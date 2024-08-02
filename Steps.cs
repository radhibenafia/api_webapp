using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace apiradhiforstage
{
    public class Steps
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("steps")]
        public string StepsData { get; set; }

        // Autres propriétés si nécessaires
    }
}
