using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAAS.Models
{
    public class PGFO
    {
        [Key]
        [Display(Name = "PGFO ID")]
        public int PGFO_ID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name*")]
        public string PGFO_First_Name { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name*")]
        public string PGFO_Last_Name { get; set; }

        [Required(ErrorMessage = "Please enter your ID Number.")]
        [StringLength(13, ErrorMessage = "ID Number cannot be longer than 13 characters.")]
        [Display(Name = "ID Number*")]
        public string PGFO_ID_Number { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email address*")]
        public string PGFO_Email { get; set; }

        [Display(Name = "Contact Number")]
        public string PGFO_Contact_No { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters long.")]
        [Display(Name = "Password*")]
        public string PGFO_Password { get; set; }

        [Display(Name = "PGFO Status")]
        public string PGFO_Status { get; set; }

    }
}