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
        public int getAllReaction(int id,int type)
        {
            var output = userReactionOperation.getReactionCount(id,type);

            return output;
        }


        [HttpPost]
        public bool addReaction(UserReaction userreaction)
        {
            var output = userReactionOperation.addReaction(userreaction);
            return output;
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