using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace DDAC_Project.Models
{
    public class Staff
    {
        public Staff()
        {
            FirstName = null;
            LastName = null;
            ContactNo = 0;
            DateOfBirth = DateTime.ParseExact("1999-11-11", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Gender = 1;
        }
        public int StaffId { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is Required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Contact no is Required")]
        [DisplayName("Contact No")]
        [DataType(DataType.PhoneNumber)]
        public int ContactNo { get; set; }

        [Required(ErrorMessage = "Date of birth is Required")]
        [DisplayName("Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [DisplayName("Gender")]
        public int Gender { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
