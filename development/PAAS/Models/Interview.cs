using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PAAS.Models
{
    public class Interview
    {
        [Key]
        [Display(Name = "Interview ID")]
        public int Interview_ID { get; set; }

        [Display(Name = "Evaluator ID")]
        public int Evaluator_ID { get; set; }

        [Display(Name = "Application ID")]
        public int Application_ID { get; set; }

        [Required(ErrorMessage = "Please enter a date.")]
        [Display(Name = "Interview Date*")]
        [DataType(DataType.Date)]
        public DateTime Interview_Date { get; set; }

        [Required(ErrorMessage = "Please enter a time.")]
        [Display(Name = "Interview Time*")]
        [DataType(DataType.Time)]
        public DateTime Interview_Time { get; set; }

        [Required(ErrorMessage = "Please enter a venue.")]
        [StringLength(50, ErrorMessage = "Venue cannot be longer than 50 characters.")]
        [Display(Name = "Venue*")]
        public string Interview_Venue { get; set; }

        [Display(Name = "Interview Status")]
        public string Interview_Status { get; set; }

        public virtual Application Application { get; set; }
        public virtual Evaluator Evaluator { get; set; }
    }
}