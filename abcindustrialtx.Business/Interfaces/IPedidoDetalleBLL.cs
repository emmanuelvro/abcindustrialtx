using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IPedidoDetalleBLL
    {
        DetallePedido Insert(DetallePedido entidad);
        IQueryable<DetallePedido> GetPedidoDetalle();
        DetallePedido GetPedidoDetalleById(int id);
        void Delete(DetallePedido entidad);
        void Update(DetallePedido entidad, int id);
    }
}
