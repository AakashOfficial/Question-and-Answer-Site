using BL;
using DL;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;

namespace Web_Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [HttpGet]
        public Answer getAnswerById(int id)
        {
            var output = answerOperations.getAnswer(id);

            return output;
        }

        [HttpPut]
        public bool activateAnswer(int id)
        {
            answerOperations.activateAnswer(id);
            return true;
        }

        [HttpPut]
        public bool deactivateAnswer(int id)
        {
            answerOperations.deactivateAnswer(id);
            return true;
        }

        [HttpPost]
        public bool addAnswer(Answer answer)
        {
            var output = answerOperations.addAnswer(answer);
            return output;
        }

        [HttpPut]
        public bool updateAnswer(Answer answer)
        {
            answerOperations.editAnswer(answer);
            return true;
        }

        [HttpDelete]
        public void deleteAnswer(int id)
        {
            answerOperations.deleteAnswer(id);
        }
    }
}