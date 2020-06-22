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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncidente(int id){
            var incidente = await _context.Incidentes.SingleOrDefaultAsync( incidente => incidente.Id == id);
            if(incidente != null){
                return Ok(incidente);
            }
            return StatusCode(400);
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateIncidente(Incidente incidente){
            var incidenteObj = await _context.Incidentes.SingleOrDefaultAsync(b => b.Id == incidente.Id);
            if( incidenteObj != null){
                incidenteObj.ProcesoId = incidente.ProcesoId;
                incidenteObj.AreaId = incidente.AreaId;
                incidenteObj.ActividadId = incidente.ActividadId;
                incidenteObj.CausaBasicaId = incidente.CausaBasicaId;
                incidenteObj.CausaInmediataId = incidente.CausaInmediataId;
                incidenteObj.ClasificacionId = incidente.ClasificacionId;
                incidenteObj.EfectoId = incidente.EfectoId;
                incidenteObj.Fecha = incidente.Fecha;
                incidenteObj.GeneroId = incidente.GeneroId;
                incidenteObj.JornadaId = incidente.JornadaId;
                incidenteObj.Observado = incidente.Observado;
                incidenteObj.ParteCuerpoId = incidente.ParteCuerpoId;
                incidenteObj.RiesgoId = incidente.RiesgoId;
                incidenteObj.SupervisorId = incidente.SupervisorId;
                incidenteObj.TurnoId = incidente.TurnoId;
                incidenteObj.Descripcion = incidente.Descripcion;
                _context.Incidentes.Update(incidenteObj);
                await _context.SaveChangesAsync();

                return StatusCode(202);
            }
            return StatusCode(400);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteIncidente(int id){
            Incidente incidente = new Incidente();
            incidente.Id = id;
            _context.Incidentes.Remove(incidente);
            await _context.SaveChangesAsync();
            return StatusCode(202);
        }
    }
}