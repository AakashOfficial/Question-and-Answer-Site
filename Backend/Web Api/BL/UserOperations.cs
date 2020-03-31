using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            System.Diagnostics.Debug.WriteLine(user.UserEmail);
            var userData = databaseContext.user.Where(x => x.UserEmail == user.UserEmail).Count();
            System.Diagnostics.Debug.WriteLine(userData);
            if (userData == 0)
            {
                databaseContext.user.Add(user);
                databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public IEnumerable<User> getUser(int id)
        {
            var result = databaseContext.user.ToList().Where(d => d.UserId == id);
            return result;
        }

        public bool editUser(User user)
        {
            databaseContext.Entry(user).State = EntityState.Modified;
            databaseContext.SaveChanges();
            return true;
        }

        public IEnumerable<User> findUser(string email,string password)
        {
            var result = databaseContext.user.ToList().Where(d => d.UserEmail == email && d.UserPassword == password);
            return result;
        }

        public int validate(string email, string password)
        {
            var result = databaseContext.user.ToList().Where(d => d.UserEmail == email && d.UserPassword == password).FirstOrDefault();
            if(result != null)
            {
                return result.UserId;
            }
            else
            {
                return 0;
            }
            
        }
    }
}