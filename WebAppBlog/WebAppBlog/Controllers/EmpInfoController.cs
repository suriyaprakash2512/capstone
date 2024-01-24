using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppBlog.Models;

namespace WebAppBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpInfoController : ControllerBase
    {
        private readonly BlogContext _context;

        public EmpInfoController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/EmpInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpInfo>>> GetEmpInfo()
        {
            var empInfos = await _context.EmpInfos.ToListAsync();

            if (empInfos == null || !empInfos.Any())
            {
                return NotFound("No employee information found.");
            }

            return empInfos;
        }

        // GET: api/EmpInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpInfo>> GetEmpInfo(int id)
        {
            var empInfo = await _context.EmpInfos.FindAsync(id);

            if (empInfo == null)
            {
                return NotFound("Employee information not found.");
            }

            return empInfo;
        }

        // PUT: api/EmpInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpInfo(int id, EmpInfo empInfo)
        {
            if (id != empInfo.EmpId)
            {
                return BadRequest("Invalid employee ID.");
            }

            _context.Entry(empInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpInfoExists(id))
                {
                    return NotFound("Employee information not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmpInfo
        [HttpPost]
        public async Task<ActionResult<EmpInfo>> PostEmpInfo(EmpInfo empInfo)
        {
            _context.EmpInfos.Add(empInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpInfo", new { id = empInfo.EmpId }, empInfo);
        }

        // DELETE: api/EmpInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpInfo(int id)
        {
            var empInfo = await _context.EmpInfos.FindAsync(id);
            if (empInfo == null)
            {
                return NotFound("Employee information not found.");
            }

            _context.EmpInfos.Remove(empInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpInfoExists(int id)
        {
            return _context.EmpInfos.Any(e => e.EmpId == id);
        }
    }

}

