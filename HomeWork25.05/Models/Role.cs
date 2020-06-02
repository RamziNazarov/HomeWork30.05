using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeWork25._05
{
    public class Role
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "Role can not be empty")]
        public string RoleName {get;set;}

        public virtual ICollection<Customer> Customers {get;set;}
    }
}