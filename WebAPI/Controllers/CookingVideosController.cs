#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookingVideosController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CookingVideosController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CookingVideos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookingVideo>>> GetCookingVideos()
        {
            return await _context.CookingVideos.ToListAsync();
        }

        // GET: api/CookingVideos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookingVideo>> GetCookingVideo(int id)
        {
            var cookingVideo = await _context.CookingVideos.FindAsync(id);

            if (cookingVideo == null)
            {
                return NotFound();
            }

            return cookingVideo;
        }

        // PUT: api/CookingVideos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookingVideo(int id, CookingVideo cookingVideo)
        {
            if (id != cookingVideo.Id)
            {
                return BadRequest();
            }

            _context.Entry(cookingVideo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookingVideoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CookingVideos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CookingVideo>> PostCookingVideo(CookingVideo cookingVideo)
        {
            _context.CookingVideos.Add(cookingVideo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCookingVideo", new { id = cookingVideo.Id }, cookingVideo);
        }

        // DELETE: api/CookingVideos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookingVideo(int id)
        {
            var cookingVideo = await _context.CookingVideos.FindAsync(id);
            if (cookingVideo == null)
            {
                return NotFound();
            }

            _context.CookingVideos.Remove(cookingVideo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CookingVideoExists(int id)
        {
            return _context.CookingVideos.Any(e => e.Id == id);
        }
    }
}
