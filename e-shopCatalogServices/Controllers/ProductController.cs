using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_shopCatalogServices.Models;
using e_shopCatalogServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_shopCatalogServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        //api/Product
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetaAll();
        }

        //api/Product/{id}
        [HttpGet("{id}")]
        public Product GetProductById(long id)
        {
            return _repo.GetProductById(id);
        }

        [HttpPost]
        public CreatedAtActionResult SaveProduct([FromBody] Product product)
        {
          
            _repo.SaveProduct(product);

            return CreatedAtAction("GetProductById", new { id = product.ProductId }, product);

        }
    }
}