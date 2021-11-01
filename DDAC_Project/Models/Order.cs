using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Payment Payment { get; set; }
    }
}
