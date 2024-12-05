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
        public async Task AddProduct(Product product)
        {
           await _repository.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _repository.DeleteProduct(id);
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _repository.GetProductById(id);
            }
            catch(Exception ex)
            {
                // File logger
                //DB logger
                //Environment logger
                File.Create("MyLog.txt");
                StreamWriter sw = new StreamWriter("MyLog.txt");
                sw.WriteLine("*******************");
                sw.WriteLine("Date:" + DateTime.Now);
                sw.WriteLine("Message:" + ex.Message);
                sw.WriteLine("stack trac:" + ex.StackTrace);
                sw.WriteLine("*******************");
            }
            return null;
        }

        public async Task<List<Product>> GetProducts()
        {
           return await _repository.GetAll();
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }
    }
}
