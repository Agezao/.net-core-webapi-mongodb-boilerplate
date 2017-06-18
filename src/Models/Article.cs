using System;
using MongoDB.Bson;

namespace Models
{
    [Serializable]
    public class Article
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastChange { get; set; }
        public DateTime Created { get; set; }

        public ObjectId UserId { get; set; }
        public User User { get; set; }

        public ObjectId TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
