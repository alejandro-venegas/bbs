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
        [AllowAnonymous]    
        [HttpPost]    
        public async Task<IActionResult> Login(Usuario login)    
        {    
            IActionResult response = Unauthorized();    
            var user = await AuthenticateUser(login);    
    
            if (user != null)    
            {    
                var tokenString = GenerateJSONWebToken(user);    
                response = Ok(new { token = tokenString });    
            }    
    
            return response;    
        }    

         [HttpGet]
         [Authorize]
        public async Task<IActionResult> GetCurrentUser()    
        {    
            var currentUser = HttpContext.User;   
    
            if (currentUser.HasClaim( c => c.Type == "username"))    
            {    
                var username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
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
    
        private async Task<Usuario> AuthenticateUser(Usuario userCredentials)    
        {    
            var user = await _context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Username == userCredentials.Username);

            if (user != null && user.Password == userCredentials.Password){
                return user;
            }
             
            return null;    
        } 

       
    }    
}   