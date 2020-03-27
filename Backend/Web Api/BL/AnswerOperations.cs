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
            var result = databaseContext.answer.Where(d => d.QuestionId == id && d.AnswerActive == 1).ToList();
            return result;
        }

        // for getting the count of the Answers of a Question
        public int getAnswerCount(int id) {
            int count = 0;

            count = databaseContext.answer.Where(d => d.QuestionId == id && d.AnswerActive == 1).Count();
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

    }
}