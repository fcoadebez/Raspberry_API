using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interface_Mongo_Http;
using Mongo;

namespace Raspberry_API.Controllers
{
    [Route("api/products")]
    public class ValuesController : Controller
    {
        private readonly Interface _interface;

        public ValuesController(Interface @interface)
        {
            _interface = @interface;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _interface.GetProducts();
            return Ok(products);
        }

        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {
            var product = _interface.GetProduct(name);
            return Ok(product);
        }

        [HttpPost("add")]
        public IActionResult Create(Product p)
        {
            try
            {
                _interface.Create(p);
                return Created($"api/products/{p.Name}", p);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
