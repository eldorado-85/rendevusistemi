
using rendevusistemi.Database.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database
{
    public class MyDbContext:DbContext
    {
        internal object Login;

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Emploies> Employes { get; set; }
        public DbSet<Appointments> Appointmenties { get; set; }

        public DbSet <Login> Logins { get; set; }

    }
}