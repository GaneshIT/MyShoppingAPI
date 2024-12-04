using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyShoppingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingRepository.Data
{
    
    public class MyShoppingDbContext:DbContext
    {

        public MyShoppingDbContext(DbContextOptions<MyShoppingDbContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        //public DbSet<Customer> Customers { get; set; }
    }
}

//http://localhost:5198/api/Product/Create
