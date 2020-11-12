using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Entities.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using System.Threading.Tasks;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IHilosProductosBLL _hilosProductosBLL = null;
        private readonly IMapper _mapper;

        public ProductosController(IHilosProductosBLL hilosProductosBLL, IMapper mapper)
        {
            _hilosProductosBLL = hilosProductosBLL;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //_hilosProductosBLL
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Insertar([FromBody] HilosProductosCreateDTO hilosProductosDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HilosProductos producto = _mapper.Map<HilosProductos>(hilosProductosDto);

            await _hilosProductosBLL.InsertarProducto(producto,
                new CatPresentacion { IdPresentacion = hilosProductosDto.IdPresentacion },
                new CatMaterial { IdMaterial = hilosProductosDto.IdMaterial },
                new HilosProductosPedidos { Cantidad = hilosProductosDto.Cantidad });

            return Ok();
            //return CreatedAtAction(
            //    nameof(GetUserById),
            //    new { id = user.IdUsuario },
            //    _mapper.Map<UsuarioGetDto>(user));
        }
    }
}
