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
        //[BsonRepresentation(BsonType.ObjectId)]
        //[BsonId]
        //[BsonElement(Order = 0)]
        public string Id { get; set; } 

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        //[BsonElement(Order = 101)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
