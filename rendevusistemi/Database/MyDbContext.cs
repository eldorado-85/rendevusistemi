using rendevusistemi.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database
{
    public class MyDbContext:DbContext
    {


        public DbSet<Kisiler> Kisilers { get; set; }
        public DbSet<IslemGruplari> IslemGruplaris { get; set; }
        public DbSet <Islemler> Islemlers { get; set; }
    }
}