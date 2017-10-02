using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAAS.Models
{
    public class Document
    {
        [Key]
        [Display(Name = "Document ID")]
        public int Document_ID { get; set; }

        [Display(Name = "Application ID")]
        public int Application_ID { get; set; }

        [Required(ErrorMessage = "Please enter a document name.")]
        [StringLength(50, ErrorMessage = "Document name cannot be longer than 50 characters.")]
        [Display(Name = "Document Name*")]
        public string Document_Name { get; set; }

        [Display(Name = "Document Type")]
        public string Document_Type { get; set; }
        
        [Required(ErrorMessage = "Please upload a document in .PDF format")]
        [DataType(DataType.Upload)]
        [Display(Name = "Select File")]
        public byte[] Document_File { get; set; }
    

    public virtual Application Application { get; set; }
    }

}


