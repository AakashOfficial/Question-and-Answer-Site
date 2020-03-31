using BL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Web_Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserReactionController : ApiController
    {
        private UserReactionOperation userReactionOperation;

        public UserReactionController()
        {
            userReactionOperation = new UserReactionOperation();
        }

        [HttpGet]
        public IEnumerable<UserReaction> getAllReaction(int id)
        {
            var output = userReactionOperation.getReaction(id);

            return output;
        }


        [HttpPost]
        public void addReaction(UserReaction userreaction)
        {
            userReactionOperation.addReaction(userreaction);
        }

        [HttpPut]
        public void updateReaction(int id)
        {
            userReactionOperation.editReaction(id);
        }

        [HttpDelete]
        public void deleteReaction(int id)
        {
            userReactionOperation.deleteReaction(id);
        }

    }
}