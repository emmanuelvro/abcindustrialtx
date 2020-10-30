using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Entities.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ICatUsuarioBLL _catUsuario = null;
        private readonly IMapper _mapper = null;
        private readonly IConfiguration _configuration;

        public UsuariosController(ICatUsuarioBLL catUsuario, IMapper mapper,
            IConfiguration configuration)
        {
            _catUsuario = catUsuario;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_catUsuario.GetUsers());
        }

        [HttpPost("insertuser")]
        public IActionResult InsertUser(UsuarioDto usuario)
        {
            var user = _mapper.Map<CatUsuario>(usuario);

            _catUsuario.Insert(user);

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult<SuccessfulLoginResult> Login(UsuarioLoginDTO usuario)
        {
            CatUsuario user = _catUsuario.Login(_mapper.Map<CatUsuario>(usuario));

            if (user == null)
                return BadRequest("Credenciales inválidas");

            JwtSecurityToken token = this.GenerateTokenAsync(user);

            string serializarToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new SuccessfulLoginResult() { Token = serializarToken };
        }

        private JwtSecurityToken GenerateTokenAsync(CatUsuario user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            //var roles = await _roles.GetRolesAsync(user);

            //foreach (string role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Restful:JwtKey")));
            SigningCredentials credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(_configuration.GetValue<string>("Restful:TokenIssuer"),
                _configuration.GetValue<string>("Restful:TokenIssuer"),
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credenciales
                );

            return token;
        }
    }
}

