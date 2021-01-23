using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Models
{
    public class VitalSign
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public int CardiacFrequency { get; set; }
        public double Temperature { get; set; }
        public double SpO2 { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
