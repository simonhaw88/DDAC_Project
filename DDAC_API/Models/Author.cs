using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
