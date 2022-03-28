using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EcommerceContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FashionEcommerce;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //modelbuilder.Entity<AnonimMusteriler>().HasBaseType<Kullanicilar>();
            // modelbuilder.Entity<AnonimMusteriler>().HasKey(am => am.KullaniciId);
            // modelbuilder.Entity<AnonimMusteriler>().HasOne(am => am.Kullanicilar).WithOne(k => k.AnonimMusteriler).HasForeignKey<AnonimMusteriler>(am => am.KullaniciId);


            //modelbuilder.Entity<Kullanicilar>().HasOne(p => p.AnonimMusteriler).WithOne(s => s.Kullanicilar).HasForeignKey<AnonimMusteriler>(e => e.KullaniciId);
            //modelbuilder.Entity<AnonimMusteriler>().HasKey(s => s.KullaniciId);          
            // modelbuilder.Entity<AnonimMusteriler>().HasOne(p => p.Kullanicilar).WithOne(s => s.AnonimMusteriler).HasForeignKey<Kullanicilar>(e => e.KullaniciId);
            // modelbuilder.Entity<Kullanicilar>().HasOne<AnonimMusteriler>(p => p.AnonimMusteriler).WithOne(s => s.Kullanicilar);
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Color>? Colors { get; set; }
        public DbSet<Size>? Sizes { get; set; }
        public DbSet<Gender>? Genders { get; set; }
        public DbSet<Fit>? Fits { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<City>? Cities { get; set; }
    }
}
