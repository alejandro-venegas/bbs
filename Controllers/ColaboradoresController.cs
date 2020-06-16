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
    public class ColaboradoresController : Controller
    {
        private readonly SBBSContext _context;

        public ColaboradoresController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetColaboradores(){
            var colaboradores = await _context.Colaboradores.Include( c => c.Departamento).ToListAsync();
            return Ok(colaboradores);
        }

        [HttpPost("new")]
            public async Task<IActionResult> InsertColaborador(Colaborador colaborador){
            await _context.Colaboradores.AddAsync(colaborador);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPost("update")]
            public async Task<IActionResult> UpdateColaborador(Colaborador colaborador){
                var result = await _context.Colaboradores.Include(c => c.Departamento).FirstOrDefaultAsync(c => c.Id == colaborador.Id);
                if (result != null) {
                    result.Nombre = colaborador.Nombre;
                    result.Apellido = colaborador.Apellido;
                    result.Puesto = colaborador.Puesto;
                    if (result.DepartamentoId != colaborador.DepartamentoId){
                        if(result.Departamento != null && result.Id == result.Departamento.GerenteId){
                            return StatusCode(409);
                        }
                        result.DepartamentoId = colaborador.DepartamentoId;
                    };
                     _context.Colaboradores.Update(result);

                     await _context.SaveChangesAsync();
                    return StatusCode(202);
                }
                return StatusCode(400);
            }


        [HttpDelete]
        public async Task<IActionResult> DeleteColaborador(int id){
            Colaborador colaborador = new Colaborador();
            colaborador.Id = id;
            _context.Colaboradores.Remove(colaborador);
            await _context.SaveChangesAsync();
            return StatusCode(202);
        }
    }
}