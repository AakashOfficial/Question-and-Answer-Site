using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserReactionOperation
    {
        private QAContext databaseContext;

        public UserReactionOperation() {
            databaseContext = new QAContext();
        }

        public List<UserReaction> getReaction(int id)
        {
            var output = databaseContext.userreaction.Where(d => d.AnswerId == id && d.ReactionActive == 1).ToList();
            return output;
        }

        public bool addReaction(UserReaction userreaction)
        {
            databaseContext.userreaction.Add(userreaction);
            databaseContext.SaveChanges();
            return true;
        }

        public bool editReaction(UserReaction userreaction)
        {
            databaseContext.Entry(userreaction).State = EntityState.Modified;
            databaseContext.SaveChanges();
            return true;
        }

        public bool deleteReaction (int id){
            var output = databaseContext.userreaction.Single(x => x.ReactionId == id);
            if (output != null)
            {
                databaseContext.userreaction.Remove(output);
                databaseContext.SaveChanges();
            }
            return true;
        }

        public bool deleteAllReaction(int id)
        {
            var output = databaseContext.userreaction.Where(d => d.AnswerId == id).ToList();
            if (output != null)
            {
                foreach(var reactions in output)
                {
                    databaseContext.userreaction.Remove(reactions);
                }
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