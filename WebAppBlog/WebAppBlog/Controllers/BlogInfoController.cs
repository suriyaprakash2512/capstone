using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppBlog.Models;

namespace WebAppBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogInfoController : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogInfoController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/BlogInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogInfo>>> GetBlogInfo()
        {
            var blogInfos = await _context.BlogInfos.ToListAsync();

            if (blogInfos == null || !blogInfos.Any())
            {
                return NotFound("No blog information found.");
            }

            return blogInfos;
        }

        // GET: api/BlogInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogInfo>> GetBlogInfo(int id)
        {
            var blogInfo = await _context.BlogInfos.FindAsync(id);

            if (blogInfo == null)
            {
                return NotFound("Blog information not found.");
            }

            return blogInfo;
        }

        // PUT: api/BlogInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogInfo(int id, BlogInfo blogInfo)
        {
            if (id != blogInfo.BlogId)
            {
                return BadRequest("Invalid blog ID.");
            }

            _context.Entry(blogInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogInfoExists(id))
                {
                    return NotFound("Blog information not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogInfo
        [HttpPost]
        public async Task<ActionResult<BlogInfo>> PostBlogInfo(BlogInfo blogInfo)
        {
            _context.BlogInfos.Add(blogInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogInfo", new { id = blogInfo.BlogId }, blogInfo);
        }

        // DELETE: api/BlogInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogInfo(int id)
        {
            var blogInfo = await _context.BlogInfos.FindAsync(id);
            if (blogInfo == null)
            {
                return NotFound("Blog information not found.");
            }

            _context.BlogInfos.Remove(blogInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogInfoExists(int id)
        {
            return _context.BlogInfos.Any(e => e.BlogId == id);
        }
    }

}

