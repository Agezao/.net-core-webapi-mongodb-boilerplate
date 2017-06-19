using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    [Serializable]
    public class Article
    {
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastChange { get; set; }
        public DateTime Created { get; set; }

        [BsonRepresentation(BsonType.ObjectId)] 
        public string UserId { get; set; }
        public User User { get; set; }

        [BsonRepresentation(BsonType.ObjectId)] 
        public string TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
