
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeWork25._05
{
    public class Pokupka
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId {get;set;}
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime Date {get;set;}

        public virtual Customer Customers {get;set;}
    }
}