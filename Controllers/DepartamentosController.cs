using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bbs.Models;
using bbs.DTOs;
using System.Collections.Generic;
using System;
using System.Linq;

namespace bbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : Controller
    {
        private readonly SBBSContext _context;

        public DepartamentosController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            var departamentos = await _context.Departamentos.Include(d => d.Gerente).ToListAsync();
            return Ok(departamentos);
        }

        [HttpPost("new")]
        public async Task<IActionResult> InsertDepartamento(Departamento departamento)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                var colaboradorResult = await _context.Colaboradores.FirstOrDefaultAsync(c => c.Id == departamento.GerenteId);
                if (colaboradorResult != null)
                {

                    var gerenteDe = await _context.Departamentos.FirstOrDefaultAsync(d => d.GerenteId == colaboradorResult.Id);
                    if (gerenteDe != null)
                    {
                        return StatusCode(409);
                    }

                    await _context.Departamentos.AddAsync(departamento);
                    await _context.SaveChangesAsync();
                    colaboradorResult.DepartamentoId = departamento.Id;
                    _context.Colaboradores.Update(colaboradorResult);

                    await _context.SaveChangesAsync();
                    Bitacora bitacora = new Bitacora
                    {
                        Fecha = DateTime.Now,
                        UsuarioId = user.Id,
                        DescripcionBitacora = $"Creó nuevo Departamento {departamento.Nombre} ID {departamento.Id}"
                    };
                    await _context.Bitacora.AddAsync(bitacora);
                    await _context.SaveChangesAsync();
                    return StatusCode(201);
                }

                return StatusCode(400);
            }
            return Unauthorized();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateDepartamento(Departamento departamento)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                var departamentoResult = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == departamento.Id);
                var gerenteNuevo = await _context.Colaboradores.FirstOrDefaultAsync(c => c.Id == departamento.GerenteId);
                if (departamentoResult != null)
                {
                    departamentoResult.Nombre = departamento.Nombre;
                    if (gerenteNuevo != null && (departamentoResult.GerenteId != gerenteNuevo.Id))
                    {
                        var gerenteDe = await _context.Departamentos.FirstOrDefaultAsync(d => d.GerenteId == gerenteNuevo.Id);
                        if (gerenteDe != null)
                        {
                            return StatusCode(409);
                        }
                        gerenteNuevo.DepartamentoId = departamento.Id;
                        departamentoResult.GerenteId = gerenteNuevo.Id;
                        _context.Colaboradores.Update(gerenteNuevo);
                        await _context.SaveChangesAsync();
                    }
                    _context.Departamentos.Update(departamentoResult);
                    Bitacora bitacora = new Bitacora
                    {
                        Fecha = DateTime.Now,
                        UsuarioId = user.Id,
                        DescripcionBitacora = $"Actualizó Departamento {departamento.Nombre} ID {departamento.Id}"
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
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(c => c.Type == "username"))
            {
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                Departamento departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == id);
                _context.Departamentos.Remove(departamento);
                Bitacora bitacora = new Bitacora
                {
                    Fecha = DateTime.Now,
                    UsuarioId = user.Id,
                    DescripcionBitacora = $"Eliminó Departamento {departamento.Nombre} ID {departamento.Id}"
                };
                await _context.Bitacora.AddAsync(bitacora);
                await _context.SaveChangesAsync();
                return StatusCode(202);
            }
            return Unauthorized();
        }

        [HttpGet("gerentes")]

        public async Task<IActionResult> GetGerentes()
        {
            var departamentos = await _context.Departamentos.Include(d => d.Gerente).ToListAsync();
            List<Colaborador> gerentes = new List<Colaborador>();
            foreach (Departamento departamento in departamentos)
            {
                gerentes.Add(departamento.Gerente);
            }
            return Ok(gerentes);
        }

    }
}