using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database.Data
{
    public class Emploies
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public DateTime DateTime { get; set; }
    
        

    }
}