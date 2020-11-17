using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Implements
{
    public class PedidosBLL : IPedidosBLL
    {
        private readonly IPedidosDAO pedidosDao;
        private readonly IPedidoDetalleBLL detelleDao;
        private readonly IProductosBLL productosBLL;
        public PedidosBLL(IPedidosDAO _pedidosDao, IPedidoDetalleBLL _detelleDao, IProductosBLL _productosBLL)
        {
            this.pedidosDao = _pedidosDao;
            this.detelleDao = _detelleDao;
            this.productosBLL = _productosBLL;
        }
        public void Delete(Pedidos entidad)
        {
            this.pedidosDao.Delete(entidad);
        }

        public Pedidos GetPedidoById(int id)
        {
            return this.pedidosDao.GetById(id);
        }

        public IQueryable<Pedidos> GetPedidos()
        {
            var ped = this.pedidosDao.Get().ToList();
            ped.ForEach(x =>
            {
                x.DetallePedido = this.detelleDao.GetPedidoDetalle()
                .Where(c => c.IdPedido == x.IdPedido)
                .Select(x => new DetallePedido {
                    Activo = x.Activo, 
                    IdProducto = x.IdProducto,
                    FechaModificacion = x.FechaModificacion, 
                    IdDetalle = x.IdDetalle, 
                    Cantidad = x.Cantidad
                }).ToList();

                x.DetallePedido.ToList().ForEach(c =>
                {
                    c.Producto = this.productosBLL.GetProductoseById(c.IdProducto);
                });
            });
            return this.pedidosDao.Get();
        }

        public Pedidos Insert(Pedidos entidad)
        {
            return this.pedidosDao.Insert(entidad);
        }

        public void Update(Pedidos entidad, int id)
        {
            this.pedidosDao.Update(entidad, id);
        }
    }
}
