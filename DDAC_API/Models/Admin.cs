using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Models
{
    public class Admin
    {
        public Admin()
        {
            FirstName = null;
            LastName = null;
            ContactNo = 0;
            DateOfBirth = DateTime.Today;
            Gender = 0;
        }
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Address")]
        public int AddressId{ get; set; }
        public Address Address { get; set; }
    }
}
