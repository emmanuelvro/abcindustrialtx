using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoresController : ControllerBase
    {
        private ICatColoresBLL _catColores;
        private readonly IMapper _mapper = null;
        //private readonly IConfiguration _configuration;
        public ColoresController(ICatColoresBLL catColores, IMapper mapper)
        {
            _catColores = catColores;
            _mapper = mapper;
            //_configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllColors()
        {
            return Ok(_catColores.GetColors());
        }

        [HttpGet("{id}")]
        public IActionResult GetColorsById(int id)
        {
            return Ok(_catColores.GetColorById(id));
        }

        [HttpPost("insertcolor")]
        public IActionResult InsertColor(CatColores colores)
        {
            var color = _mapper.Map<CatColores>(colores);

                _catColores.Insert(color);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<CatColores> Delete(int id)
        {
            CatColores existeColor = _catColores.GetColorById(id);

            if (existeColor == null)
            {
                return NotFound();
            }

            _catColores.Delete(existeColor);

            return existeColor;
        }
        [HttpPut("{id}")]
        public IActionResult UpdateColors(int id, CatColores entidad)
        {
            if (id != entidad.IdColor)
            {
                return BadRequest();
            }

            try
            {
                _catColores.Update(entidad, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorsExists(id))
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
        private bool ColorsExists(int id)
        {
            return _catColores.GetColors().Any(e => e.IdColor == id);
        }
    }
}

