namespace YellowPages.Shared.Models
{
public class EMailInformation : MongoDbEntity
    {


    public string EMail { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string ContactId { get; set; }
}
}