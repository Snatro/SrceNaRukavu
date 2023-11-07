using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SrceNaRukavu.Application.People.Models;
using SrceNaRukavu.Application.Products;
using SrceNaRukavu.Application.Products.Models;

namespace SrceNaRukavu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = nameof(GetProducts))]
        public async Task<IReadOnlyList<ProductDTO>> GetProducts(CancellationToken token)
        {
            return await _productService.GetProducts(token);
        }
        [HttpGet("{id}", Name = nameof(GetProductById))]
        public async Task<IActionResult> GetProductById([FromRoute] int id, CancellationToken token)
        {
            ProductDTO product = await _productService.GetProductById(id, token);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost(Name = nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO product, CancellationToken token)
        {
            await _productService.CreateProduct(product, token);
            return Ok();
        }

        [HttpPut(Name = nameof(UpdateProduct))]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO product, CancellationToken token)
        {
            await _productService.UpdateProduct(product, token);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteProduct))]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id, CancellationToken token)
        {
            bool deleted = await _productService.DeleteProduct(id, token);
            return deleted ? Ok() : NotFound();
        }
    }

}
