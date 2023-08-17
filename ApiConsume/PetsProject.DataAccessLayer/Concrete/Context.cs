using Microsoft.EntityFrameworkCore;
using PetsProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-IV1U5H1\\SQLEXPRESS; initial catalog = PetsDb; " +
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
    }
}
