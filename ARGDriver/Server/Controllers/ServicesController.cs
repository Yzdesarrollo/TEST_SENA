using ARGDriver.Server.Data;
using ARGDriver.Shared.Models.Services;
using ARGDriver.Shared.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARGDriver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ServicesController> https://localhost:7072/api/Rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetAll()
        {
            //var RolList = await _context.Roles.OrderBy(r => r.Name).ToListAsync();
            return await _context.Services.ToListAsync();

        }

        // GET api/<RolController>/5 https://localhost:7072/api/Rol/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetById(int id)
        {
            var service = await _context.Services.FindAsync(id);
            //var rol2 = await _context.Roles.Where(r => r.Id == id).FirstOrDefaultAsync();

            if (service == null)
                return BadRequest("No se encontro el registro");

            return service;
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            try
            {
                await _context.AddAsync(service);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
            }
            catch
            {
                return BadRequest();
            }
        }

        //// PUT api/<RolController>/5
        [HttpPut("{id}")]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Service service)
        {
            //var rolExist = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(service);
        }

        //// DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        [Route("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return Ok();

        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
