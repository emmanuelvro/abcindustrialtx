using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Entities.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using System;
using System.Threading.Tasks;

namespace abcindustrialtx.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IProductosBLL productosBLL = null;

        public ProductosController(IProductosBLL _productosBLL)
        {
            productosBLL = _productosBLL;
        }
        [HttpGet]
        public IActionResult GetProductos()
        {
            return Ok(this.productosBLL.GetProductos());
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Productos model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.FechaModificacion = DateTime.Now;
            model.Activo = 1;
            return Ok(this.productosBLL.Insert(model));
        }
    }
}
