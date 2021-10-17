using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [DisplayName("Artist")]
        [Required(ErrorMessage = "Artist's name is required")]
        public string Name { get; set; }
    }
}
