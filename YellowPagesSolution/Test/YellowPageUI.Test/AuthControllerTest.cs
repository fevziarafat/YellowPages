using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

using Moq;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;

using YellowPagesUI.Business.Abstract;
using YellowPagesUI.Controllers;

namespace YellowPageUI.Test
{
    public class AuthControllerTest
    {
        private readonly Mock<IIdentityService> _mockRepo;

        private readonly AuthController _controller;

        private SigninInput signinInput;

        public AuthControllerTest()
        {
            _mockRepo = new Mock<IIdentityService>();
            _controller = new AuthController(_mockRepo.Object);

            signinInput = new SigninInput { Email = "fevziarafat@gmail.com", Password = "49d2d918A1.", IsRemember = false };
        }

        [Fact]
        public void SignIn_ActionExecutes_ReturnView()
        {
            var result = _controller.SignIn();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task SignIn_ActionExecutes_IfModelStateIsNotValid_ReturnView()
        {
            _controller.ModelState.AddModelError("FieldName", "Invalid value");

            var result = await _controller.SignIn(new SigninInput());

            Assert.IsType<ViewResult>(result);
        }

        
    }
}
