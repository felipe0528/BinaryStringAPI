using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaryStringAPI.Models;
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
        public async Task<IActionResult> GetAsync()
        {
            return new ObjectResult(await _binaryRepository.GetAllBinaryStrings());
        }

        // GET api/<BinaryStringsController>/{name}
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var binary = await _binaryRepository.GetBinaryString(name);

            if (binary == null)
                return new NotFoundResult();

            return new ObjectResult(binary);
        }

        // POST api/<BinaryStringsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BinaryString binary)
        {
            await _binaryRepository.Create(binary);
            return new OkObjectResult(binary);
        }

        // PUT api/<BinaryStringsController>/{name}
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] BinaryString binary)
        {
            var binaryFromDb = await _binaryRepository.GetBinaryString(name);

            if (binaryFromDb == null)
                return new NotFoundResult();

            binary.Id = binaryFromDb.Id;

            await _binaryRepository.Update(binary);

            return new OkObjectResult(binary);
        }

        // DELETE api/<BinaryStringsController>/{name}
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var binaryFromDb = await _binaryRepository.GetBinaryString(name);

            if (binaryFromDb == null)
                return new NotFoundResult();

            await _binaryRepository.Delete(name);

            return new OkResult();
        }
    }
}
