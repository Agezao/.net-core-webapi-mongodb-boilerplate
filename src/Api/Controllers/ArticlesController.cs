using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace webapi_boilerplate.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private ServiceManager serviceManager { get; }

        public ArticlesController()
        {
            serviceManager = new ServiceManager(AppConfiguration.DatabaseAddress, AppConfiguration.DatabaseName);
        }

        // GET api/articles
        [HttpGet]
        public Response<IEnumerable<Article>> Get()
        {
            return new Response<IEnumerable<Article>>{ Data = serviceManager.ArticleService.ListAll() };
        }

        // GET api/articles/5
        [HttpGet("{id}")]
        public Response<Article> Get(string id)
        {
            var response  = new Response<Article>();
            response.Data = serviceManager.ArticleService.Find(ObjectId.Parse(id));
            return response;
        }

        // GET api/articles/search
        [HttpGet("search")]
        public Response<List<Article>> GetSearch(string id = null, string title = "")
        {
            var response  = new Response<List<Article>>();
            response.Data = serviceManager.ArticleService.List(new Article{ 
                    Id = id, 
                    Title = title
                });
            return response;
        }

        // POST api/articles
        [HttpPost]
        public Response<Article> Post([FromBody]Article model)
        {
            var response  = new Response<Article>();
            response.Data = serviceManager.ArticleService.Create(model);
            return response;
        }

        // PUT api/articles
        [HttpPut]
        public Response<Article> Put([FromBody]Article model)
        {
            var response  = new Response<Article>();
            response.Data = serviceManager.ArticleService.Update(ObjectId.Parse(model.Id), model);
            return response;
        }

        // DELETE api/articles/5
        [HttpDelete("{id}")]
        public Response<int> Delete(string id)
        {
            var response  = new Response<int>();
            response.Data = serviceManager.ArticleService.Delete(ObjectId.Parse(id));
            return response;
        }
    }
}
