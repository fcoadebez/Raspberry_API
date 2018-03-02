using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interface_Mongo_Http;

namespace Raspberry_API.Controllers
{
    [Route("api/")]
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
            var toto = _interface.GetProducts();
            return Ok(toto);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {

            return Ok("product");
        }

       
    }
}
