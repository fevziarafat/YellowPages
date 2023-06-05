namespace YellowPagesReportService.Models;

public class YellowPages
{
    public YellowPages()
    {
        EMailInformation = new HashSet<EMailInformation>();
        LocationInformation = new HashSet<LocationInformation>();
        PhoneInformation = new HashSet<PhoneInformation>();
    }

    [MongoDB.Bson.Serialization.Attributes.BsonIdAttribute]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentationAttribute(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public string SurName { get; set; }
    public string Firm { get; set; }


    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreAttribute]
    public virtual ICollection<EMailInformation> EMailInformation { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreAttribute]
    public virtual ICollection<LocationInformation> LocationInformation { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreAttribute]
    public virtual ICollection<PhoneInformation> PhoneInformation { get; set; }
}