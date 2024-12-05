using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Linq;
using MyShoppingEntity;
using MyShoppingRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //set dbcontext instance to make CRUD operation
        MyShoppingDbContext _context;
        ILogger<ProductRepository> _logger;
        public ProductRepository(MyShoppingDbContext dbcontext,ILogger<ProductRepository> logger)
        {
            //getting instance from container and assign to local variable
            _context = dbcontext;
            _logger = logger;
        }
        public async Task AddProduct(Product product)
        {
            //insert into products values(product.id,product,name,product.desc,product.price)
           await _context.Products.AddAsync(product);
            _context.SaveChanges();//execute the query
            _logger.LogInformation("Product added");
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
           Product product= _context.Products.Find(id);
            //delete from products where id=1
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        public async Task<Product> GetProductById(int id)
        {
            //select * from prodcuts where id=1
            Product obj =await _context.Products.FindAsync(id);
            return obj;
        }
        public async Task<List<Product>> GetAll()
        {
            //select * from products
            List<Product> list =await _context.Products.ToListAsync();
            return list;
        }
    }
}
