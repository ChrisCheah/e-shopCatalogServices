using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_shoporderservices.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace e_shoporderservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase    {

        private DataAccess _dataAccess;
        public OrderController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        // GET: api/Game
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(_dataAccess.GetOrders());
        }
        // GET: api/Order/id
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(ObjectId id)
        {
            var order =  _dataAccess.GetOrder(id);
            if (order == null)
                return new NotFoundResult();
            return new ObjectResult(order);
        }
        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            _dataAccess.Create(order);
            return new OkObjectResult(order);
        }
        
    }
}