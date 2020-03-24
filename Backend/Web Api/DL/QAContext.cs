using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DL
{
    public class QAContext : DbContext
    {
        public DbSet<User> user { get; set; }

        public DbSet<Question> question { get; set; }

        public DbSet<Answer> answer { get; set; }

        public DbSet<UserReaction> userreaction { get; set; }

        public DbSet<Tags> tags { get; set; }
    }
}