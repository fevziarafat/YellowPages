namespace YellowPagesService.Models;

public class PhoneInformation
{
    [MongoDB.Bson.Serialization.Attributes.BsonIdAttribute]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public string Phone { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string ContactId { get; set; }
}