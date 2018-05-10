using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database.Data
{
    public class ViewModel
    {

        public IEnumerable <Appointments> randevular { get; set; }
        public IEnumerable <Emploies> müsteriler { get; set; }

        public IEnumerable<Job> operasyonlar { get; set; }
        public IEnumerable<User> kullanicilar { get; set; }
    }
}