using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using abcindustrialtx.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalibreController : Controller
    {
        private ICatCalibresBLL _catCalibre;
        public CalibreController(ICatCalibresBLL catCalibre)
        {
            _catCalibre = catCalibre;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_catCalibre.Get());
        }
    }
}
