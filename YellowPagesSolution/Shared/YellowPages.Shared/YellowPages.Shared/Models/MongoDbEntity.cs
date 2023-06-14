using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

using System;
using System.Collections.Generic;
using System.Text;

namespace YellowPages.Shared.Models
{
    public abstract class MongoDbEntity : IEntity<string>
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
      
        public string Id { get; set; } 

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
     
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
