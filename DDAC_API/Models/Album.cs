using System;
using System.Collections.Generic;
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
        public string CountryOfOrigin { get; set; }
        public DateTime ReleaseDate { get; set; }
        public AlbumCategory AlbumCategory { get; set; }
        public Artist Artist { get; set; }
    }
}
