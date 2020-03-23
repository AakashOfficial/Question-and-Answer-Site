using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    class Tags
    {
        [Key]
        public int QuestionTagId { get; set; }

        public string TagName { get; set; }

        public int QuestionId { get; set; }

        public DateTime CreationDate { get; set; }

        public int TagActive { get; set; }

        public virtual Question Question { get; set; }
    }
}