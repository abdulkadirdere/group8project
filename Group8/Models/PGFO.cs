using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group8.Models
{
    public class PGFO
    {
        [Key]
        public int PGFO_ID { get; set; }
        public string PGFO_First_Name { get; set; }
        public string PGFO_Last_Name { get; set; }
        public string PGFO_ID_Number { get; set; }
        public string PGFO_Email { get; set; }
        public string PGFO_Contact_No { get; set; }
        public string PGFO_Password { get; set; }
        public string PGFO_Status { get; set; }
        public virtual ICollection<Application> Application { get; set; }
    }
}