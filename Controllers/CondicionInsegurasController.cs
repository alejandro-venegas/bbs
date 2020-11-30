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
    public class CondicionInsegurasController : Controller
    {
        private readonly SBBSContext _context;

        public CondicionInsegurasController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCondicionInsegura(int id)
        {

            var condicionInsegura = await _context.CondicionInseguras.SingleOrDefaultAsync(condicionInsegura => condicionInsegura.Id == id);
            if (condicionInsegura != null)
            {
                return Ok(condicionInsegura);
            }
            return StatusCode(400);
        }

        [HttpGet]
        public async Task<IActionResult> GetCondicionInseguras()
        {
            Console.Write("Hola");
            var condicionInseguras = await _context.CondicionInseguras.ToListAsync();
            return Ok(condicionInseguras);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertCondicionInsegura(CondicionInsegura condicionInsegura)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                await _context.CondicionInseguras.AddAsync(condicionInsegura);

                await _context.SaveChangesAsync();

                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    UsuarioId = user.Id,
                    DescripcionBitacora = "Insertó nueva Condicion Insegura con ID " + condicionInsegura.Id
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();

                return StatusCode(201);
            }
            return Unauthorized();
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateCondicionInsegura(CondicionInsegura condicionInsegura)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                var condicionInseguraObj = await _context.CondicionInseguras.SingleOrDefaultAsync(b => b.Id == condicionInsegura.Id);
                if (condicionInseguraObj != null)
                {
                    // condicionInseguraObj.ProcesoId = condicionInsegura.ProcesoId;
                    condicionInseguraObj.Fecha = condicionInsegura.Fecha;
                    // condicionInseguraObj.AreaId = condicionInsegura.AreaId;
                    // condicionInseguraObj.FactorRiesgoId = condicionInsegura.FactorRiesgoId;
                    // condicionInseguraObj.IndicadorRiesgoId = condicionInsegura.IndicadorRiesgoId;
                    _context.CondicionInseguras.Update(condicionInseguraObj);

                    Bitacora bitacora = new Bitacora
                    {
                        Fecha = DateTime.Now,
                        UsuarioId = user.Id,
                        DescripcionBitacora = "Actualizó Condicion Insegura con ID " + condicionInsegura.Id
                    };
                    await _context.Bitacora.AddAsync(bitacora);
                    await _context.SaveChangesAsync();

                    return StatusCode(202);
                }
                return StatusCode(400);
            }
            return Unauthorized();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCondicionInsegura(int id)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                CondicionInsegura condicionInsegura = new CondicionInsegura();
                condicionInsegura.Id = id;
                _context.CondicionInseguras.Remove(condicionInsegura);

                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    UsuarioId = user.Id,
                    DescripcionBitacora = "Eliminó Condicion Insegura con ID " + condicionInsegura.Id
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();
                return StatusCode(202);
            }
            return Unauthorized();
        }
    }
}