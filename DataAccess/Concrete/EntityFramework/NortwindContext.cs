using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje class'larını bağlama
    public class NortwindContext:DbContext
    {

        //override on yazıp ilk satırdaki seçeneği seçiyoruz ve bu yapıyı oluştutuyor.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local)\SQL2014;Database=Northwind;Trusted_Connection=true"); //SQL Server bağlantısı
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
