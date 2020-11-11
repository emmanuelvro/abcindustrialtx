using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class RolesUpdateDto
    {
        [Required]
        public int IdRol { get; set; }
        [Required]
        public string NombreRol { get; set; }
    }
}
