using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class UserOperations
    {
        private QAContext databaseContext;

        public UserOperations()
        {
            databaseContext = new QAContext();
        }

        // For adding the User
        public bool addUser(User user)
        {
            databaseContext.user.Add(user);
            databaseContext.SaveChanges();
            return true;
        }

        public IEnumerable<User> getUser(int id)
        {
            var result = databaseContext.user.ToList().Where(d => d.UserId == id);
            return result;
        }
    }
}
