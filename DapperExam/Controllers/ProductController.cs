using DapperExam.Interfaces;
using DapperExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _productRepository.GetAllProduct();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _productRepository.AddProduct(product);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveProduct(int id)
        {
            _productRepository.RemoveProduct(id);

            return Ok();
        }
    }
}
