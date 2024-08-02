using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiradhiforstage
{
    public class Diabete
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("HbA1c_level")]
        public double HbA1cLevel { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("blood_glucose_level")]
        public double BloodGlucoseLevel { get; set; }

        [BsonElement("bmi")]
        public double BMI { get; set; }

        [BsonElement("diabetes")]
        public int Diabetes { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("heart_disease")]
        public int HeartDisease { get; set; }

        [BsonElement("hypertension")]
        public int Hypertension { get; set; }

        [BsonElement("smoking_history")]
        public string SmokingHistory { get; set; }
    }
}
