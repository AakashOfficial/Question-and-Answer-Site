using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Please Enter Event Date")]
        public string QuestionName { get; set; }

        public string QuestionTitle { get; set; }
        public DateTime CreationDate { get; set; }

        public int QuestionActive { get; set; }

        public int UserId { get; set; }

        public string QuestionImage { get; set; }

        public int QuestionTagId { get; set; }

        // public virtual Tags Tags { get; set; }

        // [ForeignKey("UserId")]
        public virtual User Users { get; set; }

        public virtual Tags Tag { get; set; }

        public virtual IList<Answer> Answers { get; set; }
    }
}
