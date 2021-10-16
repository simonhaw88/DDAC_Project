using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public Album Album { get; set; }
    }
}
