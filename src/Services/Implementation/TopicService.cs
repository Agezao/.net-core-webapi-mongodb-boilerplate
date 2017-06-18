using System;
using System.Linq;
using Models;
using Services.Interface;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;


namespace Services.Implementation
{
    public class TopicService : BaseService<Topic>
    {
        public TopicService(IMongoDatabase db) : base(db, "topics") { }

        public List<Topic> List(Topic model) {
            var objs = this._ctx.AsQueryable().ToList()
                        .Where(c => c.Title.ToLower().IndexOf(model.Title.ToLower()) > -1 )
                        .ToList();

            return objs;
        }
    }
}