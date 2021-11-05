using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DDAC_API.Models;

namespace DDAC_API.Data
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
        public DbSet<AlbumCategory> AlbumCategorys { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumPhoto> AlbumPhotos { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AlbumCategory>().HasData(
               new AlbumCategory { AlbumCategoryId = 1, Name = "Jazz" },
               new AlbumCategory { AlbumCategoryId = 2, Name = "New Age" },
               new AlbumCategory { AlbumCategoryId = 3, Name = "Pop" },
               new AlbumCategory { AlbumCategoryId = 4, Name = "Punk & Hardcore" },
               new AlbumCategory { AlbumCategoryId = 5, Name = "R&B" },
               new AlbumCategory { AlbumCategoryId = 6, Name = "Reggae" },
               new AlbumCategory { AlbumCategoryId = 7, Name = "Soundtracks" },
               new AlbumCategory { AlbumCategoryId = 8, Name = "Urban" },
               new AlbumCategory { AlbumCategoryId = 9, Name = "Vinyl" },
               new AlbumCategory { AlbumCategoryId = 10, Name = "World Music" }
               );
            modelBuilder.Entity<Address>().HasData(
               new Address()
              {
                  AddressId = 1,
                  Line = "B-1-19，Desa Gembira Condo No. 6，Jalan 1 / 127A Off Jalan Kuchai Lama，58200 Kuala Lumpur",
                  City = "Kuala Lumpur",
                  Region = "Asia",
                  PostCode = 58200,
                  Country = "Malaysia"
              });

          modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Email = "admin@gmail.com",
                    Password = "1292201552198220877194054219216496220885",
                    Role = 3,
                    SecurityAns = "apple",
                    Status = 1,
                });
            modelBuilder.Entity<Admin>().HasData(
              new Admin()
              {
                  AdminId = 1,
                  FirstName = "simon",
                  LastName = "Haw",
                  ContactNo = 01699885450,
                  DateOfBirth = DateTime.Today,
                  Gender = 1,
                  UserId = 1,
                  AddressId = 1,

              });
        }


    }
}
