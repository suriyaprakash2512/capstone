using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppBlog.Models;

namespace WebAppBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminInfoController : ControllerBase
    {
        private readonly BlogContext _context;

        public AdminInfoController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/AdminInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminInfo>>> GetAdminInfo()
        {
            var adminInfos = await _context.AdminInfos.ToListAsync();

            if (adminInfos == null || !adminInfos.Any())
            {
                return NotFound("No admin information found.");
            }

            return adminInfos;
        }

        // GET: api/AdminInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminInfo>> GetAdminInfo(int id)
        {
            var adminInfo = await _context.AdminInfos.FindAsync(id);

            if (adminInfo == null)
            {
                return NotFound("Admin information not found.");
            }

            return adminInfo;
        }

        // PUT: api/AdminInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminInfo(int id, AdminInfo adminInfo)
        {
            if (id != adminInfo.AdminId)
            {
                return BadRequest("Invalid admin ID.");
            }

            _context.Entry(adminInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminInfoExists(id))
                {
                    return NotFound("Admin information not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdminInfo
        [HttpPost]
        public async Task<ActionResult<AdminInfo>> PostAdminInfo(AdminInfo adminInfo)
        {
            _context.AdminInfos.Add(adminInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminInfo", new { id = adminInfo.AdminId }, adminInfo);
        }

        // DELETE: api/AdminInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminInfo(int id)
        {
            var adminInfo = await _context.AdminInfos.FindAsync(id);
            if (adminInfo == null)
            {
                return NotFound("Admin information not found.");
            }

            _context.AdminInfos.Remove(adminInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminInfoExists(int id)
        {
            return _context.AdminInfos.Any(e => e.AdminId == id);
        }
    }

}

