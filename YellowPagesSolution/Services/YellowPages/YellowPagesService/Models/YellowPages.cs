namespace YellowPagesService.Models;

public class YellowPages
{
    [MongoDB.Bson.Serialization.Attributes.BsonIdAttribute]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public string SurName { get; set; }
    public string Firm { get; set; }
}