﻿using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("insertcolor")]
        public IActionResult InsertColor(CatColores colores)
        {
            var color = _mapper.Map<CatColores>(colores);
            if (!ModelState.IsValid) 
            {
                _catColores.Insert(color);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_catColores.Get());
        }
    }
}

