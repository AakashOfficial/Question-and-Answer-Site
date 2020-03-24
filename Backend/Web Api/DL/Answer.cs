using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        public string AnswerName { get; set; }

        public DateTime CreationDate { get; set; }
        public int AnswerActive { get; set; }

        public int QuestionId { get; set; }

        // public virtual Question Question { get; set; }

        public int UserId { get; set; }

        // public virtual User User { get; set; }

        public virtual IList<UserReaction> Reactions { get; set; }
    }
}