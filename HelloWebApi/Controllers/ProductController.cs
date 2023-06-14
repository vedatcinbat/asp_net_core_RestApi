using HelloWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {

        List<Product> allProducts = new List<Product>() {
                new Product() {Id = 1,ProductName = "Product A", ProductDescription = "This is product a", Price = 1000},
                new Product() {Id = 2,ProductName = "Product B", ProductDescription = "This is product b", Price = 2000},
                new Product() {Id = 3,ProductName = "Product C", ProductDescription = "This is product c", Price = 3000},
        };

        [HttpGet("api/products")]
        public IActionResult getproducts()
        {
            return Ok(allProducts);
        }

        [HttpGet("api/products/{id}")]
        public IActionResult getproducts(int id)
        {
            bool idExists = allProducts.Any(i => i.Id == id);

            if (idExists)
            {
                var product = allProducts.Find(i => i.Id == id);
                return Ok(product);
            }else{
                return BadRequest($"Id -{id}- didn't found !");
            }


        }

        [HttpPost("api/products")]
        public IActionResult postproduct(Product product)
        {
            allProducts.Add(product);
            return Ok(allProducts);
        }

        [HttpDelete("api/products/{id}")]
        public IActionResult deleteproduct(int id)
        {

            bool idExists = allProducts.Any(i => i.Id == id);
            if (idExists)
            {
                Console.WriteLine($"ProductId{id} Has Deleted !");
                var product = allProducts.Find(i => i.Id == id);
                allProducts.Remove(product);
                return Ok(allProducts);
            }
            else
            {
                return BadRequest("There is no such id");
            }



        }
    }
}