using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class QuestionOperations
    {
        private QAContext databaseContext;
        private TagsOperations tagsOperations;

        public QuestionOperations()
        {
            databaseContext = new QAContext();
            tagsOperations = new TagsOperations();
        }

        public List<Question> getQuestions()
        {
            var result = databaseContext.question.OrderByDescending(x => x.CreationDate).ToList();
            return result;
        }

        public bool editQuestion(Question question)
        {
            var local = databaseContext.question.FirstOrDefault(c => c.UserId == question.UserId);
            
            
                databaseContext.Entry(local).State = EntityState.Detached;
            
            databaseContext.Entry(question).State = EntityState.Modified;
            
            // tagsOperations.updateTags(tags);
            databaseContext.SaveChanges();
            return true;
        }

        public int addQuestion(Question question)
        {
            question.CreationDate = DateTime.Now;
            databaseContext.question.Add(question);
            databaseContext.SaveChanges();
            return question.QuestionId;
        }

        public Question getById (int id){
            var output = databaseContext.question.Where(d => d.QuestionId == id).FirstOrDefault();
            return output;
        }

        public bool deleteQuestion(int id)
        {
            var output = databaseContext.question.Single(x => x.QuestionId == id);
            if(output != null)
            {
                databaseContext.question.Remove(output);

                AnswerOperations answerOperations = new AnswerOperations();
                answerOperations.deleteAllAnswer(id);
                databaseContext.SaveChanges();
            }
            
            return true;
        }

        public bool deactivateQuestion(int id)
        {
            var output = databaseContext.question.Single(x => x.QuestionId == id);
            if(output != null)
            {
                output.QuestionActive = 0;
                AnswerOperations answerOperations = new AnswerOperations();
                answerOperations.deactivateAllAnswer(id);
                databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool activateQuestion(int id)
        {
            var output = databaseContext.question.Single(x => x.QuestionId == id);
            if (output != null)
            {
                output.QuestionActive = 1;
                AnswerOperations answerOperations = new AnswerOperations();
                answerOperations.activateAllAnswer(id);
                databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Question> Search(string search)
        {
            var output = databaseContext.question.Where(x => x.QuestionName == search || x.QuestionTitle == search || x.Tag.TagName == search).ToList();
            return output;
        }
    }
}