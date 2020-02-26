using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_crud.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "EnterName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Mobileno")]
        [Phone(ErrorMessage ="Enter Valid Phone no.")]
        public string Mobileno { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Birthdate")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Enter EmailID")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string EmailID { get; set; }

        public List<Customer> ShowallCustomer { get; set; }
    }
}