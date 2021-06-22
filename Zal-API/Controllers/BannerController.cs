using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal_API.Models;

namespace Zal_API.Controllers
{
    [Route("api/[controller]")] // api/banner
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IHussarRepository<Banner> _hussarRepository;
        private readonly IHussarRepository<Hussar> _hussarRepository2;

        public BannerController(IHussarRepository<Banner> hussarRepository, IHussarRepository<Hussar> hussarRepository2)
        {
            _hussarRepository = hussarRepository;
            _hussarRepository2 = hussarRepository2;
        }

        [HttpPost]
        public async Task<IActionResult> AddBanner(Banner banner)
        {
            var createdBanner = await _hussarRepository.AddEntity(banner);
            return CreatedAtAction("GetBanner", new { id = createdBanner.ID }, createdBanner);
        }

        [HttpGet]
        public async Task<IActionResult> GetBanners()
        {
            return Ok(await _hussarRepository.GetAllEntities());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var banner = await _hussarRepository.GetEntity(id);
            if (banner == null)
            {
                return NotFound();
            }
            return Ok(banner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBanner(int id, Banner banner)
        {
            if (id != banner.ID)
            {
                return BadRequest();
            }
            var bannerToUpdate = await _hussarRepository.GetEntity(id);
            if (bannerToUpdate == null)
            {
                return NotFound();
            }
            return Ok(await _hussarRepository.EditEntity(banner));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var bannerToDelete = await _hussarRepository.GetEntity(id);
            if (bannerToDelete == null)
            {
                return NotFound();
            }
            var hussars = await _hussarRepository2.GetAllEntities();
            if(hussars.Any(hussar => hussar.BannerID == id))
            {
                return BadRequest("BannerHasHussars");
            }
            await _hussarRepository.DeleteEntity(bannerToDelete);
            return NoContent();
        }

        [HttpGet("getHussarsUnderBanner/{bannerid}")]
        public async Task<IActionResult> GetHussarsUnderBanner(int bannerid)
        {
            var bannerToCheck = await _hussarRepository.GetEntity(bannerid);
            if (bannerToCheck == null)
            {
                return NotFound();
            }
            var hussars = await _hussarRepository2.GetAllEntities();
            return Ok(hussars.Where(hussar => hussar.BannerID == bannerid).ToList());
        }
    }
}
