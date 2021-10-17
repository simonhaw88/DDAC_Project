using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class AlbumPhoto
    {
        public int AlbumPhotoId { get; set; }
        public string Name { get; set; }

         public int AlbumId{ get; set; }

        public Album Album { get; set; }
    }
}
