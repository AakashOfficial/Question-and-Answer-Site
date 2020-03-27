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

        [HttpGet]
        public IEnumerable<Answer> getAnswerById(int id)
        {
            return null;
        }

        [HttpPut]
        public void activateAnswer(int id)
        {
            answerOperations.activateAnswer(id);
        }

        [HttpPut]
        public void deactivateAnswer(int id)
        {
            answerOperations.deactivateAnswer(id);
        }

        [HttpPost]
        public void addAnswer(Answer answer)
        {
            answerOperations.addAnswer(answer);
        }

        [HttpPut]
        public void updateAnswer(Answer answer)
        {
            answerOperations.editAnswer(answer);
        }

        [HttpDelete]
        public void deleteAnswer(int id)
        {
            answerOperations.deleteAnswer(id);
        }
    }
}