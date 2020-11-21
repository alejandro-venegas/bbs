using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bbs.Models;
using bbs.DTOs;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace bbs.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _context.Roles.Include(r => r.RolVistas).ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRol(int id)
        {
            var roles = await _context.Roles.Include(rol => rol.RolVistas).ThenInclude(rolVista => rolVista.Vista).FirstOrDefaultAsync(x => x.Id == id);
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }
        [HttpPost("new")]
        public async Task<IActionResult> InsertRol(RolToInsert rolToInsert)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                Rol rol = new Rol();
                rol.Nombre = rolToInsert.Nombre;
                rol.Descripcion = rolToInsert.Descripcion;
                foreach (VistaDto vista in rolToInsert.Vistas)
                {
                    RolVista rolVista = new RolVista();
                    rolVista.Rol = rol;
                    rolVista.VistaId = vista.Id;
                    rolVista.Escritura = vista.Escritura;
                    await _context.RolVistas.AddAsync(rolVista);
                }
                await _context.Roles.AddAsync(rol);
                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    UsuarioId = user.Id,
                    DescripcionBitacora = $"Creó nuevo rol {rol.Nombre} ID {rol.Id}"
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            return Unauthorized();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                Rol rol = new Rol();
                if (id == 1)
                {
                    return BadRequest();
                }
                rol.Id = id;

                _context.Roles.Remove(rol);
                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    UsuarioId = user.Id,
                    DescripcionBitacora = $"Eliminó rol {rol.Nombre} ID {rol.Id}"
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();
                return StatusCode(202);
            }
            return Unauthorized();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRol(RolToInsert updatedRol)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                var result = await _context.Roles.Include(r => r.RolVistas).SingleOrDefaultAsync(rol => rol.Id == updatedRol.Id);
                List<RolVista> newRolVistas = new List<RolVista>();
                if (result != null)
                {
                    result.Nombre = updatedRol.Nombre;
                    result.Descripcion = updatedRol.Descripcion;
                    foreach (VistaDto vista in updatedRol.Vistas)
                    {


                        if (vista != null)
                        {

                            newRolVistas.Add(new RolVista
                            {
                                RolId = result.Id,
                                VistaId = vista.Id,
                                Escritura = vista.Escritura
                            });
                        }

                    }
                    _context.RolVistas.RemoveRange(result.RolVistas);
                    _context.RolVistas.AddRange(newRolVistas);
                    _context.Roles.Update(result);
                    Bitacora bitacora = new Bitacora
                    {
                        Fecha = DateTime.Now,
                        UsuarioId = user.Id,
                        DescripcionBitacora = $"Actualizó rol {result.Nombre} ID {result.Id}"
                    };
                    await _context.Bitacora.AddAsync(bitacora);
                    await _context.SaveChangesAsync();
                    return StatusCode(202);
                }
                return StatusCode(400);
            }
            return Unauthorized();
        }
    }
}
