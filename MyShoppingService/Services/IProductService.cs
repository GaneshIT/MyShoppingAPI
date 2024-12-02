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
        void AddProduct(Product product);
        List<Product> GetProducts();
        Product GetProductById(int id);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
    }
}
