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
        [Required(ErrorMessage = "Lütfen bir ad giriniz")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lütfen bir soyad giriniz")]
        public string Lastname { get; set; }
        public string Fullname { get { return string.Format("{0} {1}", Firstname, Lastname); } }
        public string Adress { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefon Numarası Giriniz")]
        public string Phone { get; set; }





    }
}