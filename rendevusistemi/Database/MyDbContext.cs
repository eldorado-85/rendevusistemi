
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


        public DbSet<Job> Jobs { get; set; }
        public DbSet<Emploies> Employes { get; set; }
        
    }
}