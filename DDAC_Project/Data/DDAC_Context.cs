using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DDAC_Project.Models;

namespace DDAC_Project.Data
{
    public class DDAC_Context: DbContext
    {
        public DDAC_Context()
        {

        }
        public DDAC_Context(DbContextOptions<DDAC_Context> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AlbumCategory> AlbumCategorys { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
       
        public DbSet<AlbumPhoto> AlbumPhotos { get; set; }
      
        public DbSet<Track> Tracks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


        }

    }
}
