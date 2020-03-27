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

        // for add the answer
        public bool addAnswer(Answer answer)
        {
            databaseContext.answer.Add(answer);
            databaseContext.SaveChanges();
            return true;
        }

        public bool deleteAnswer(int id)
        {
            var output = databaseContext.answer.Single(x => x.AnswerId == id);
            if(output != null)
            {
                databaseContext.answer.Remove(output);
                UserReactionOperation userReactionOperation = new UserReactionOperation();
                userReactionOperation.deleteAllReaction(id);
                databaseContext.SaveChanges();
            }
            return true;
        }

        public bool deactivateAnswer(int id)
        {
            var output = databaseContext.answer.Single(x => x.AnswerId == id);

            if(output != null)
            {
                output.AnswerActive = 0;
                UserReactionOperation userReactionOperation = new UserReactionOperation();
                userReactionOperation.deactivateAllReaction(id);
                databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool activateAnswer(int id)
        {
            var output = databaseContext.answer.Single(x => x.AnswerId == id);

            if (output != null)
            {
                output.AnswerActive = 1;
                UserReactionOperation userReactionOperation = new UserReactionOperation();
                userReactionOperation.activateAllReaction(id);
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