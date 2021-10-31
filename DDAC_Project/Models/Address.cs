using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDAC_Project.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Address's line is Required")]
        [DisplayName("Line")]
        public string Line { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Region is Required")]
        [DisplayName("Region")]
        public string Region { get; set; }

        [Required(ErrorMessage = "PostCode is Required")]
        [DisplayName("Post Code")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [DisplayName("Country")]
        public string Country { get; set; }

    }
}
