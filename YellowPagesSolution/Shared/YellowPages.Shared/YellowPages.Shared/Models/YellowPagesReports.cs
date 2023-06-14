using System;

namespace YellowPages.Shared.Models
{
    public class YellowPagesReport : MongoDbEntity
    {
       

        public DateTime CreatedTime { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public int LocationContactCount { get; set; }
        public int LocationPhoneCount { get; set; }
    }
}