﻿using System;
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
            var userData = databaseContext.user.Where(x => x.UserEmail == user.UserEmail);
            if(userData == null)
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
    }
}