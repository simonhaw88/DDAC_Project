using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Column(TypeName = "Date")]

        public DateTime CreatedDate { get; set; }

        public int Status { get; set; }
        public string Line { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PostCode { get; set; }
        public string Country { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
}
