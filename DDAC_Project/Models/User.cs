using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DDAC_Project.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        [Remote("IsEmailExist", "Auth", ErrorMessage = "Email Already Exist. Please choose another email.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "Role is Required")]
        public int Role { get; set; }
        public UserEnum UserRole { get; set; }      
    }
   
}
