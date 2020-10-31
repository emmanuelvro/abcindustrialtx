using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("insertmaterial")]
        public IActionResult InsertMaterial(CatHilosMateriales materiales)
        {
            var material = _mapper.Map<CatHilosMateriales>(materiales);

                _catMateriales.Insert(material);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_catMateriales.Get());
        }
    }
}
