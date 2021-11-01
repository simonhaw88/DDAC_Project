using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDAC_API.Models
{
    public class Customer
    {
        public Customer()
        {
            FirstName = null;
            LastName = null;
            ContactNo = 0;
            DateOfBirth = DateTime.Today;
            Gender = 0;
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
        public Address Address { get; set; }
    }
}
