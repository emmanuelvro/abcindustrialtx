using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using abcindustrialtx.Business.Implements;
using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoresController : ControllerBase
    {
        private ICatColores _catColores;
        public ColoresController(ICatColores catColores)
        {
            _catColores = catColores;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_catColores.Get());
        }
    }
}

