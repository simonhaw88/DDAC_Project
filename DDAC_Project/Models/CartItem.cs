using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class CartItem
    {
        public CartItem()
        {
            IsSelected = false;
        }

        public int CartItemId { get; set; }

        public int Quantity { get; set; }

        public Double Price { get; set; }


        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Boolean IsSelected { get; set; }


    }
}
