﻿namespace YellowPagesReportService.Models;

public class YellowPages
{
    [MongoDB.Bson.Serialization.Attributes.BsonId]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public string SurName { get; set; }
    public string Firm { get; set; }
}