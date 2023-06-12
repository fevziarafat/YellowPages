using System;

namespace YellowPages.Shared.Models
{
    public class YellowPagesReport : MongoDbEntity
    {
        //[MongoDB.Bson.Serialization.Attributes.BsonId]
        //[MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        //public string Id { get; set; }

        public DateTime CreatedTime { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public int LocationContactCount { get; set; }
        public int LocationPhoneCount { get; set; }
    }
}