using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Please Enter Event Date")]
        public string QuestionName { get; set; }

        public DateTime CreationDate { get; set; }

        public int QuestionActive { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual IList<Answer> Answers { get; set; }
    }
}
