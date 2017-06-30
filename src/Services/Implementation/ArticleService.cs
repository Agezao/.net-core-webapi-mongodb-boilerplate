using System;
using System.Linq;
using Models;
using Services.Interface;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Services.Implementation
{
    public class ArticleService : BaseService<Article>
    {
        public ArticleService(IMongoDatabase db) : base(db, "articles") { }

        public List<Article> List(Article model) {
            var objs = this._ctx.AsQueryable().ToList()
                        .Where(c => c.Title.ToLower().IndexOf(model.Title.ToLower()) > -1 )
                        .ToList();

            return objs;
        }

        public override List<Article> ListAll()
        {
            var response = base.ListAll();

            if (response != null && response.Count > 0)
                response.ForEach(a => {
                    a = Populate(a);
                });

            return response;
        }

        public override Article Find(ObjectId id)
        {
            var result = base.Find(id);
            result = Populate(result);

            return result;
        }

        private Article Populate(Article model) {

            var topicService = new TopicService(base._db);
            var userService = new UserService(base._db);

            model.User = userService.Find(ObjectId.Parse(model.UserId));
            model.Topic = topicService.Find(ObjectId.Parse(model.TopicId));

            return model;
        }
    }
}