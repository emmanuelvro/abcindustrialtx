using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IPedidosBLL
    {
        Pedidos Insert(Pedidos entidad);
        IQueryable<Pedidos> GetPedidos();
        Pedidos GetPedidoById(int id);
        void Delete(Pedidos entidad);
        void Update(Pedidos entidad, int id);
    }
}
