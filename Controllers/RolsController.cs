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
        public class RolesController : Controller
    {
        private readonly SBBSContext _context;

        public RolesController(SBBSContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles(){
            var roles = await _context.Roles.Include(r => r.RolVistas).ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRol(int id){
            var roles = await _context.Roles.Include(rol => rol.RolVistas).ThenInclude(rolVista => rolVista.Vista).FirstOrDefaultAsync( x => x.Id == id);
            if(roles == null){
                return NotFound();
            }
            return Ok(roles);
        }
        [HttpPost("new")]
        public async Task<IActionResult> InsertRol(RolToInsert rolToInsert){
            Rol rol = new Rol();
            rol.Nombre = rolToInsert.Nombre;
            rol.Descripcion = rolToInsert.Descripcion;
            foreach(int vistaId in rolToInsert.Vistas)
            {
                RolVista rolVista = new RolVista();
                rolVista.Rol = rol;
                rolVista.VistaId = vistaId;
                await _context.RolVistas.AddAsync(rolVista);
            }
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id){
            Rol rol = new Rol();
            if(id == 1){
                return BadRequest();
            }
            rol.Id = id;
            
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return StatusCode(202);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRol(RolToInsert updatedRol){
            var result = await _context.Roles.Include(r => r.RolVistas).SingleOrDefaultAsync(rol => rol.Id == updatedRol.Id );
            List<RolVista> newRolVistas = new List<RolVista>();
            if (result != null)
            {
                result.Nombre = updatedRol.Nombre;
                result.Descripcion = updatedRol.Descripcion;
                foreach(int vistaId in updatedRol.Vistas){
                    var vista = await _context.Vistas.FirstOrDefaultAsync( x => x.Id == vistaId);

                    if(vista != null){
                        
                    newRolVistas.Add(new RolVista{
                         RolId = result.Id,
                         VistaId = vista.Id
                    });
                    }
                    
                }
                 _context.RolVistas.RemoveRange(result.RolVistas);
                _context.RolVistas.AddRange(newRolVistas);
                _context.Roles.Update(result);
                await _context.SaveChangesAsync();
                return StatusCode(202);
            }
            return StatusCode(400);
        }
    }
}
