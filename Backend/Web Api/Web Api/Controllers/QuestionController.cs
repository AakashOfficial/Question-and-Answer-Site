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
        [HttpGet]
        public List<Question> getAllQuestion()
        {
            var result = questionoperation.getQuestions();
            return result;
        }

    }
}