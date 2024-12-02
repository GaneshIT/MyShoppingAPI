using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShoppingEntity;
using MyShoppingService.Services;

namespace MyShoppingAPI.Controllers
{
    [Route("api/[controller]")] //localhost:3000/api/Product/AddProduct
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetProducts")]
        public IActionResult GetAll()
        {
            var result = _productService.GetProducts();
            if(result.Count > 0) 
            return Ok(result); //200
            return NotFound(); //404
        }
        [HttpGet("GetProductById")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetProductById(id);
            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            object err = "Product name mus be passed..";
            if (product.Name == "")
                return BadRequest(err);//400
            _productService.AddProduct(product);

            Response response = new Response();
            response.statuscode = "200";
            response.result = "Product added successfully..";
            response.message = "Success";

            //object result = "Product added successfully..";
            return Ok(response);
        }
        [HttpPut("Update")]
        public IActionResult UpdateProduct([FromBody] Product product,int id)
        {
            _productService.UpdateProduct(product);
            object result = "Product updated successfully..";
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            object result = "Product deleted successfully..";
            return Ok(result);
        }
    }

    public class Response
    {
        public object result { get; set; }
        public string statuscode  { get; set; }
        public string message { get; set; }
    }
}
