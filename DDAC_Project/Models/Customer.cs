using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace DDAC_Project.Models
{
    public class Customer
    {
        public Customer()
        {
            FirstName = null;
            LastName = null;
            ContactNo = 0;
            DateOfBirth = DateTime.ParseExact("1999-11-11", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Gender = 1;
        }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
