using Microsoft.EntityFrameworkCore;
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
           :base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
