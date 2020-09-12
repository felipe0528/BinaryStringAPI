using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaryStringAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BinaryStringAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryStringsController : ControllerBase
    {
        private readonly IBinaryStringRepository _binaryRepository;

        public BinaryStringsController(IBinaryStringRepository binaryRepository)
        {
            _binaryRepository = binaryRepository;
        }

        // GET: api/<BinaryStringsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BinaryStringsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BinaryStringsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BinaryStringsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BinaryStringsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
