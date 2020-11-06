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
    public class MaterialesController : ControllerBase
    {
        private ICatMaterialesBLL _catMateriales;
        private readonly IMapper _mapper = null;
        //private readonly IConfiguration _configuration;
        public MaterialesController(ICatMaterialesBLL catMateriales, IMapper mapper)
        {
            _catMateriales = catMateriales;
            _mapper = mapper;
            //_configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllCalibres()
        {
            return Ok(_catMateriales.GetMateriales());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_catMateriales.GetMaterialById(id));
        }

        [HttpPost("insertmaterial")]
        public IActionResult InsertMaterial(CatMaterial materiales)
        {
            var material = _mapper.Map<CatMaterial>(materiales);

            _catMateriales.Insert(material);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<CatMaterial> Delete(int id)
        {
            CatMaterial existeMaterial = _catMateriales.GetMaterialById(id);

            if (existeMaterial == null)
            {
                return NotFound();
            }

            _catMateriales.Delete(existeMaterial);

            return existeMaterial;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMaterial(int id, CatMaterial entidad)
        {
            if (id != entidad.IdMaterial)
            {
                return BadRequest();
            }

            try
            {
                _catMateriales.Update(entidad, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        private bool MaterialExists(int id)
        {
            return _catMateriales.GetMateriales().Any(e => e.IdMaterial == id);
        }

   
    }
}
