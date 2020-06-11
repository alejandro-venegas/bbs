using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using bbs.Models;
namespace bbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class VistasController : Controller
    {
        private readonly SBBSContext _context;

        public VistasController(SBBSContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetVistas(){
            var vistas = await _context.Vistas.ToListAsync();
            return Ok(vistas);
        }
    }
}