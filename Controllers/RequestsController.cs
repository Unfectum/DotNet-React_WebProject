using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNet_React_WebProject.Data;
using DotNet_React_WebProject.Models;

namespace DotNet_React_WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly DotNet_React_WebProjectContext _context;

        public RequestsController(DotNet_React_WebProjectContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            return await _context.Request.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{CourseId}&{UserId}")]
        public async Task<ActionResult<Request>> GetRequest(int CourseId, int UserId)
        {
            var request = await _context.Request.FindAsync(CourseId, UserId);
            
            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{CourseId}&{UserId}")]
        public async Task<IActionResult> PutRequest(int CourseId, int UserId, Request newrequest)
        {
            var request = await _context.Request.FindAsync(CourseId, UserId);
            if (request == null)
            {
                return NotFound();
            }
            request.IsConfirmed = newrequest.IsConfirmed;
            request.IsCreator = newrequest.IsCreator;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(CourseId, UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok() ;
        }

        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Request.Add(request);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RequestExists(request.CourseId, request.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRequest", new { CourseId = request.CourseId, UserId = request.UserId }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{CourseId}&{UserId}")]
        public async Task<IActionResult> DeleteRequest(int CourseId, int UserId)
        {
            var request = await _context.Request.FindAsync(CourseId, UserId);
            if (request == null)
            {
                return NotFound();
            }

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int CourseId, int UserId)
        {
            return _context.Request.Any(e => e.CourseId == CourseId && e.UserId == UserId);
        }
    }
}
