using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShoppingEntity;
using MyShoppingService.Services;

namespace MyShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.AddProduct(product);
            object result = "Product added successfully..";
            return Ok(result);
        }
    }
}
