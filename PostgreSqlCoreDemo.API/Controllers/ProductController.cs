using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresqlCoreDemo.Entity.Entities;
using PostgreSqlCoreDemo.Business.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgreSqlCoreDemo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductHandler productHandler;
        public ProductController()
        {
            productHandler = new ProductHandler();
        }
        // GET: api/<Product>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //return new string[] { "value1", "value2" };
            return productHandler.GetProducts();
        }

        // GET api/<Product>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Product>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                productHandler.AddProduct(product);
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // PUT api/<Product>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Product>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
