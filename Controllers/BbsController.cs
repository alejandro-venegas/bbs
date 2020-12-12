using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bbs.Models;
using bbs.DTOs;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;

namespace bbs.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BbsController : Controller
    {
        private readonly SBBSContext _context;

        public BbsController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBbs(int id)
        {
            var bbs = await _context.Bbss.SingleOrDefaultAsync(bbs => bbs.Id == id);
            if (bbs != null)
            {
                return Ok(bbs);
            }
            return StatusCode(400);
        }
        [HttpGet]
        public async Task<IActionResult> GetBbss()
        {
            var bbss = await _context.Bbss.Include(b => b.Area).ToListAsync();
            return Ok(bbss);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertBbs(Bbs bbs)
        {

            var currentUser = HttpContext.User;

            if (currentUser.HasClaim( c => c.Type == ClaimTypes.Name))
            {

                var username = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                await _context.Bbss.AddAsync(bbs);
                await _context.SaveChangesAsync();
                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    UsuarioId = user.Id,
                    DescripcionBitacora = "Insertó nuevo BBS con ID " + bbs.Id
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();
                return StatusCode(201);

            }
            return Unauthorized();

        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBbs(Bbs bbs)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(p => p.Type == ClaimTypes.Name))
            {
                 var username = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                var bbsObj = await _context.Bbss.SingleOrDefaultAsync(b => b.Id == bbs.Id);
                if (bbsObj != null)
                {
                    bbsObj.ObservadorId = bbs.ObservadorId;
                    bbsObj.ProcesoId = bbs.ProcesoId;
                    bbsObj.TipoComportamientoId = bbs.TipoComportamientoId;
                    bbsObj.AreaId = bbs.AreaId;
                    bbsObj.ComportamientoId = bbs.ComportamientoId;
                    bbsObj.Fecha = bbs.Fecha;
                    bbsObj.TipoObservadoId = bbs.TipoObservadoId;
                    _context.Bbss.Update(bbsObj);

                    await _context.SaveChangesAsync();
                    Bitacora bitacora = new Bitacora
                    {
                        Fecha = DateTime.Now,
                        UsuarioId = user.Id,
                        DescripcionBitacora = "Actualizó BBS con ID " + bbs.Id
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
        public async Task<IActionResult> DeleteBbs(int id)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(p => p.Type == ClaimTypes.Name))
            {
                var username = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
            
            Bbs bbs = new Bbs();
            bbs.Id = id;
            _context.Bbss.Remove(bbs);
            Bitacora bitacora = new Bitacora
            {
                Fecha = DateTime.Now,
                UsuarioId = user.Id,
                DescripcionBitacora = "Eliminó BBS con ID " + bbs.Id
            };
            await _context.Bitacora.AddAsync(bitacora);
            await _context.SaveChangesAsync();
            return StatusCode(202);
            }
            return Unauthorized();
        }

    }

}