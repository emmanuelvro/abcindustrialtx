using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalibreController : Controller
    {
        private ICatCalibresBLL _catCalibre;
        private readonly IMapper _mapper = null;
        public CalibreController(ICatCalibresBLL catCalibre, IMapper mapper)
        {
            _catCalibre = catCalibre;
            _mapper = mapper;
        }
        [HttpPost("insertcalibre")]
        public IActionResult InsertCalibre(CatCalibre calibres)
        {
            var calibre = _mapper.Map<CatCalibre>(calibres);

                _catCalibre.Insert(calibre);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_catCalibre.Get());
        }
    }
}
