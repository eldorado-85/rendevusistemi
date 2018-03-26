using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database.Data
{
    public class Appointments
    {
        public int Id { get; set; }
        public int EmployesId { get; set; }
        public int JobId { get; set; }
        public string Description { get; set; } 
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public virtual Emploies Emloiess { get; set; }
        public virtual List<Job> Jobs { get; set; }

    }
}