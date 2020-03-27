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

    }
}