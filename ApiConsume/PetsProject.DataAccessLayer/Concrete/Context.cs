using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser , AppRole ,int> //int girdiğimiz key(<int>) değerlerinin nedeni :
                                                                      //identity kütüphanesinde idler string formatta geliyor ben int olmasını istiyorum.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-IV1U5H1\\SQLEXPRESS; initial catalog = PetDb; " +
                "integrated security=true");
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Pets> Petss { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopProcess> ShopProcesies { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ClientLogo> ClientLogos { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
