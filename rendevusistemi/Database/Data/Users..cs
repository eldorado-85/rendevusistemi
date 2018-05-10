using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rendevusistemi.Database.Data
{
    public class User 
    {    [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string FirstName { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string LastName{ get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}