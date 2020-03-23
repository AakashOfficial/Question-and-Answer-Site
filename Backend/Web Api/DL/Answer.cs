﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        public string AnswerName { get; set; }

        public DateTime CreationDate { get; set; }
        public int AnswerActive { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public virtual IList<UserReaction> Reactions { get; set; }
    }
}