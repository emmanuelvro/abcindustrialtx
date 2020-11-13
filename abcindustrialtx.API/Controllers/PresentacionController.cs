using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace abcindustrialtx.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionController : Controller
    {
        private ICatPresentacionBLL _catPresentacion;
        private readonly IMapper _mapper = null;
        public PresentacionController(ICatPresentacionBLL catPresentacion, IMapper mapper)
        {
            _catPresentacion = catPresentacion;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPresentacion()
        {
            return Ok(_catPresentacion.GetPresentacion());
        }

        [HttpGet("{id}")]
        public IActionResult GetColorsById(int id)
        {
            return Ok(_catPresentacion.GetPresentacionById(id));
        }

        [HttpPost]
        public IActionResult InsertPresentacion(CatPresentacion presentaciones)
        {
            //var presentacion = _mapper.Map<CatPresentacion>(presentaciones);
            presentaciones.Activo = 1;
            presentaciones.FechaAlta = DateTime.Now;


            return Ok(_catPresentacion.Insert(presentaciones));
        }

        [HttpDelete("{id}")]
        public ActionResult<CatPresentacion> Delete(int id)
        {
            CatPresentacion existePresentacion = _catPresentacion.GetPresentacionById(id);

            if (existePresentacion == null)
            {
                return NotFound();
            }

            _catPresentacion.Delete(existePresentacion);

            return existePresentacion;
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePresentacion(int id, CatPresentacion entidad)
        {
            if (id != entidad.IdPresentacion)
            {
                return BadRequest();
            }

            try
            {
                _catPresentacion.Update(entidad, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool PresentacionExists(int id)
        {
            return _catPresentacion.GetPresentacion().Any(e => e.IdPresentacion == id);
        }
    }
}
