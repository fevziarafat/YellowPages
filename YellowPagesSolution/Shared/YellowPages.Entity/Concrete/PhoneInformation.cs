﻿namespace YellowPages.Entities.Concrete
{
public class PhoneInformation:MongoDbEntity
{
    [MongoDB.Bson.Serialization.Attributes.BsonIdAttribute]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public string Phone { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string ContactId { get; set; }
}}