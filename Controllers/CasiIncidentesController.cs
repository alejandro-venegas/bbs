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
    public class CasiIncidentesController : Controller
    {
        private readonly SBBSContext _context;

        public CasiIncidentesController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetIncidentes(){
            var casiIncidentes = await _context.CasiIncidentes.Include(c => c.Area).ToListAsync();
            return Ok(casiIncidentes);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertIncidente(CasiIncidente casiIncidente){
            await _context.CasiIncidentes.AddAsync(casiIncidente);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
    }
}