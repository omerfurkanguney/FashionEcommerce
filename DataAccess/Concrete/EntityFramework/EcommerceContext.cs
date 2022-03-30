using Core.Entities.Concrete;
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
            modelbuilder.Entity<Customer>().ToTable("customers");

            //modelbuilder.Entity<Customer>().HasBaseType<User>();
            //modelbuilder.Entity<User>().HasDiscriminator<string>("user_type").HasValue<User>("blog_base").HasValue<Customer>("user_customer");
            //modelbuilder.Entity<Customer>().HasKey(c => c.UserId);

            //modelbuilder.Entity<Customer>().HasOne(c => c.user).WithOne(a => a.customer).HasForeignKey<Customer>(c => c.UserId);
            //modelbuilder.Entity<User>().HasOne(u => u.customer).WithOne(c=>c.user).HasForeignKey<User>(u => u.UserId);

          
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Color>? Colors { get; set; }
        public DbSet<Size>? Sizes { get; set; }
        public DbSet<Gender>? Genders { get; set; }
        public DbSet<Fit>? Fits { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<County>? Counties { get; set; }
        public DbSet<SubCategory>? SubCategories { get; set; }
        public DbSet<BaseProduct>? BaseProducts { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Stock>? Stocks { get; set; }
        public DbSet<AdminOperationClaim>? AdminOperationClaims { get; set; }
        public DbSet<AdminClaim>? AdminClaims { get; set; }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<User>? Users { get; set; }
        //public DbSet<Customer>? Customers { get; set; }
    }
}
