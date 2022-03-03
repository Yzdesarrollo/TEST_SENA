using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARGDriver.Server.Data;
using ARGDriver.Shared.Models.Services;

namespace ARGDriver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidencesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EvidencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Evidences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evidences>>> GetEvidences()
        {
            return await _context.Evidences.ToListAsync();
        }

        // GET: api/Evidences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evidences>> GetEvidences(int id)
        {
            var evidences = await _context.Evidences.FindAsync(id);

            if (evidences == null)
            {
                return NotFound();
            }

            return evidences;
        }

        // PUT: api/Evidences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvidences(int id, Evidences evidences)
        {
            if (id != evidences.Id)
            {
                return BadRequest();
            }

            _context.Entry(evidences).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvidencesExists(id))
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

        // POST: api/Evidences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evidences>> PostEvidences(Evidences evidences)
        {
            _context.Evidences.Add(evidences);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvidences", new { id = evidences.Id }, evidences);
        }

        // DELETE: api/Evidences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvidences(int id)
        {
            var evidences = await _context.Evidences.FindAsync(id);
            if (evidences == null)
            {
                return NotFound();
            }

            _context.Evidences.Remove(evidences);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvidencesExists(int id)
        {
            return _context.Evidences.Any(e => e.Id == id);
        }
    }
}
