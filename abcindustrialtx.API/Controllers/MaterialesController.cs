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

        [HttpPost]
        public IActionResult InsertMaterial([FromBody] CatMaterial materiales)
        {
            //var material = _mapper.Map<CatMaterial>(materiales);
            materiales.FechaAlta = DateTime.Now;
            materiales.Activo = 1;

            return Ok(_catMateriales.Insert(materiales));
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

        [HttpPut]
        public IActionResult UpdateMaterial(CatMaterial entidad)
        {
            try
            {
                entidad.FechaAlta = DateTime.Now;
                entidad.Activo = 1;
                _catMateriales.Update(entidad, entidad.IdMaterial);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(entidad.IdMaterial))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(entidad);
        }

        private bool MaterialExists(int id)
        {
            return _catMateriales.GetMateriales().Any(e => e.IdMaterial == id);
        }


    }
}
