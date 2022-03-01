using ARGDriver.Server.Data;
using ARGDriver.Shared.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARGDriver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<RolController> https://localhost:7072/api/Rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetAll()
        {
            //var RolList = await _context.Roles.OrderBy(r => r.Name).ToListAsync();
            return await _context.Roles.ToListAsync();

        }

        // GET api/<RolController>/5 https://localhost:7072/api/Rol/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetById(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            //var rol2 = await _context.Roles.Where(r => r.Id == id).FirstOrDefaultAsync();

            if (rol == null)
                return BadRequest("No se encontro el registro");

            return rol;
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<IActionResult> Create(Rol rol)
        {
            try
            {
                await _context.AddAsync(rol);
                await _context.SaveChangesAsync();
                
                return CreatedAtAction(nameof(GetById), new { id = rol.Id }, rol);
            }
           catch
            {
                return BadRequest();
            }      
        }

        //// PUT api/<RolController>/5
        [HttpPut("{id}")]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Rol rol)
        {
            //var rolExist = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (id != rol.Id)
            {
                return BadRequest();
            }

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(rol);
        }

        //// DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        [Route("{id}")]
        public async Task<ActionResult<Rol>> Delete(int id)
         {
            var rol = await _context.Roles.FindAsync(id);
            if(rol == null)
            {
                return NotFound();
            }
        
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();

            return Ok();
       
        }

        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
