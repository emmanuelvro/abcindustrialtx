using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace abcindustrialtx.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosBLL pedidosBLL = null;

        public PedidosController(IPedidosBLL _pedidosBLL)
        {
            pedidosBLL = _pedidosBLL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.pedidosBLL.GetPedidos());
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Pedidos model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.DetallePedido.ToList().ForEach(x =>
            {
                x.Activo = 1;
                x.FechaModificacion = DateTime.Now;
            });
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var sid = claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).LastOrDefault();
            model.IdUsuario = Convert.ToInt32(sid);
            model.FechaModificacion = DateTime.Now;
            model.Activo = 1;
            return Ok(this.pedidosBLL.Insert(model));
        }


        [HttpPut]
        public IActionResult Update([FromBody] Pedidos model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.pedidosBLL.Update(model, model.IdPedido);
            return Ok(model);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pedidos ped = pedidosBLL.GetPedidoById(id);

            if (ped == null)
            {
                return NotFound();
            }

            pedidosBLL.Delete(ped);

            return Ok(ped != null);
        }
    }
}
