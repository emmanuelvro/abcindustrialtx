using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Entities.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ICatUsuarioBLL _catUsuario = null;
        private readonly IMapper _mapper = null;
        private readonly IConfiguration _configuration;
        private readonly ICatRolesBLL _catRolesBLL;

        public UsuariosController(ICatUsuarioBLL catUsuario, IMapper mapper,
            IConfiguration configuration, ICatRolesBLL catRolesBLL)
        {
            _catUsuario = catUsuario;
            _mapper = mapper;
            _configuration = configuration;
            _catRolesBLL = catRolesBLL;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            IEnumerable<UsuarioGetDto> users = _mapper.Map<IEnumerable<UsuarioGetDto>>(_catUsuario.GetUsers());

            return Ok(users);
        }

        [HttpGet("{id}", Name = nameof(GetUserById))]
        public ActionResult<UsuarioGetDto> GetUserById(int id)
        {
            UsuarioGetDto user = _mapper.Map<UsuarioGetDto>(_catUsuario.GetUserById(id));

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UsuarioGetDto> InsertUser([FromBody] UsuarioCreateDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuarios user = _mapper.Map<Usuarios>(usuario);

            _catUsuario.Insert(user);

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = user.IdUsuario },
                _mapper.Map<UsuarioGetDto>(user));
        }

        [HttpPost("login")]
        public ActionResult<SuccessfulLoginResult> Login([FromBody] UsuarioLoginDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuarios user = _catUsuario.Login(_mapper.Map<Usuarios>(usuario));

            if (user == null)
                return BadRequest("Credenciales inválidas");

            JwtSecurityToken token = this.GenerateTokenAsync(user);

            string serializarToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new SuccessfulLoginResult() { Token = serializarToken };
        }

        [HttpDelete("{id}")]
        public ActionResult<Usuarios> Delete(int id)
        {
            Usuarios existeUsuario = _catUsuario.GetUserById(id);

            if (existeUsuario == null)
            {
                return NotFound();
            }

            _catUsuario.Delete(existeUsuario);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, [FromBody] UsuarioUpdateDto entidad)
        {
            Usuarios currentUser = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entidad.IdUsuario)
            {
                return BadRequest("El id de la url no corresponde con el modelo");
            }

            try
            {
                currentUser = _catUsuario.GetUserById(id);

                if (currentUser != null)
                {
                    entidad.CorreoElectronico = currentUser.CorreoElectronico;
                    entidad.Telefono = currentUser.Telefono;

                    Usuarios mapUser = _mapper.Map<Usuarios>(entidad);
                    _catUsuario.Update(mapUser, id);
                }
                else
                {
                    return NotFound("El usuario que quiere actualizar no existe");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_mapper.Map<UsuarioGetDto>(currentUser));
        }

        [HttpPost("agregarol")]
        public ActionResult<UsuarioRolGetDto> AddRol([FromBody] UsuarioRolCreateDto usuarioRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsuariosRoles userToRol = _catUsuario.AddRolToUser(new Usuarios { IdUsuario = usuarioRol.IdUsuario }, new Roles { IdRol = usuarioRol.IdRol });

            return Ok(_mapper.Map<UsuarioRolGetDto>(userToRol));
        }

        private bool UserExists(int id)
        {
            return _catUsuario.GetUsers().Any(e => e.IdUsuario == id);
        }


        private JwtSecurityToken GenerateTokenAsync(Usuarios user)
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
