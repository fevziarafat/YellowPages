using System.Collections.Generic;

namespace YellowPages.Shared.Models
{
    public class YellowPages
{
    public YellowPages()
    {
        EMailInformation = new HashSet<EMailInformation>();
        LocationInformation = new HashSet<LocationInformation>();
        PhoneInformation = new HashSet<PhoneInformation>();
    }

    [MongoDB.Bson.Serialization.Attributes.BsonId]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public string SurName { get; set; }
    public string Firm { get; set; }


    [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
    public virtual ICollection<EMailInformation> EMailInformation { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
    public virtual ICollection<LocationInformation> LocationInformation { get; set; }

    [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
    public virtual ICollection<PhoneInformation> PhoneInformation { get; set; }
}
}