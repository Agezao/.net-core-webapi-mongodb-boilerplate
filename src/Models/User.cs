using System;
using MongoDB.Bson;

namespace Models
{
    [Serializable]
    public class User
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
