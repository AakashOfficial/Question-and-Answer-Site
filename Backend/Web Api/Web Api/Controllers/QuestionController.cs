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
    [EnableCors(origins: "*", headers:"*",methods:"*")]
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
        public Question getQuestionById(int id)
        {
            var result = questionoperation.getById(id);
            return result;
        }

        // POST api/<controller>
        [HttpPost]
        public void AddQuestion(QuestionTag questiontag)
        {
            Question question = questiontag.question;
            Tags tags = questiontag.tags;
            System.Diagnostics.Debug.WriteLine("Aa Rhi");
            questionoperation.addQuestion(question,tags);
        }

        [HttpPut]
        // PUT api/<controller>/5
        public void updateQuestion(Question question, Tags tags)
        {
            questionoperation.editQuestion(question,tags);
        }

        [HttpPut]
        public void deactivateQuestion(int id)
        {
            questionoperation.deactivateQuestion(id);
        }

        [HttpPut]
        public void activateQuestion(int id)
        {
            questionoperation.activateQuestion(id);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void deleteQuestion(int id)
        {
            questionoperation.deleteQuestion(id);
        }
    }
}