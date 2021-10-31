using System.ComponentModel.DataAnnotations.Schema;

namespace DDAC_API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public string DateOfBirth { get; set; }
        public int Gender { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
}
