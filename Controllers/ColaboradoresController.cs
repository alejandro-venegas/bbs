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
    public class ColaboradoresController : Controller
    {
        private readonly SBBSContext _context;

        public ColaboradoresController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetColaboradores()
        {
            var colaboradores = await _context.Colaboradores.Include(c => c.Departamento).Include(c => c.Usuario).ToListAsync();
            return Ok(colaboradores);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertColaborador(Colaborador colaborador)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(p => p.Type == ClaimTypes.Name))
            {
                var username = currentUser.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                await _context.Colaboradores.AddAsync(colaborador);
                await _context.SaveChangesAsync();
                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    UsuarioId = user.Id,
                    DescripcionBitacora = "Creó nuevo colaborador " + colaborador.Nombre + " " + colaborador.Apellido + " ID " + colaborador.Id
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            return Unauthorized();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateColaborador(Colaborador colaborador)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(p => p.Type == ClaimTypes.Name))
            {
                var username = currentUser.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                var result = await _context.Colaboradores.Include(c => c.Departamento).FirstOrDefaultAsync(c => c.Id == colaborador.Id);
                if (result != null)
                {
                    result.Nombre = colaborador.Nombre;
                    result.Apellido = colaborador.Apellido;
                    result.Puesto = colaborador.Puesto;
                    if (result.DepartamentoId != colaborador.DepartamentoId)
                    {
                        if (result.Departamento != null && result.Id == result.Departamento.GerenteId)
                        {
                            return StatusCode(409);
                        }
                        result.DepartamentoId = colaborador.DepartamentoId;
                    };
                    _context.Colaboradores.Update(result);

                    Bitacora bitacora = new Bitacora
                    {
                        Fecha = DateTime.Now,
                        UsuarioId = user.Id,
                        DescripcionBitacora = "Actualizó colaborador " + colaborador.Nombre + " " + colaborador.Apellido + " ID " + colaborador.Id
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
        public async Task<IActionResult> DeleteColaborador(int id)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(p => p.Type == ClaimTypes.Name))
            {
                var username = currentUser.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                Colaborador colaborador = await _context.Colaboradores.FirstOrDefaultAsync(c => c.Id == id);
                _context.Colaboradores.Remove(colaborador);
                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    UsuarioId = user.Id,
                    DescripcionBitacora = "Eliminó colaborador " + colaborador.Nombre + " " + colaborador.Apellido + " ID " + colaborador.Id
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();
                return StatusCode(202);
            }
            return Unauthorized();
        }
    }
}