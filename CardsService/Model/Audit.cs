using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CardsService.Model
{
    public class Audit
    {
        [BsonRepresentation(BsonType.ObjectId), BsonId]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public int CardId { get; set; }
    }
}
