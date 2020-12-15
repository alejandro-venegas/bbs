using bbs.Models;
using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;    
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;    
using System.Text;
using System.Threading.Tasks;

namespace bbs.Controllers 
{    
    [Authorize]
    [Route("api/[controller]")]    
    [ApiController]    
    public class AuthController : Controller    
    {    
        private IConfiguration _config;  
        private readonly SBBSContext _context;  
    
        public AuthController(IConfiguration config, SBBSContext context)    
        {    
            _config = config;    
            _context = context;
        }    


        [Authorize]
        [HttpPost("new")]    
        public async Task<IActionResult> signUp(Usuario newUser)    
        {    

            await _context.Usuarios.AddAsync(newUser);
            await _context.SaveChangesAsync();
            
            var username = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
            var user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
            Bitacora bitacora = new Bitacora
            {
                Fecha = DateTime.Now,
                UsuarioId = user.Id,
                DescripcionBitacora = "Creó nuevo colaborador " + newUser.Username + " ID " + newUser.Id
            };
            await _context.Bitacora.AddAsync(bitacora);
            await _context.SaveChangesAsync();
            return StatusCode(201);  
        }    

        // [AllowAnonymous]    
        // [HttpPost]    
        // public async Task<IActionResult> Login(Usuario login)    
        // {    
        //     IActionResult response = Unauthorized();    
        //     var user = await AuthenticateUser(login);    
    
        //     if (user != null)    
        //     {    
        //         var tokenString = GenerateJSONWebToken(user);    
        //         response = Ok(new { token = tokenString });    
        //     }    
    
        //     return response;    
        // }    


        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(Usuario usuario)    
        { 
            var currentUser = HttpContext.User;
            if (currentUser.HasClaim(p => p.Type == ClaimTypes.Name))
            {
                var username = currentUser.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
                Usuario user = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                var result = await _context.Usuarios.FirstOrDefaultAsync<Usuario>(u => u.Id == usuario.Id);
                if(result != null){
                    result.RolId = usuario.RolId;
                    result.Username = usuario.Username;
                    result.ColaboradorId = usuario.ColaboradorId;
                    _context.Update(result);
                    Bitacora bitacora = new Bitacora
                    {
                        Fecha = DateTime.Now,
                        UsuarioId = user.Id,
                        DescripcionBitacora = "Actualizó usuario " + usuario.Username + " ID " + usuario.Id
                    };
                    await _context.Bitacora.AddAsync(bitacora);

                    await _context.SaveChangesAsync();
                    return StatusCode(202);
                }
                return StatusCode(400);
            }
            return Unauthorized();
        }

        [HttpGet("usuarios")]
         [Authorize]
        public async Task<IActionResult> GetUsers()    
        {    

            var usuarios = await _context.Usuarios
            .Include(u => u.Colaborador).ThenInclude(c => c.Departamento)
            .Include(u => u.Rol)
            .ToListAsync();
    
            return Ok(usuarios);    
        }  

        [HttpGet("test")]
        [Authorize]
        public async Task<IActionResult> TestUser()    
        {    
            var name = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
    
            return Ok(name);    
        }  

        

         [HttpGet]
         [Authorize]
        public async Task<IActionResult> GetCurrentUser()    
        {    
            var currentUser = HttpContext.User;   
            
    
            if (currentUser.HasClaim( c => c.Type == ClaimTypes.Name))    
            {    
                var username = HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name)?.Value;
                var user = await _context.Usuarios.Include(u => u.Rol.RolVistas).ThenInclude(RolVista=> RolVista.Vista).FirstOrDefaultAsync<Usuario>(u => u.Username == username);
                return Ok(user); 
            }    
    
            return Unauthorized();    
        }  

        
    
        private string GenerateJSONWebToken(Usuario userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {    
                new Claim("username", userInfo.Username),  
            };     
    
            var token = new JwtSecurityToken(null,    
             null,    
              claims: claims,    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    
        // private async Task<Usuario> AuthenticateUser(Usuario userCredentials)    
        // {    
        //     var user = await _context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Username == userCredentials.Username);

        //     if (user != null && user.Password == userCredentials.Password){
        //         return user;
        //     }
             
        //     return null;    
        // } 

        

       
    }    
}   