using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    class UserReaction
    {
        [Key]
        public int ReactionId { get; set; }

        public int ReactionType { get; set; }

        public DateTime CreationDate { get; set; }

        public int ReactionActive { get; set; }

        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}