using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDAC_Project.Models
{
    public class Album
    {
        public Album()
        {
            Tracks = new List<Track>();
            AlbumPhotos = new List<AlbumPhoto>();
        }
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Album's name is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Album's description is required")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Album's price is required")]
        [DisplayName("Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Album's quantity is required")]
        [DisplayName("Quantity")]
        public int Stock { get; set; }


        [Required(ErrorMessage = "Country of origin is required")]
        [DisplayName("Country of Origin")]
        public string CountryOfOrigin { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [DisplayName("Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Album's category is required")]
        [DisplayName("Category")]
        public int AlbumCategoryId { get; set; }
        public AlbumCategory albumCategory { get; set; }


        [Required(ErrorMessage = "Author is required")]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Album's photo is required")]
        [DisplayName("Image")]
        public IFormFile FormFile { get; set; }

        [DisplayName("Name")]
        public string[] TrackNames { get; set; }

        public List<Track> Tracks { get; set; }
        public List<AlbumPhoto> AlbumPhotos { get; set; }
        public CountryEnum CountryEnum { get; set; }

    }
}
