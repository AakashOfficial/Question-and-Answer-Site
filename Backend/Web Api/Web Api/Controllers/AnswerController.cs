using BL;
using DL;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net;
using System.Net.Http;

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
        [HttpGet]
        public List<Answer> getAllAnswer(int id)
        {
            var result = answerOperations.getAnswers(id);
            return result;            
        }

    }
}