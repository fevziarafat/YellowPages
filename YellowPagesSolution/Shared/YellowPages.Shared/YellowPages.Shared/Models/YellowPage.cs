﻿using System.Collections.Generic;

namespace YellowPages.Shared.Models
{
    public class YellowPage : MongoDbEntity
    {
    public YellowPage()
    {
        EMailInformation = new HashSet<EMailInformation>();
        LocationInformation = new HashSet<LocationInformation>();
        PhoneInformation = new HashSet<PhoneInformation>();
    }



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