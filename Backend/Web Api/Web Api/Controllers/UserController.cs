using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using DL;

namespace Web_Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private UserOperations useroperation;

        public UserController()
        {
            useroperation = new UserOperations();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IEnumerable<User> getUserbyId(int id)
        {
            var output = useroperation.getUser(id);
            return output;
        }

        // GET api/user/validateUser
        [HttpGet]
        public User ValidateUser(string email, string password)
        {
            var userId = useroperation.validate(email, password);
            return userId;
        }

        // POST api/<controller>
        [HttpPost]
        public User addUser(User user)
        {
            var output = useroperation.addUser(user);
            return user;
            // return output;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}