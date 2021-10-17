using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string CountryOfOrigin { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AlbumCategoryId { get; set; }

        public AlbumCategory AlbumCategory { get; set; }

        public string Artist { get; set; }

        public List<Track> Tracks { get; set; }

        public List<AlbumPhoto> AlbumPhotos { get; set; }
    }
}
