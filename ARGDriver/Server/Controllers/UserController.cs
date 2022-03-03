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
            var UserList = await _context.Users
                .Include(u => u.Rol)
                .AsNoTracking()
                .ToListAsync();

            return UserList;

        }

        // GET api/<UserController>/5 https://localhost:7072/api/User/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(user => user.Id == id);

            if (user == null)
                return BadRequest("No se encontro el registro");

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var role = await _context.Roles.FindAsync(rol.Id);
                    //if (role == null) return BadRequest();

                    await _context.AddAsync(user);
                    await _context.SaveChangesAsync();                  

                    return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
                }

                catch
                {
                    return BadRequest();
                }
            }

            return NotFound();
        }

        //// PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id || user == null)
            {
                return BadRequest();
            }

            var userUpdate= _context.Users
                .Include(u => u.Rol)
                //.ThenInclude(r => r.Name)
                .FirstOrDefault(u => u.Id == id);

            if (userUpdate == null)
                return NotFound();

            //_context.Entry(user).State = EntityState.Modified;

            userUpdate.Id = user.Id;
            userUpdate.Name = user.Name;
            userUpdate.Surname = user.Surname;
            userUpdate.DocumentType = user.DocumentType;
            userUpdate.Document = user.Document;
            userUpdate.Address = user.Address;
            userUpdate.RolId = user.RolId;
            userUpdate.Rol = user.Rol;
            userUpdate.Status = user.Status;           

            try
            {
                _context.Users.Update(userUpdate);
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
            //return Ok(userUpdate);
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
