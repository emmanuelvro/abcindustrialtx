using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Entities.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace abcindustrialtx.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ICatRolesBLL _catRolesBLL = null;
        private readonly IMapper _mapper = null;
        public RolesController(ICatRolesBLL catRolesBLL, IMapper mapper)
        {
            _catRolesBLL = catRolesBLL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            IEnumerable<RolesGetDto> roles = _mapper.Map<IEnumerable<RolesGetDto>>(_catRolesBLL.GetRoles());
            return Ok(roles);
        }

        [HttpGet("{id}", Name = nameof(GetRolById))]
        public ActionResult<RolesGetDto> GetRolById(int id)
        {
            RolesGetDto rol = _mapper.Map<RolesGetDto>(_catRolesBLL.GetRolById(id));

            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        [HttpPost]
        public ActionResult<RolesGetDto> InsertRol([FromBody] RolesCreateDto rolesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Roles roles = _mapper.Map<Roles>(rolesDto);

            _catRolesBLL.Insert(roles);

            return CreatedAtAction(
                nameof(GetRolById),
                new { id = roles.IdRol },
                _mapper.Map<RolesGetDto>(roles));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Roles existeRol = _catRolesBLL.GetRolById(id);

            if (existeRol == null)
            {
                return NotFound();
            }

            _catRolesBLL.Delete(existeRol);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRol(int id, [FromBody] RolesUpdateDto rolesDto)
        {
            Roles currentRol = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rolesDto.IdRol)
            {
                return BadRequest("El id de la url no corresponde con el modelo");
            }

            try
            {
                currentRol = _catRolesBLL.GetRolById(id);

                if (currentRol != null)
                {
                    Roles mapRol = _mapper.Map<Roles>(rolesDto);
                    _catRolesBLL.Update(mapRol, id);
                }
                else
                {
                    return NotFound("El rol que quiere actualizar no existe");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_mapper.Map<RolesGetDto>(currentRol));
        }

        private bool RolExists(int id)
        {
            return _catRolesBLL.GetRoles().Any(e => e.IdRol == id);
        }
    }
}
