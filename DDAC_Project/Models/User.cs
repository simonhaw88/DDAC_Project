using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using Xamarin.Essentials;

namespace DDAC_Project.Models
{
    public class User
    {
        public User()
        {
            Status = 1;
        }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DisplayName("Email Address")]
        [Email] 
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "Role is Required")]
        public int Role { get; set; }

        [DisplayName("Security Question")]
        [Required(ErrorMessage = "Security answer is required")]
        public string SecurityAns { get; set; }

        public int Status { get; set; }

        public Staff Staff { get; set; }

        public Admin Admin { get; set; }

        public Customer Customer { get; set; }

        public UserEnum UserRole { get; set; }

    }

}
