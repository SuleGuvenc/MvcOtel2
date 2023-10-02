using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Otel.Entitiy.Concrete;
using Otel.Entity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL.Contents
{
    public class SqlDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Menu> Menuler { get; set; }


        public SqlDbContext()
        {

        }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MssqlLocaldb;Database=OtelMvc;Trusted_Connection=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Burasi Calisan Assembly icersinde ITypeEntityConfig interface'inden kalitim almis ne kadar class varsa 
            // onun icerisindeki Configure metodunu cagirir.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
