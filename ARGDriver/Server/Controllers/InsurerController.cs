using ARGDriver.Server.Data;
using ARGDriver.Shared.Models.Insurance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARGDriver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InsurerController(ApplicationDbContext context)
        {
            _context = context;
        }

                [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurer>>> GetAll()
        {
            //var InsurerList = await _context.Insurers.OrderBy(i => i.Name).ToListAsync();
            return await _context.Insurers.ToListAsync();

        }

               [HttpGet("{id}")]
        public async Task<ActionResult<Insurer>> GetById(int id)
        {
            var insurer = await _context.Insurers.FindAsync(id);
            //var insurer2 = await _context.Insurers.Where(i => i.Id == id).FirstOrDefaultAsync();

            if (insurer == null)
                return BadRequest("No se encontro el registro");

            return insurer;
        }

                [HttpPost]
        public async Task<IActionResult> Create(Insurer insurer)
        {
            try
            {
                await _context.AddAsync(insurer);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = insurer.Id }, insurer);
            }
            catch
            {
                return BadRequest();
            }
        }

      
        [HttpPut("{id}")]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Insurer insurer)
        {
            //var insurerExist = await _context.Insurers.FirstOrDefaultAsync(r => r.Id == id);
            if (id != insurer.Id)
            {
                return BadRequest();
            }

            _context.Entry(insurer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsurerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(insurer);
        }

        
        [HttpDelete("{id}")]
        [Route("{id}")]
        public async Task<ActionResult<Insurer>> Delete(int id)
        {
            var insurer = await _context.Insurers.FindAsync(id);
            if (insurer == null)
            {
                return NotFound();
            }

            _context.Insurers.Remove(insurer);
            await _context.SaveChangesAsync();

            return Ok();

        }

        private bool InsurerExists(int id)
        {
            return _context.Insurers.Any(e => e.Id == id);
        }
    }
}
    






