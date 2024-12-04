using MyShoppingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingService.Services
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
    }
}
