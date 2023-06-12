namespace YellowPages.Shared.Models
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }

        public ServiceApi YellowPages { get; set; }

        public ServiceApi EMail { get; set; }

        public ServiceApi Phones { get; set; }

        public ServiceApi Locations { get; set; }
        public ServiceApi Report { get; set; }

    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}