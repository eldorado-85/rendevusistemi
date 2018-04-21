using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database.Data
{
    public class Appointments
    {
        public int Id { get; set; }
       
        public int JobId { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeEnd { get; set; }
        public int EmployeId { get; set; }
    



    }
}