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

        // GET api/<controller>/5
        [HttpGet]
        public IEnumerable<Question> getQuestionById(int id)
        {
            var result = questionoperation.getById(id);
            return result;
        }

        // POST api/<controller>
        [HttpPost]
        public void AddQuestion(Question question)
        {
            questionoperation.addQuestion(question);
        }

        [HttpPut]
        // PUT api/<controller>/5
        public void updateQuestion(Question question)
        {
            questionoperation.editQuestion(question);
        }

        [HttpPut]
        public void deactivateQuestion(int id)
        {
            questionoperation.deactivateQuestion(id);
        }

    }
}