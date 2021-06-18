using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Zal_API.Models;

namespace Zal_API.Controllers
{
    [Route("api/[controller]")] // api/hussar
    [ApiController]
    public class HussarController : ControllerBase
    {
        private readonly IHussarRepository _hussarRepository;

        public HussarController(IHussarRepository hussarRepository)
        {
            _hussarRepository = hussarRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddHussar(Hussar hussar)
        {
            var createdHussar = await _hussarRepository.AddHussar(hussar);
            return CreatedAtAction("GetHussar", new { id = createdHussar.ID }, createdHussar);
        }

        [HttpGet]
        public async Task<IActionResult> GetHussars()
        {
            return Ok(await _hussarRepository.GetAllHussars());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHussar(int id)
        {
            var hussar = await _hussarRepository.GetHussar(id);
            if(hussar == null)
            {
                return NotFound();
            }
            return Ok(hussar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHussar(int id, Hussar hussar)
        {
            if (id != hussar.ID)
            {
                return BadRequest();
            }
            var hussarToUpdate = await _hussarRepository.GetHussar(id);
            if (hussarToUpdate == null)
            {
                return NotFound();
            }
            return Ok(await _hussarRepository.EditHussar(hussar));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHussar(int id)
        {
            var hussarToDelete = await _hussarRepository.GetHussar(id);
            if (hussarToDelete == null)
            {
                return NotFound();
            }
            await _hussarRepository.DeleteHussar(hussarToDelete);
            return NoContent();
        }
    }
}
