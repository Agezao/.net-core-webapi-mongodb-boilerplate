using System;
using System.Linq;
using Models;
using Services.Interface;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Services.Interface
{
    public abstract class BaseService<T> : IService<T>
    {
        protected IMongoDatabase _db { get; }
        protected IMongoCollection<T> _ctx { get; }

        public BaseService(IMongoDatabase db, string collectionName)
        {
            this._db = db;
            this._ctx = this._db.GetCollection<T>(collectionName);
        }

        public virtual T Create(T model)
        {
            this._ctx.InsertOne(model);

            return model;
        }

        public virtual T Update(ObjectId id, T model)
        {
            this._ctx.ReplaceOne(Builders<T>.Filter.Eq("_id", id), model);

            return model;
        }

        public virtual int Delete(ObjectId id)
        {
            var result = this._ctx.DeleteOne(Builders<T>.Filter.Eq("_id", id));

            return int.Parse(result.DeletedCount.ToString());
        }

        public virtual List<T> ListAll()
        {
            var response = this._ctx.AsQueryable().ToList();

            return response;
        }

        public virtual T Find(ObjectId id)
        {
            var result = this._ctx.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefault();

            return result;
        }
    }
}