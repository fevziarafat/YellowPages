using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YellowPagesUI.Services
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public string YellowPageUri { get; set; }

        public ServiceApi YellowPages { get; set; }

        public ServiceApi Report { get; set; }

    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}