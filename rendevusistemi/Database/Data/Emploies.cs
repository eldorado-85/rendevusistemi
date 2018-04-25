using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database.Data
{
    public class Emploies
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression(@"[A-Z]{3,50}$",
         ErrorMessage = "Only uppercase Characters are allowed.")]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get { return string.Format("{0} {1}", Firstname, Lastname); } }
        public string Adress { get; set; }
       
       



    }
}