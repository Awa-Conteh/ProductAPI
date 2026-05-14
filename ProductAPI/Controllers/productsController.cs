using Microsoft.AspNetCore.Mvc;
using ProductAPI.Model;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        public static List<Product> products = new List<Product>
        {
            new Product
            {
                ID = 1,
                Name = "Laptop",
                Price = 5000.0M,
                Quantity = 3
            },
            new Product {
                ID = 2,
                Name = "Microphone",
                Price = 1000.0M,
                Quantity = 5
            },
            new Product
            {
                ID = 3,
                Name = "Desk",
                Price = 700.0M,
                Quantity = 2
            },
            new Product
            {
                ID = 4,
                Name = "Speaker",
                Price = 500.0M,
                Quantity = 3,
            },
            new Product
            {
                ID = 5,
                Name = "Chair",
                Price = 300.0M,
                Quantity = 2
            }

        };

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductByID(int id)
        {
            var product = products.FirstOrDefault(x => x.ID == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(Product newProduct)
        {
            if (newProduct == null)
                return BadRequest();

            products.Add(newProduct);

            return CreatedAtAction(nameof(GetProductByID), new { id = newProduct.ID }, newProduct);

        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(x => x.ID == id);

            if (product == null)
                return NotFound();

            product.ID = updatedProduct.ID;
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.ID == id);

            if (product == null)
                return NotFound();

            products.Remove(product);

            return NoContent();
        }
    }
}
