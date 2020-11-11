using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class RolesCreateDto
    {
        [Required]
        public string NombreRol { get; set; }
    }
}
