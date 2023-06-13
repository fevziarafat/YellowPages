using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Moq;
using YellowPages.Shared.Models;
using YellowPagesUI.Business.Abstract;
using YellowPagesUI.Business.Concrete;

using static System.Net.WebRequestMethods;

namespace YellowPageUI.Test
{
    public class UserControllerTest
    {
        private readonly Mock<HttpClient> _client;

        public UserControllerTest()
        {
            _client = new Mock<HttpClient>();
        }

        [Fact]
        public async Task GetUser_Returns_UserViewModel()
        {

            var expectedUser = new UserViewModel
            {
                Email = "a@a.com",
                City = "Çorum",
                Id = "1",
                UserName = "Fevzi"
            };

            _client.Setup(a => a.GetFromJsonAsync<UserViewModel>("/api/user/getuser"))
                .ReturnsAsync(expectedUser);

            var userService = new UserService(_client.Object);

            // Act
            var result = await userService.GetUser();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.UserName, result.UserName);
            // Assert other properties as needed
        }
    }




}