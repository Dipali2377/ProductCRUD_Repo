using Microsoft.AspNetCore.Mvc;
using ProductCRUD.IServices;
using ProductCRUD.Models;
using ProductCRUD.RequestModels;

namespace ProductCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
   
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(ProductDto productDto)
        {
            // Assuming productDto contains all necessary data including Productid
            var product = new Product
            {
                Productid = productDto.Productid, // Manually set Productid
                Productname = productDto.Productname,
                Productdescription = productDto.Productdescription,
                Price = productDto.Price,
                Categoryid = productDto.Categoryid
            };

            // Check if the Productid already exists
            var existingProduct = await _productService.GetProductByIdAsync(productDto.Productid);
            if (existingProduct != null)
            {
                // Productid already exists, return a conflict response
                return Conflict("Productid already exists.");
            }

            var newProduct = await _productService.AddProductAsync(product);
            return newProduct; // Return the newProduct directly
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok(new { message = "Product deleted successfully" });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult< List<Product>>> GetProductsAsync()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, ProductDto productDto)
        {
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Productname = productDto.Productname;
            existingProduct.Productdescription = productDto.Productdescription;
            existingProduct.Price = productDto.Price;
            existingProduct.Categoryid = productDto.Categoryid;

            var updatedProduct = await _productService.UpdateProductAsync(id, existingProduct);
            return Ok(updatedProduct);
        }

    }
}
