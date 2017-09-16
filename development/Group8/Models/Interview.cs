using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group8.Models
{
    public class Interview
    {
        [Key]
        public int Interview_ID { get; set; }
        public int Evaluator_ID { get; set; }
        public int PGC_ID { get; set; }
        public DateTime Interview_Date { get; set; }
        public DateTime Interview_Time { get; set; }
        public string Interview_Venue { get; set; }
        public int Interview_Status { get; set; }
        public virtual Application Application { get; set; }
        public virtual Evaluator Evaluator { get; set; }
        public virtual PGC PGC { get; set; }

    }
}