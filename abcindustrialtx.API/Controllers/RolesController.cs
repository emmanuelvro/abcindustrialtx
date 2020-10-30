using abcindustrialtx.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace abcindustrialtx.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ICatRolesBLL _catRolesBLL = null;
        public RolesController(ICatRolesBLL catRolesBLL)
        {
            _catRolesBLL = catRolesBLL;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(_catRolesBLL.GetRoles());
        }
    }
}

