using BL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class QuestionController : ApiController
    {
        private QuestionOperations questionoperation;
        public QuestionController()
        {
            questionoperation = new QuestionOperations();
        }

        // GET api/<controller>
        public List<Question> GetAll()
        {
            var result = questionoperation.getQuestions();
            return result;
        }

        // GET api/<controller>/5
        // public IEnumerable<string> Get(int id)
        //{//
            
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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