using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiradhiforstage
{
    public class Employe
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nom")]
        public string Nom { get; set; }

        [BsonElement("prenom")]
        public string Prenom { get; set; }

        [BsonElement("height")]
        public string Height { get; set; }

        [BsonElement("weight")]
        public string Weight { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}

