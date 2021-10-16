using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public string DateOfBirth { get; set; }
        public int Gender { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
}
