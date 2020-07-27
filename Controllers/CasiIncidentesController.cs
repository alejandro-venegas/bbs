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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCasiIncidente(int id){
            var casoIncidente = await _context.CasiIncidentes.SingleOrDefaultAsync( incidente => incidente.Id == id);
            if(casoIncidente != null){
                return Ok(casoIncidente);
            }
            return StatusCode(400);
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
        [HttpPost("update")]
        public async Task<IActionResult> UpdateCasiIncidente(CasiIncidente casiIncidente){
            var casiIncidenteObj = await _context.CasiIncidentes.SingleOrDefaultAsync(b => b.Id == casiIncidente.Id);
            if( casiIncidenteObj != null){
                casiIncidenteObj.ProcesoId = casiIncidente.ProcesoId;
                casiIncidenteObj.AreaId = casiIncidente.AreaId;
                casiIncidenteObj.Fecha = casiIncidente.Fecha;
                casiIncidenteObj.GeneroId = casiIncidente.GeneroId;
                casiIncidenteObj.JornadaId = casiIncidente.JornadaId;
                casiIncidenteObj.Observado = casiIncidente.Observado;
                casiIncidenteObj.RiesgoId = casiIncidente.RiesgoId;
                casiIncidenteObj.TurnoId = casiIncidente.TurnoId;
                casiIncidenteObj.Descripcion = casiIncidente.Descripcion;
                casiIncidenteObj.CasualidadId = casiIncidente.CasualidadId;
                _context.CasiIncidentes.Update(casiIncidenteObj);
                await _context.SaveChangesAsync();

                return StatusCode(202);
            }
            return StatusCode(400);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCasiIncidente(int id){
            CasiIncidente casiIncidente = new CasiIncidente();
            casiIncidente.Id = id;
            _context.CasiIncidentes.Remove(casiIncidente);
            await _context.SaveChangesAsync();
            return StatusCode(202);
        }
    }
}