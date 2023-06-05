

namespace YellowPages.Shared.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string YellowPagesCollectionName { get; set; }
        public string YellowPagesReportCollectionName { get; set; }
        public string EMailInformationCollectionName { get; set; }
        public string LocationInformationCollectionName { get; set; }
        public string PhoneInformationCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}