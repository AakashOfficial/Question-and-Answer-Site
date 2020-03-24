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

        public QuestionOperations()
        {
            databaseContext = new QAContext();
        }

        public List<Question> getQuestions()
        {
            var result = databaseContext.question.ToList();
            return result;
        }

        public bool editQuestion(Question question)
        {
            databaseContext.Entry(question).State = EntityState.Modified;
            databaseContext.SaveChanges();
            return true;
        }

        public bool addQuestion(Question question)
        {
            databaseContext.question.Add(question);
            return true;
        }

        public bool deleteQuestion(int id)
        {

            return true;
        }

    }
}