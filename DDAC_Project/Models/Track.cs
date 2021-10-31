using System.ComponentModel.DataAnnotations.Schema;

namespace DDAC_Project.Models
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
