using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryStringAPI.Models
{
    public class BinaryString
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }
    }
}
