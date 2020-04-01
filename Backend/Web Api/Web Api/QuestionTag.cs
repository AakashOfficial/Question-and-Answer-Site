using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api
{

    public class QuestionTag
    {
        // question table object 
        public Question question { get; set; }
        // tag table object
        public Tags tags { get; set; }
    }
}