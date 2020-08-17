using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bbs.Models;

namespace bbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : Controller
    {
        private readonly SBBSContext _context;

        public BitacoraController(SBBSContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetBitacora()
        {
            var bitacora = await _context.Bitacora.ToListAsync();
            return Ok(bitacora);
        }
    }
}