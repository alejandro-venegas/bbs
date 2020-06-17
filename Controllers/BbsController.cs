using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bbs.Models;
using bbs.DTOs;
using System.Collections.Generic;
namespace bbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BbsController : Controller
    {
        private readonly SBBSContext _context;

        public BbsController(SBBSContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetBbs(){
            var bbss = await _context.Bbss.Include(b => b.Area).ToListAsync();
            return Ok(bbss);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertBbs(Bbs bbs){
            await _context.Bbss.AddAsync(bbs);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        
    }
}