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
    public class CondicionInsegurasController : Controller
    {
        private readonly SBBSContext _context;

        public CondicionInsegurasController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCondicionInseguras(){
            var condicionInseguras = await _context.CondicionInseguras.Include(c => c.Area).ToListAsync();
            return Ok(condicionInseguras);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertCondicionInsegura(CondicionInsegura condicionInsegura){
            await _context.CondicionInseguras.AddAsync(condicionInsegura);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
    }
}