using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interface_Mongo_Http;
using Raspberry_API.Models;

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
        public IActionResult Create([FromBody]Product p)
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

        [HttpPost("update/{name}")]
        public IActionResult Create(string name, Product p)
        {
            try
            {
                _interface.Update(name, p);
                return Created($"api/products/{p.Name}", p);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("remove/{name}")]
        public IActionResult Remove(string name)
        {
            try
            {
                _interface.Remove(name);
                return Ok("Removed");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}