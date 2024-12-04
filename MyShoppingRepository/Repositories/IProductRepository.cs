using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShoppingEntity;

namespace MyShoppingRepository.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAll();


    }
}
