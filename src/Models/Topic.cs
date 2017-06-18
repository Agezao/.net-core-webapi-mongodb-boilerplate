using System;
using MongoDB.Bson;

namespace Models
{
    [Serializable]
    public class Topic
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
