using Microsoft.AspNetCore.Mvc;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowPagesUI.Business.Abstract;

using Moq;
using YellowPages.Shared.Dtos;
using YellowPages.Shared.Models;

using YellowPagesUI.Business.Abstract;
using YellowPagesUI.Controllers;
using Microsoft.Extensions.Logging;

namespace YellowPageUI.Test
{
    public class HomeControllerTest
    {
        private readonly HomeController _controller;

        private readonly ILogger<HomeController> _logger;

        public HomeControllerTest()
        {
            _controller = new HomeController(_logger);
        }
        [Fact]
        public async Task Index_Returns_ViewResult()
        {
            var result = await _controller.Index();
           
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
