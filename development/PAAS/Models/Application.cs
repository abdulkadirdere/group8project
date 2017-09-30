using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAAS.Models
{
    public class Application
    {
        [Key]
        [Display(Name = "Application ID")]
        public int Application_ID { get; set; }

        [Required(ErrorMessage = "Please enter your student number.")]
        [StringLength(50, ErrorMessage = "Student number cannot be longer than 50 characters.")]
        [Display(Name = "Student Number*")]
        public string Student_No { get; set; }

        [Display(Name = "Application Status")]
        public string Application_Status { get; set; }

        [Display(Name = "Recommendation Description")]
        public string Application_Recommend_Desc { get; set; }

        [Display(Name = "Final Decision Description")]
        public string Application_Decision_Desc { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name*")]
        public string Applicant_First_Name { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name*")]
        public string Applicant_Last_Name { get; set; }

        [Required(ErrorMessage = "Please enter your ID Number.")]
        [StringLength(13, ErrorMessage = "ID Number cannot be longer than 13 characters.")]
        [Display(Name = "ID Number*")]
        public string Applicant_ID_Number { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email address*")]
        public string Applicant_Email { get; set; }

        [Display(Name = "Contact Number")]
        public string Applicant_Contact_No { get; set; }

        [Required(ErrorMessage = "Please enter the school name of application.")]
        [StringLength(50, ErrorMessage = "School name cannot be longer than 50 characters.")]
        [Display(Name = "School*")]
        public string Applicant_School { get; set; }

        [Required(ErrorMessage = "Please enter the faculty name of application.")]
        [StringLength(50, ErrorMessage = "Faculty name cannot be longer than 50 characters.")]
        [Display(Name = "Faculty*")]
        public string Applicant_Faculty { get; set; }

        [Required(ErrorMessage = "Please enter postal address street number.")]
        [StringLength(50, ErrorMessage = "Street number cannot be longer than 50 characters.")]
        [Display(Name = "Street Number*")]
        public string Applicant_Street_No { get; set; }

        [Required(ErrorMessage = "Please enter postal address street name.")]
        [StringLength(50, ErrorMessage = "Street name cannot be longer than 50 characters.")]
        [Display(Name = "Street Name*")]
        public string Applicant_Street_Name { get; set; }

        [Required(ErrorMessage = "Please enter postal address suburb.")]
        [StringLength(50, ErrorMessage = "Suburb cannot be longer than 50 characters.")]
        [Display(Name = "Suburb*")]
        public string Applicant_Suburb { get; set; }

        [Required(ErrorMessage = "Please enter postal address city.")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        [Display(Name = "City*")]
        public string Applicant_City { get; set; }

        [Required(ErrorMessage = "Please enter Province.")]
        [StringLength(50, ErrorMessage = "Province cannot be longer than 25 characters.")]
        [Display(Name = "Province*")]
        public string Applicant_Province { get; set; }

        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Interview> Interview { get; set; }
    }
}