﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_Project.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
    }
}
