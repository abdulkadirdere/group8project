using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group8.Models
{
    public class Application
    {
        [Key]
        public int Application_ID { get; set; }
        public int PGO_ID { get; set; }
        public int PGFO_ID { get; set; }
        public int PGC_ID { get; set; }
        public int Evaluator_ID { get; set; }
        public int Student_No { get; set; }
        public string Application_Status { get; set; }
        public string Applicant_First_Name { get; set; }
        public string Applicant_Last_Name { get; set; }
        public string Applicant_ID_Number { get; set; }
        public string Applicant_Email { get; set; }
        public string Applicant_Contact_No { get; set; }
        public string Applicant_School { get; set; }
        public string Applicant_Faculty { get; set; }
        public int Applicant_Street_No { get; set; }
        public string Applicant_Street_Name { get; set; }
        public string Applicant_Suburb { get; set; }
        public string Applicant_City { get; set; }
        public string Applicant_Province { get; set; }

        public virtual PGC PGC { get; set; }
        public virtual Evaluator Evaluator { get; set; }
        public virtual PGFO PGFO { get; set; }
        public virtual PGO PGO { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }

    }
}