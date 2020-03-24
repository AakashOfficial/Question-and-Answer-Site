using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string UserPassword { get; set; }

        public string UserProfilePicture { get; set; }
        [Required]
        public int UserActive { get; set; }

        public DateTime CreationDate { get; set; }
        public virtual IList<Question> Questions { get; set; }
    }
}