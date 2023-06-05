namespace YellowPagesService.Dtos;

public class LocationInformationDto
{
    public int LocationCount { get; set; }
    public string Location { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string ContactId { get; set; }
}