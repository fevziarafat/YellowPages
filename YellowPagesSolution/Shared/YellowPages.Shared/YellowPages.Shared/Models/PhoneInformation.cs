namespace YellowPages.Shared.Models
{
public class PhoneInformation : MongoDbEntity
    {
 

    public string Phone { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string ContactId { get; set; }
}}