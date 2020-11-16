using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Implements
{
    public class ProductosBLL : IProductosBLL
    {
        private readonly IProductosDAO productosDao;
        private readonly IProductosColorBLL productosColor;
        private readonly ICatCalibresBLL calibre;
        private readonly ICatPresentacionBLL presentacion;
        private readonly IProductosMaterialBLL productosMaterial;
        private readonly ICatMaterialesBLL material;
        private readonly ICatColoresBLL color;
        public ProductosBLL(IProductosDAO _productosDao, IProductosColorBLL _productosColor, IProductosMaterialBLL _productosMaterial, ICatCalibresBLL _calibre, ICatPresentacionBLL _presentacion, ICatMaterialesBLL _material, ICatColoresBLL _color)
        {
            this.productosDao = _productosDao;
            this.productosColor = _productosColor;
            this.productosMaterial = _productosMaterial;
            this.presentacion = _presentacion;
            this.calibre = _calibre;
            this.material = _material;
            this.color = _color;
        }
        public void Delete(Productos entidad)
        {
            this.productosDao.Delete(entidad);
        }

        public IQueryable<Productos> GetProductos()
        {
            var pro = this.productosDao.Get();
            pro.ToList().ForEach(x =>
            {
                var cal = this.calibre.GetCalibreById(x.IdCalibre);
                var pre = this.presentacion.GetPresentacionById(x.IdPresentacion);
                x.Calibre.Activo = cal.Activo;
                x.Calibre.FechaModificacion = cal.FechaModificacion;
                x.Calibre.Productos = null;
                x.Calibre.IdCalibre = cal.IdCalibre;
                x.Calibre.Calibre = cal.Calibre;
                x.Presentacion.Activo = pre.Activo;
                x.Presentacion.FechaAlta = pre.FechaAlta;
                x.Presentacion.IdPresentacion = pre.IdPresentacion;
                x.Presentacion.Productos = null;
                
                x.ProductoMaterial = this.productosMaterial.GetProductosMaterial().Where(c => c.IdProducto == x.IdProducto).Select(x => new ProductoMaterial { Activo = x.Activo, IdProducto = x.IdProducto, FechaModificacion = x.FechaModificacion, IdMaterial = x.IdMaterial,  IdProductoMaterial = x.IdProductoMaterial }).ToList();

                x.ProductoMaterial.ToList().ForEach(pm =>
                {
                    pm.Material = this.material.GetMaterialById(pm.IdMaterial);
                });
                x.ProductoColor = this.productosColor.GetProductosColor().Where(c => c.IdProducto == x.IdProducto).Select(x=> new ProductoColor{ Activo = x.Activo, IdProducto = x.IdProducto, FechaModificacion = x.FechaModificacion, IdColor = x.IdColor, Porcentaje = x.Porcentaje, IdProductoColor =x.IdProductoColor }).ToList();
                x.ProductoColor.ToList().ForEach(pc =>
                {
                    pc.Color = this.color.GetColorById(pc.IdColor);
                });
            });
            return pro;
        }

        public Productos GetProductoseById(int id)
        {
            var pro = this.productosDao.GetById(id);
            var cal = this.calibre.GetCalibreById(pro.IdCalibre);
            var pre = this.presentacion.GetPresentacionById(pro.IdPresentacion);
            pro.Calibre.Activo = cal.Activo;
            pro.Calibre.FechaModificacion = cal.FechaModificacion;
            pro.Calibre.IdCalibre = cal.IdCalibre;
            pro.Calibre.Productos = null;
            pro.Calibre.Calibre = cal.Calibre;
            pro.Presentacion.Activo = pre.Activo;
            pro.Presentacion.FechaAlta = pre.FechaAlta;
            pro.Presentacion.IdPresentacion = pre.IdPresentacion;
            pro.Presentacion.Presentacion = pre.Presentacion;
            pro.Presentacion.Productos = null;
            pro.ProductoMaterial = this.productosMaterial.GetProductosMaterial()
                .Where(c => c.IdProducto == pro.IdProducto)
                .Select(x => new ProductoMaterial { 
                    Activo = x.Activo, 
                    IdProducto = x.IdProducto, 
                    FechaModificacion = x.FechaModificacion, 
                    IdMaterial = x.IdMaterial, 
                    IdProductoMaterial = x.IdProductoMaterial 
                }).ToList();
            pro.ProductoMaterial.ToList().ForEach(pm =>
            {
                pm.Material = this.material.GetMaterialById(pm.IdMaterial);
            });
            pro.ProductoColor = this.productosColor.GetProductosColor()
                .Where(c => c.IdProducto == pro.IdProducto)
                .Select(x => new ProductoColor { 
                    Activo = x.Activo, 
                    IdProducto = x.IdProducto, 
                    FechaModificacion = x.FechaModificacion, 
                    IdColor = x.IdColor, 
                    Porcentaje = x.Porcentaje, 
                    IdProductoColor = x.IdProductoColor })
                .ToList();
            pro.ProductoColor.ToList().ForEach(pc =>
            {
                pc.Color = this.color.GetColorById(pc.IdColor);
            });
            return pro;
        }

        public Productos Insert(Productos entidad)
        {
            
           entidad.ProductoColor.ToList().ForEach(x =>
           {
               x.Activo = 1;
               x.FechaModificacion = DateTime.Now;
           });
            entidad.ProductoMaterial.ToList().ForEach(x =>
            {
                x.Activo = 1;
                x.FechaModificacion = DateTime.Now;
            });
            var prod = this.productosDao.Insert(entidad);
            return prod;
        }

        public void Update(Productos entidad, int id)
        {
            this.productosDao.Update(entidad, id);
        }
    }
}
