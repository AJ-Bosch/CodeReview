using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.COMPANY.Where(c => !c.IsDeleted).ToListAsync();
        }

        // GET: api/Company/Deleted
        [HttpGet("Deleted")]
        public async Task<ActionResult<IEnumerable<Company>>> GetDeletedCompanies()
        {
            return await _context.COMPANY.Where(c => c.IsDeleted).ToListAsync();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.COMPANY.FindAsync(id);

            if (company == null || company.IsDeleted)
            {
                return NotFound();
            }

            return company;
        }

        // POST: api/Company
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _context.COMPANY.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.COMPANY.Any(e => e.CompanyId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Company updated successfully." });
        }

        // DELETE: api/Company/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.COMPANY.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            company.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Company deleted successfully." });
        }
    }
}
