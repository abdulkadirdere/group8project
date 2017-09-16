using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group8.Models
{
    public class PGO
    {
        [Key]
        public int PGO_ID { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name*")]
        public string PGO_First_Name { get; set; }
        public string PGO_Last_Name { get; set; }
        public string PGO_ID_Number{ get; set; }
        public string PGO_Email { get; set; }
        public string PGO_Contact_No { get; set; }
        public string PGO_Password { get; set; }
        public string PGO_Status { get; set; }
        public virtual ICollection<Application> Application { get; set; }
    }
}