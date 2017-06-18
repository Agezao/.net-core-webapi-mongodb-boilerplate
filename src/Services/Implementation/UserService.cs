using System;
using System.Linq;
using Models;
using Services.Interface;
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

            return users;
        }
    }
}