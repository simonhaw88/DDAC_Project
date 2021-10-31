using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        public Album Album { get; set; }
 
    }
}
