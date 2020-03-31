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

        public DateTime CreationDate { get; set; }

        public int QuestionActive { get; set; }

        public int UserId { get; set; }
        
        public int TagId { get; set; }
        // [ForeignKey("UserId")]
        //public virtual User User { get; set; }

        public virtual IList<Answer> Answers { get; set; }
    }
}
