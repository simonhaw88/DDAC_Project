using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }

        [DisplayName("Address Line")]
        [Required(ErrorMessage = "Address line is Required")]
        public string Line { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [DisplayName("Region")]
        [Required(ErrorMessage = "Region is Required")]
        public string Region { get; set; }

        [DisplayName("PostCode")]
        [Required(ErrorMessage = "PostCode is Required")]
        public int PostCode { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
}
