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


        [HttpPut]
        public IActionResult Update([FromBody] Productos model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.productosBLL.Update(model, model.IdProducto);
            return Ok(model);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Productos prod = productosBLL.GetProductoseById(id);

            if (prod == null)
            {
                return NotFound();
            }

            productosBLL.Delete(prod);

            return Ok(prod != null);
        }
    }
}
