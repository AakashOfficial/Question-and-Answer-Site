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
            var result = databaseContext.question.ToList();
            return result;
        }

        public bool editQuestion(Question question, Tags tags)
        {
            databaseContext.Entry(question).State = EntityState.Modified;
            tagsOperations.updateTags(tags);
            databaseContext.SaveChanges();
            return true;
        }

        public bool addQuestion(Question question, Tags tags)
        {
            var tagId = tagsOperations.addTags(tags);
            question.QuestionTagId = tagId;
            databaseContext.question.Add(question);
            return true;
        }

        public IEnumerable<Question> getById (int id){
            var output = databaseContext.question.ToList().Where(d => d.QuestionId == id);
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
    }
}