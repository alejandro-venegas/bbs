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
    public class IncidentesController : Controller
    {
        private readonly SBBSContext _context;

        public IncidentesController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetIncidentes(){
            var incidentes = await _context.Incidentes.Include(c => c.Area).ToListAsync();
            return Ok(incidentes);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertIncidente(Incidente incidente){
            await _context.Incidentes.AddAsync(incidente);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
    }
}