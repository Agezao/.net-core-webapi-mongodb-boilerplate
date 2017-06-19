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
    public class UsersController : Controller
    {
        private ServiceManager serviceManager { get; }

        public UsersController()
        {
            serviceManager = new ServiceManager(AppConfiguration.DatabaseAddress, AppConfiguration.DatabaseName);
        }

        // GET api/users
        [HttpGet]
        public Response<IEnumerable<User>> Get()
        {
            return new Response<IEnumerable<User>>{ Data = serviceManager.UserService.ListAll() };
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public Response<User> Get(string id)
        {
            var response  = new Response<User>();
            response.Data = serviceManager.UserService.Find(ObjectId.Parse(id));
            return response;
        }

        // GET api/users/search
        [HttpGet("search")]
        public Response<List<User>> GetSearch(string id = null, string name = "", string email = "")
        {
            var response  = new Response<List<User>>();
            response.Data = serviceManager.UserService.List(new User{ 
                    Id = id, 
                    Name = name, 
                    Email = email 
                });
            return response;
        }

        // POST api/users
        [HttpPost]
        public Response<User> Post([FromBody]User model)
        {
            var response  = new Response<User>();
            response.Data = serviceManager.UserService.Create(model);
            return response;
        }

        // PUT api/users
        [HttpPut]
        public Response<User> Put([FromBody]User model)
        {
            var response  = new Response<User>();
            response.Data = serviceManager.UserService.Update(ObjectId.Parse(model.Id), model);
            return response;
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public Response<int> Delete(string id)
        {
            var response  = new Response<int>();
            response.Data = serviceManager.UserService.Delete(ObjectId.Parse(id));
            return response;
        }
    }
}
