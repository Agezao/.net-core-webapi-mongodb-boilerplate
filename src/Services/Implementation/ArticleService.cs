using System;
using System.Linq;
using Models;
using Services.Interface;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;


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
    }
}