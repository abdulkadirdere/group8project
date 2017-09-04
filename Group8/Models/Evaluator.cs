using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group8.Models
{
    public class Evaluator
    {
        [Key]
        public int Evaluator_ID { get; set; }
        public string Evaluator_First_Name { get; set; }
        public string Evaluator_Last_Name { get; set; }
        public string Evaluator_ID_Number { get; set; }
        public string Evaluator_Email { get; set; }
        public string Evaluator_Contact_No { get; set; }
        public string Evaluator_Type { get; set; }
        public string Evaluator_Password { get; set; }
        public string Evaluator_Status { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }
        public virtual ICollection<Application> Application { get; set; }
    }
}