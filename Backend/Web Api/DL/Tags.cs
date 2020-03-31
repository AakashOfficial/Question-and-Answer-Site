using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Tags
    {
        [Key]
        public int QuestionId { get; set; }

        public string TagName { get; set; }

        public DateTime CreationDate { get; set; }

        public int TagActive { get; set; }
    }
}