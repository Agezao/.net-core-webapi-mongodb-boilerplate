using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [Serializable]
    public class Topic
    {
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
