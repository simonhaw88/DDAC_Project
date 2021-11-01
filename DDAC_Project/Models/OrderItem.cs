using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        public Double Price { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
