﻿using BL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Api.Controllers
{
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
        
    }
}