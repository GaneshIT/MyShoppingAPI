using MyShoppingEntity;
using MyShoppingRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingService.Services
{
    interface IA
    {
        void add();
    }
    class MyClass : IA
    {
        public void add()
        {
        }
    }
    public class mainclass
    {
        void Call() {    IA obj=new MyClass();         }
    }
    public class ProductService : IProductService
    {
        IProductRepository _repository;
        public ProductService(IProductRepository productRepository) 
        {
            _repository = productRepository;
        }
        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
        }

        public List<Product> GetProducts()
        {
           return _repository.GetAll();
        }
    }
}
