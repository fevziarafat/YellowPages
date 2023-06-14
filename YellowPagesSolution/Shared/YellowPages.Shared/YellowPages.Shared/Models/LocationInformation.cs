namespace YellowPages.Shared.Models
{
    public class LocationInformation : MongoDbEntity
    {


    public string Location { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string ContactId { get; set; }
}
}