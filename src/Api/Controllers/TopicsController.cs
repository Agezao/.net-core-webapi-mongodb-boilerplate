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
    public class TopicsController : Controller
    {
        private ServiceManager serviceManager { get; }

        public TopicsController()
        {
            serviceManager = new ServiceManager(AppConfiguration.DatabaseAddress, AppConfiguration.DatabaseName);
        }

        // GET api/topics
        [HttpGet]
        public Response<IEnumerable<Topic>> Get()
        {
            return new Response<IEnumerable<Topic>>{ Data = serviceManager.TopicService.ListAll() };
        }

        // GET api/topics/5
        [HttpGet("{id}")]
        public Response<Topic> Get(string id)
        {
            var response  = new Response<Topic>();
            response.Data = serviceManager.TopicService.Find(ObjectId.Parse(id));
            return response;
        }

        // GET api/topics/search
        [HttpGet("search")]
        public Response<List<Topic>> GetSearch(string id = null, string title = "")
        {
            var response  = new Response<List<Topic>>();
            response.Data = serviceManager.TopicService.List(new Topic{ 
                    Id = id, 
                    Title = title
                });
            return response;
        }

        // POST api/topics
        [HttpPost]
        public Response<Topic> Post([FromBody]Topic model)
        {
            var response  = new Response<Topic>();
            response.Data = serviceManager.TopicService.Create(model);
            return response;
        }

        // PUT api/topics
        [HttpPut]
        public Response<Topic> Put([FromBody]Topic model)
        {
            var response  = new Response<Topic>();
            response.Data = serviceManager.TopicService.Update(ObjectId.Parse(model.Id), model);
            return response;
        }

        // DELETE api/topics/5
        [HttpDelete("{id}")]
        public Response<int> Delete(string id)
        {
            var response  = new Response<int>();
            response.Data = serviceManager.TopicService.Delete(ObjectId.Parse(id));
            return response;
        }
    }
}
