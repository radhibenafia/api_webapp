using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace apiradhiforstage
{
    public class Training
    {    
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // Champ Id pour MongoDB

        [BsonElement("customersexecies")]
        public string[] Customersexecies { get; set; } // Tableau de chaînes

        [BsonElement("mail")]
        public string Mail { get; set; } // Chaîne de caractères pour l'email
    }

}

