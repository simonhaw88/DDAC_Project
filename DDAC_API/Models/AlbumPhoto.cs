using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Models
{
    public class AlbumPhoto
    {
        public int AlbumPhotoId { get; set; }
        public string Name { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
