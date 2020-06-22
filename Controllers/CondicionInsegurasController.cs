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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCondicionInsegura(int id){
            var condicionInsegura = await _context.CondicionInseguras.SingleOrDefaultAsync( condicionInsegura => condicionInsegura.Id == id);
            if(condicionInsegura != null){
                return Ok(condicionInsegura);
            }
            return StatusCode(400);
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
        [HttpPost("update")]
        public async Task<IActionResult> UpdateCondicionInsegura(CondicionInsegura condicionInsegura){
            var condicionInseguraObj = await _context.CondicionInseguras.SingleOrDefaultAsync(b => b.Id == condicionInsegura.Id);
            if( condicionInseguraObj != null){
                condicionInseguraObj.ProcesoId = condicionInsegura.ProcesoId;
                condicionInseguraObj.Fecha = condicionInsegura.Fecha;
                condicionInseguraObj.AreaId = condicionInsegura.AreaId;
                condicionInseguraObj.FactorRiesgoId = condicionInsegura.FactorRiesgoId;
                condicionInseguraObj.IndicadorRiesgoId = condicionInsegura.IndicadorRiesgoId;
                condicionInseguraObj.SupervisorId = condicionInsegura.SupervisorId;
                _context.CondicionInseguras.Update(condicionInseguraObj);
                await _context.SaveChangesAsync();

                return StatusCode(202);
            }
            return StatusCode(400);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCondicionInsegura(int id){
            CondicionInsegura condicionInsegura = new CondicionInsegura();
            condicionInsegura.Id = id;
            _context.CondicionInseguras.Remove(condicionInsegura);
            await _context.SaveChangesAsync();
            return StatusCode(202);
        }
    }
}