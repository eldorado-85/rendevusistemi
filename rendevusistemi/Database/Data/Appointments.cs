using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database.Data
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }
       
        public int JobId { get; set; }
        public string Description { get; set; } 
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public int EmployeId { get; set; }

      




    }
}