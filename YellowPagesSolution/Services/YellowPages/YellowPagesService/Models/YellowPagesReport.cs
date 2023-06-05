namespace YellowPagesService.Models;

public class YellowPagesReport
{
    [MongoDB.Bson.Serialization.Attributes.BsonIdAttribute]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public DateTime CreatedTime { get; set; }
    public string State { get; set; }
    public string Location { get; set; }
    public int LocationContactCount { get; set; }
    public int LocationPhoneCount { get; set; }
}