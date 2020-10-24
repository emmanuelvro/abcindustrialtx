using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using abcindustrialtx.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosBsn _iProductosBsn;

        public ProductosController(IProductosBsn poroductosBsn) => _iProductosBsn = poroductosBsn;

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                return Ok(await _iProductosBsn.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
