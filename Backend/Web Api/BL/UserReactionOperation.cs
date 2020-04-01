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

        public int getReactionCount(int id,int type)
        {
            var output = databaseContext.userreaction.Where(d => d.AnswerId == id && d.ReactionActive == 1 && d.ReactionType == type).ToList().Count();
            return output;
        }

        public bool addReaction(UserReaction userreaction)
        {
            var output = databaseContext.userreaction.Where(d => d.AnswerId == userreaction.AnswerId && d.UserId == userreaction.UserId).ToList().Count();
            if(output > 0)
            {
                return false;
            }
            userreaction.CreationDate = DateTime.Now;
            databaseContext.userreaction.Add(userreaction);
            databaseContext.SaveChanges();
            return true;
        }

        public bool editReaction(int id)
        {
            var output = databaseContext.userreaction.Single(x => x.ReactionId == id);
            if(output != null)
            {
                if(output.ReactionType == 1)
                {
                    output.ReactionType = 0;
                }
                else
                {
                    output.ReactionType = 1;
                }
            }
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

        public bool activateAllReaction(int id)
        {
            var output = databaseContext.userreaction.Where(d => d.AnswerId == id && d.ReactionActive == 0).ToList();

            if (output != null)
            {
                foreach (var reactions in output)
                {
                    reactions.ReactionActive = 1;
                }
                databaseContext.SaveChanges();
            }
            return true;
        }

        public bool deactivateAllReaction(int id)
        {
            var output = databaseContext.userreaction.Where(d => d.AnswerId == id && d.ReactionActive == 1).ToList();

            if (output != null)
            {
                foreach (var reactions in output)
                {
                    reactions.ReactionActive = 0;
                }
                databaseContext.SaveChanges();
            }
            return true;
        }

        public int Votes(int id, int type)
        {
            int count = databaseContext.userreaction.Where(d => d.AnswerId == id && d.ReactionActive == 1 && d.ReactionType == type).ToList().Count();
            return count;
        }
    }
}