using System;
using System.Linq;
using Models;
using Services.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;


namespace Services.Implementation
{
    public class UserService : BaseService<User>
    {
        public UserService(IMongoDatabase db) : base(db, "users") { }

        public List<User> List(User model) {
            var users = this._ctx.AsQueryable().ToList()
                        .Where(c => c.Name.ToLower().IndexOf(model.Name.ToLower()) > -1 )
                        .ToList();

            users.ForEach(u => u.Password = "");

            return users;
        }

        public override List<User> ListAll() {
            var users = base.ListAll();
            users.ForEach(u => u.Password = "");
            return users;
        }

        public override User Find(ObjectId id)
        {
            var user = base.Find(id);
            user.Password = "";

            return user;
        }

        public User FindUnsafe(ObjectId id)
        {
            var user = base.Find(id);

            return user;
        }
    }
}