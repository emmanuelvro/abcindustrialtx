using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace abcindustrialtx.API.Controllers
{
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

        [HttpPost("insertpresentacion")]
        public IActionResult InsertPresentacion(CatPresentacion presentacion)
        {
            var presenta = _mapper.Map<CatPresentacion>(presentacion);
                _catPresentacion.Insert(presenta);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_catPresentacion.Get());
        }
    }
}
