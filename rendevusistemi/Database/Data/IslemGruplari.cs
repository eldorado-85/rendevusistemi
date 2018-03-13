using rendevusistemi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database
{
    public class IslemGruplari
    {
        public int Id { get; set; }
        public string GurupAdi { get; set; }
        public int IslemNo { get; set; }
        public virtual List<Islemler>  Islemlers {get;set;}
    }
}