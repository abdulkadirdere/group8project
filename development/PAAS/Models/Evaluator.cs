using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAAS.Models
{
    public class Evaluator
    {
        [Key]
        [Display(Name = "Evaluator ID")]
        public int Evaluator_ID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name*")]
        public string Evaluator_First_Name { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name*")]
        public string Evaluator_Last_Name { get; set; }

        [Required(ErrorMessage = "Please enter your ID Number.")]
        [StringLength(13, ErrorMessage = "ID Number cannot be longer than 13 characters.")]
        [Display(Name = "ID Number*")]
        public string Evaluator_ID_Number { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email address*")]
        public string Evaluator_Email { get; set; }

        [Display(Name = "Contact Number")]
        public string Evaluator_Contact_No { get; set; }

        [Display(Name = "Evaluator Type")]
        public string Evaluator_Type { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters long.")]
        [Display(Name = "Password*")]
        public string Evaluator_Password { get; set; }

        [Display(Name = "Evaluator Status")]
        public string Evaluator_Status { get; set; }

        public virtual ICollection<Interview> Interview { get; set; }
    }
}