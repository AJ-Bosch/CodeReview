using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return await _context.USER
                .Where(u => !u.IsDeleted)
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Email = u.Email,
                    RoleId = u.RoleId,
                    CompanyCode = u.CompanyCode,
                    LastUpdate = u.LastUpdate,
                    Role = u.Role,
                    Company = u.Company
                })
                .ToListAsync();
        }

        // GET: api/User/Deleted
        [HttpGet("Deleted")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetDeletedUsers()
        {
            return await _context.USER.Where(u => u.IsDeleted)
            .Select(u => new UserDto
            {
                UserId = u.UserId,
                Username = u.Username,
                Email = u.Email,
                RoleId = u.RoleId,
                CompanyCode = u.CompanyCode,
                LastUpdate = u.LastUpdate,
                Role = u.Role,
                Company = u.Company
            }).ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.USER
                .Where(u => u.UserId == id && !u.IsDeleted)
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Email = u.Email,
                    RoleId = u.RoleId,
                    CompanyCode = u.CompanyCode,
                    LastUpdate = u.LastUpdate,
                    Role = u.Role,
                    Company = u.Company
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/User/ByCompanyCode/5
        [HttpGet("ByCompanyCode/{companyCode}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByCompanyCode(int companyCode)
        {
            return await _context.USER
                .Where(u => u.CompanyCode == companyCode && !u.IsDeleted)
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Email = u.Email,
                    RoleId = u.RoleId,
                    CompanyCode = u.CompanyCode,
                    LastUpdate = u.LastUpdate,
                    Role = u.Role,
                    Company = u.Company
                })
                .ToListAsync();
        }

        // GET: api/User/DeletedByCompanyCode/5
        [HttpGet("DeletedByCompanyCode/{companyCode}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetDeletedUsersByCompanyCode(int companyCode)
        {
            return await _context.USER
                .Where(u => u.CompanyCode == companyCode && u.IsDeleted)
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Email = u.Email,
                    RoleId = u.RoleId,
                    CompanyCode = u.CompanyCode,
                    LastUpdate = u.LastUpdate,
                    Role = u.Role,
                    Company = u.Company
                })
                .ToListAsync();
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(User user)
        {
            _context.USER.Add(user);
            await _context.SaveChangesAsync();

            var newUser = new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                RoleId = user.RoleId,
                CompanyCode = user.CompanyCode,
                LastUpdate = user.LastUpdate,
                Role = user.Role,
                Company = user.Company
            };

            return CreatedAtAction("GetUser", new { id = user.UserId }, newUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            // Consider handling password updates securely here

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.USER.Any(e => e.UserId == id))
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

        // DELETE: api/User/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.USER.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
