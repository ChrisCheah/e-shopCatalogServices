using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consul;
using e_shopCatalogServices.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestClientDotNet;

namespace e_shopCatalogServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private Func<IConsulClient> _consulClientFactory;

        public ValuesController(Func<IConsulClient> consulClientFactory)
        {
            _consulClientFactory = consulClientFactory;
        }        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            using (var client = _consulClientFactory())
            {
                var queryResult = await client.KV.List("CatalogApi");
                if (queryResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<string> finalResults = new List<string>();
                    foreach (var matchedPair in queryResult.Response)
                    {
                        finalResults.Add(Encoding.UTF8.GetString(matchedPair.Value, 0,
                            matchedPair.Value.Length));
                    }
                    return finalResults;
                }
                return new string[0];

            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            using (var client = _consulClientFactory())
            {
                var getPair = await client.KV.Get($"ConsulDemoApi-ID-{id.ToString()}");
                return Encoding.UTF8.GetString(getPair.Response.Value, 0,
                    getPair.Response.Value.Length);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
