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
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _productService.GetProducts();
                _logger.LogInformation("Get products exectued");
                if (result.Count > 0)
                    return Ok(result); //200

            }
            catch(Exception ex)
            {
                _logger.LogError("Get products not exectued:"+ex.Message);

            }
            return NotFound(); //404
        }
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _productService.GetProductById(id);
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




/*
 * class A
 * {
 * async void M1(){
 *         await service.Getusers(); -> db and fetch   12 sec
 * }
 * async void M2(){
 *        await  service.GetEmployees(); -> db and fetch   15 sec
 * }
 * async void M3(){
 *        await  service.GetProducts(); -> db and fetch    10sec
 * }
 * M1()
 * M2()
 * M3()
 * 
 * }
 *   Warining
 *   Error
 *   Info
 *   Debug
 *   
 * Log4Net
 * Serilog
 * NLog
 * 
 * 
 * 
 */