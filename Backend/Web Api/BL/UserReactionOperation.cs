using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class UserReactionOperation
    {
        private QAContext databaseContext;

        public UserReactionOperation() {
            databaseContext = new QAContext();
        }

        public List<UserReaction> getReaction(int id)
        {
            var output = databaseContext.userreaction.Where(d => d.AnswerId == id).ToList();
            return output;
        }

        public bool addReaction(UserReaction userreaction)
        {
            databaseContext.userreaction.Add(userreaction);
            return true;
        }

        public bool editReaction(UserReaction userreaction)
        {
            databaseContext.Entry(userreaction).State = EntityState.Modified;
            return true;
        }

        public bool deleteReaction (int id){
            return true;
        }
    }
}