using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeWork25._05
{
    public class Customer
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "Login can not be empty")]
        public string Login {get;set;}
        [Required(ErrorMessage = "Password can not be empty")]
        public string Password {get;set;}
        public int PhoneNumber {get;set;}
        public string Adress {get;set;}
        [Required(ErrorMessage = "Role can not be empty")]
        public int RoleId {get;set;}


        public virtual ICollection<Pokupka> Pokupki {get;set;}
        public virtual Role roles {get;set;}
    }
}