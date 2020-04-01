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
        public int AddQuestion(Question question)
        {
            var output = questionoperation.addQuestion(question);
            return output;
        }

        [HttpPut]
        // PUT api/<controller>/5
        public bool updateQuestion(Question question)
        {
            var output = questionoperation.editQuestion(question);
            return output;
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

        public int saveTags(Tags tag)
        {
            TagsOperations tagOperations = new TagsOperations();
            var output = tagOperations.addTags(tag);
            return output;
        }

        [HttpGet]
        public List<Question> Search(string search)
        {
            var output = questionoperation.Search(search);
            return output;
        }
    }
}