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
        public ProductRepository(MyShoppingDbContext dbcontext)
        {
            //getting instance from container and assign to local variable
            _context = dbcontext;
        }
        public void AddProduct(Product product)
        {
            //insert into products values(product.id,product,name,product.desc,product.price)
            _context.Products.Add(product);
            _context.SaveChanges();//execute the query
        }
        public void UpdateProduct(Product product)
        {

        }
        public void DeleteProduct(int id)
        {

        }
        public Product GetProductById(int id)
        {
            Product obj = new Product();
            return obj;
        }
        public List<Product> GetAll()
        {
            //select * from products
            List<Product> list = _context.Products.ToList();
            return list;
        }
    }
}
