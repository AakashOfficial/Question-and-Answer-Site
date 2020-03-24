using DL;
using System;
using System.Collections.Generic;
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
    }
}