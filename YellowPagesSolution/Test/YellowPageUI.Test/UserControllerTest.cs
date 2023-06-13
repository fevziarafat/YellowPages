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

       
    }




}