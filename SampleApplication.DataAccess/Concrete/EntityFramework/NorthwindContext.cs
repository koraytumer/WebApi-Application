using Microsoft.EntityFrameworkCore;
using SampleApplication.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApplication.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        //public NorthwindContext(DbContextOptions<NorthwindContext>options):base(options)
        //{ 
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BK7H63U;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; } 
    }
}