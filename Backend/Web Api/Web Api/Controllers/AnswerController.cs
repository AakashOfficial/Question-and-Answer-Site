using BL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Web_Api.Controllers
{
    public class AnswerController : ApiController
    {
        private AnswerOperations answerOperations;
        public AnswerController()
        {
            answerOperations = new AnswerOperations();
        }
        // GET: Answer
        public List<Answer> get(int id)
        {
            var result = answerOperations.getAnswers(id);
            return result;            
        }
    }
}