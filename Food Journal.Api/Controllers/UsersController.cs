using Food_Journal.Api.Helpers;
using Food_Journal.DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Journal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        // POST: api/Users/login?username=blah&password=blah
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromHeader]string username, [FromHeader]string password)
        {
            if (string.IsNullOrWhiteSpace(username)
                || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest();
            }

            var user = await _context.Users.FirstOrDefaultAsync(
                    u => u.Username.Equals(
                             username, StringComparison.OrdinalIgnoreCase)
                          && u.Password == password);

            if (user == null)
            {
                return NotFound();
            }

            user.LastLoggedIn = DateTimeOffset.Now;
            _context.SaveChanges();

            return Ok(user.ToPartial());
        }

        // GET: api/Users/check_username
        [HttpGet("check_username")]
        public async Task<IActionResult> CheckUsername([FromQuery]string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest();
            }

            return Ok(_UsernameExists(username));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToPartial());
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            user.UpdatedAt = DateTimeOffset.Now;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid || _UsernameExists(user.Username))
            {
                return BadRequest(ModelState);
            }

            user.CreatedAt = DateTimeOffset.Now;
            user.UpdatedAt = DateTimeOffset.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user.ToPartial());
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user.ToPartial());
        }

        private bool _UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private bool _UsernameExists(string username)
        {
            return _context.Users.Any(e => e.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}