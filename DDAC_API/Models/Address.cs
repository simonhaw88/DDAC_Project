using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Models
{
    public class Address
    {
        public Address()
        {
            Line = null;
            City = null;
            Region = null;
            PostCode = 00000;
            Country = null;
        }
        public int AddressId { get; set; }
        public string Line { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PostCode { get; set; }
        public string Country { get; set; }

    }
}
