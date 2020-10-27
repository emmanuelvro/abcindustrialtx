using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class DetallesLogs
    {
        public int IdLogs { get; set; }
        public string NombreTabla { get; set; }
        public string IdTransaccion { get; set; }
        public int IdUsuario { get; set; }
    }
}
