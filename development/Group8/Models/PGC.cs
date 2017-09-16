using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group8.Models
{
    public class PGC
    {
        [Key]
        public int PGC_ID { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name*")]
        public string PGC_First_Name { get; set; }
        public string PGC_Last_Name { get; set; }
        public string PGC_ID_Number { get; set; }
        public string PGC_Email { get; set; }
        public string PGC_Contact_No { get; set; }
        public string PGC_Password { get; set; }
        public string PGC_Status { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }
        public virtual ICollection<Application> Application { get; set; }
    }
}