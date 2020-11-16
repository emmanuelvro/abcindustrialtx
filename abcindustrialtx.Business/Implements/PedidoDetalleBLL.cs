using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Implements
{
    public class PedidoDetalleBLL : IPedidoDetalleBLL
    {
        private readonly IPedidoDetalleDAO pedidosDao;
        public PedidoDetalleBLL(IPedidoDetalleDAO _pedidosDao)
        {
            this.pedidosDao = _pedidosDao;
        }
        public void Delete(DetallePedido entidad)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DetallePedido> GetPedidoDetalle()
        {
            return this.pedidosDao.Get();
        }

        public DetallePedido GetPedidoDetalleById(int id)
        {
            throw new NotImplementedException();
        }

        public DetallePedido Insert(DetallePedido entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(DetallePedido entidad, int id)
        {
            throw new NotImplementedException();
        }
    }
}
