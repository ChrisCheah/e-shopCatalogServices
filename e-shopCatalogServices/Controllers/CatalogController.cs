using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_shopCatalogServices.Models;
using e_shopCatalogServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//http://localhost:9001/api/Catalog
namespace e_shopCatalogServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ICatalogRepository _repo;

        public CatalogController(ICatalogRepository repo)
        {
            _repo = repo;
        }
        //api/Catalog
        [HttpGet]
        public IEnumerable<Catalog> GetCatalogs()
        {
            return _repo.GetaAll();
        }

        //api/Catalog/{id}
        [HttpGet("{id}")]
        public Catalog GetCatalogById(long id)
        {
            return _repo.GetCatalogById(id);
        }

        [HttpPost]
        public CreatedAtActionResult SaveCatalog([FromBody] Catalog catalog)
        {
            
            _repo.SaveCatalog(catalog);        

            return CreatedAtAction("GetCatalogById", new { id = catalog.CatalogId }, catalog);

        }
    }
}