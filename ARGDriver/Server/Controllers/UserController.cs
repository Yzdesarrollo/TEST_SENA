using ARGDriver.Server.Data;
using ARGDriver.Shared.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARGDriver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<UserController> https://localhost:7072/api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            //var UserList = await _context.Users.OrderBy(s => s.Name).ToListAsync();
            return await _context.Users.ToListAsync();

        }

        // GET api/<UserController>/5 https://localhost:7072/api/User/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            //var user2 = await _context.Users.Where(s => s.Id == id).FirstOrDefaultAsync();

            if (user == null)
                return BadRequest("No se encontro el registro");

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch
            {
                return BadRequest();
            }
        }

        //// PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            //var userExist = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Accepted();
        }

        //// DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Route("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Accepted();

        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(s => s.Id == id);
        }
    }
}
