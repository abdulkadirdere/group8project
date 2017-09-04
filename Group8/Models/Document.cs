using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group8.Models
{
    public class Document
    {
        [Key]
        public int Document_ID { get; set; }
        public int Application_ID { get; set; }
        public int Student_No { get; set; }
        public string Document_Name { get; set; }
        public string Document_Status { get; set; }
        public virtual Application Application { get; set; }
    }
}