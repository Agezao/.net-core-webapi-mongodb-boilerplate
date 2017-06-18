using Services.Implementation;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager
    {
        private MongoClient _client { get; }
        private IMongoDatabase _db { get; }

        // Services
        public TopicService TopicService { get; }
        public ArticleService ArticleService { get; }
        public UserService UserService { get; }

        public ServiceManager(string host, string dbname)
        {
            this._client = new MongoClient(host);
            this._db = this._client.GetDatabase(dbname);

            this.TopicService = new TopicService(_db);
            this.ArticleService = new ArticleService(_db);
            this.UserService = new UserService(_db);
        }
    }
}