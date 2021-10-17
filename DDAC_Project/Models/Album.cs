using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Album's name is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Album's description is required")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Album's price is required")]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Album's quantity is required")]
        [DisplayName("Quantity")]
        public int Stock { get; set; }


        [Required(ErrorMessage = "Country of origin is required")]
        [DisplayName("Country of Origin")]
        public string CountryOfOrigin { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [DisplayName("Release Date")]
        [DataType(DataType.Currency)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Album's category is required")]
        [DisplayName("Category")]
        public int AlbumCategoryId { get; set; }

        [Required(ErrorMessage = "Artist is required")]
        [DisplayName("Artist")]
        public string Artist { get; set; }

        [Required]
        [DisplayName("File")]
        public IFormFile FormFile { get; set; }

        public Track Track { get; set; }

        public CountryEnum CountryEnum { get; set; }
    }
}
