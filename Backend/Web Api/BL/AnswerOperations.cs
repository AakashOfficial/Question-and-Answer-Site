using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AnswerOperations
    {
        private QAContext databaseContext;

        public AnswerOperations()
        {
            databaseContext = new QAContext();
        }

        public List<Answer> getAnswers(int id)
        {
            var result = databaseContext.answer.Where(d => d.QuestionId == id).ToList();
            return result;
        }

        // for getting the count of the Answers of a Question
        public int getAnswerCount(int id) {
            int count = 0;

            count = databaseContext.answer.Where(d => d.QuestionId == id).Count();
            if(count > 0){
                return count;
            }
            else
            {
                return 0;
            }
        }

        // for edit the answer
        public bool editAnswer(Answer answer)
        {
            databaseContext.Entry(answer).State = EntityState.Modified;
            databaseContext.SaveChanges();
            return true;
        }

        // for add the answer
        public bool addAnswer(Answer answer)
        {
            databaseContext.answer.Add(answer);
            return true;
        }

        public bool deleteAnswer(int id)
        {
            return true;
        }
    }
}