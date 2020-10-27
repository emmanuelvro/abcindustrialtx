using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO
{
    public partial class AbcIndustrialDbContext : DbContext
    {
        public AbcIndustrialDbContext()
        {
        }

        public AbcIndustrialDbContext(DbContextOptions<AbcIndustrialDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatCalibre> CatCalibre { get; set; }
        public virtual DbSet<CatColores> CatColores { get; set; }
        public virtual DbSet<CatHilosMateriales> CatHilosMateriales { get; set; }
        public virtual DbSet<CatPresentacion> CatPresentacion { get; set; }
        public virtual DbSet<CatUsuario> CatUsuario { get; set; }
        public virtual DbSet<ColoresProductos> ColoresProductos { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<DetallesLogs> DetallesLogs { get; set; }
        public virtual DbSet<HilosExistenciaMateriales> HilosExistenciaMateriales { get; set; }
        public virtual DbSet<HilosExistencias> HilosExistencias { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<ProductoPresentacion> ProductoPresentacion { get; set; }
        public virtual DbSet<ProductosMateriales> ProductosMateriales { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TblProducto> TblProducto { get; set; }
        public virtual DbSet<UsuarioRoles> UsuarioRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=abcindustrial_db");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatCalibre>(entity =>
            {
                entity.HasKey(e => e.IdCalibre)
                    .HasName("PRIMARY");

                entity.ToTable("cat_calibre");

                entity.Property(e => e.IdCalibre)
                    .HasColumnName("id_calibre")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<CatColores>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PRIMARY");

                entity.ToTable("cat_colores");

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_color")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fecha_alta")
                    .HasColumnType("date");

                entity.Property(e => e.HexadecimalColor)
                    .IsRequired()
                    .HasColumnName("hexadecimal_color")
                    .HasMaxLength(6);

                entity.Property(e => e.NombreDesc)
                    .IsRequired()
                    .HasColumnName("nombre_desc")
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<CatHilosMateriales>(entity =>
            {
                entity.HasKey(e => e.IdMateriales)
                    .HasName("PRIMARY");

                entity.ToTable("cat_hilos_materiales");

                entity.Property(e => e.IdMateriales)
                    .HasColumnName("id_materiales")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.ColorMaterial)
                    .IsRequired()
                    .HasColumnName("color_material")
                    .HasMaxLength(85);

                entity.Property(e => e.NombreMaterial)
                    .IsRequired()
                    .HasColumnName("nombre_material")
                    .HasMaxLength(85);
            });

            modelBuilder.Entity<CatPresentacion>(entity =>
            {
                entity.HasKey(e => e.IdPresentacion)
                    .HasName("PRIMARY");

                entity.ToTable("cat_presentacion");

                entity.Property(e => e.IdPresentacion)
                    .HasColumnName("id_presentacion")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo).HasColumnType("tinyint unsigned");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.PresentaciónDesc)
                    .HasColumnName("presentación_desc")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<CatUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("cat_usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(100);

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100);

                entity.Property(e => e.UsrActivo)
                    .HasColumnName("usr_activo")
                    .HasColumnType("tinyint unsigned");
            });

            modelBuilder.Entity<ColoresProductos>(entity =>
            {
                entity.HasKey(e => e.IdcoloresProductos)
                    .HasName("PRIMARY");

                entity.ToTable("colores_productos");

                entity.HasIndex(e => e.IdColor)
                    .HasName("fk_colores_productos_cat_colores1_idx");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("fk_colores_productos_tbl_producto1_idx");

                entity.Property(e => e.IdcoloresProductos)
                    .HasColumnName("idcolores_productos")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_color")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.ColoresProductos)
                    .HasForeignKey(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_colores_productos_cat_colores1");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ColoresProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_colores_productos_tbl_producto1");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetallePedido)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_pedido");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("fk_detalle_pedido_Pedidos1_idx");

                entity.Property(e => e.IdDetallePedido)
                    .HasColumnName("id_detalle_pedido")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("id_pedido")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedido)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalle_pedido_Pedidos1");
            });

            modelBuilder.Entity<DetallesLogs>(entity =>
            {
                entity.HasKey(e => e.IdLogs)
                    .HasName("PRIMARY");

                entity.ToTable("detalles_logs");

                entity.Property(e => e.IdLogs)
                    .HasColumnName("id_logs")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdTransaccion)
                    .IsRequired()
                    .HasColumnName("id_transaccion")
                    .HasMaxLength(15);

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.NombreTabla)
                    .IsRequired()
                    .HasColumnName("nombre_tabla")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HilosExistenciaMateriales>(entity =>
            {
                entity.HasKey(e => e.IdMateriales)
                    .HasName("PRIMARY");

                entity.ToTable("hilos_existencia_materiales");

                entity.HasIndex(e => e.IdMateriales)
                    .HasName("fk_hilos_existencia_composicion_hilos_composicion1_idx");

                entity.Property(e => e.IdMateriales)
                    .HasColumnName("id_materiales")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdMaterialesNavigation)
                    .WithOne(p => p.HilosExistenciaMateriales)
                    .HasForeignKey<HilosExistenciaMateriales>(d => d.IdMateriales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hilos_existencia_composicion_hilos_composicion1");
            });

            modelBuilder.Entity<HilosExistencias>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PRIMARY");

                entity.ToTable("hilos_existencias");

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_color")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CantidadBobinas)
                    .HasColumnName("cantidad_bobinas")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CantidadExistente)
                    .HasColumnName("cantidad_existente")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithOne(p => p.HilosExistencias)
                    .HasForeignKey<HilosExistencias>(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hilos_existencias_hilos_colores");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedidos");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("id_pedido")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithOne(p => p.Pedidos)
                    .HasForeignKey<Pedidos>(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pedidos_tbl_producto1");
            });

            modelBuilder.Entity<ProductoPresentacion>(entity =>
            {
                entity.HasKey(e => e.IdproductoPresentacion)
                    .HasName("PRIMARY");

                entity.ToTable("producto_presentacion");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("fk_producto_presentacion_tbl_producto1_idx");

                entity.Property(e => e.IdproductoPresentacion)
                    .HasColumnName("idproducto_presentacion")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.IdPresentacion)
                    .HasColumnName("id_presentacion")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductoPresentacion)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_presentacion_tbl_producto1");

                entity.HasOne(d => d.IdproductoPresentacionNavigation)
                    .WithOne(p => p.ProductoPresentacion)
                    .HasForeignKey<ProductoPresentacion>(d => d.IdproductoPresentacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_presentacion_cat_presentacion1");
            });

            modelBuilder.Entity<ProductosMateriales>(entity =>
            {
                entity.HasKey(e => e.IdproductosMateriales)
                    .HasName("PRIMARY");

                entity.ToTable("productos_materiales");

                entity.HasIndex(e => e.IdMateriales)
                    .HasName("fk_productos_materiales_cat_hilos_materiales1_idx");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("fk_productos_materiales_tbl_producto1_idx");

                entity.Property(e => e.IdproductosMateriales)
                    .HasColumnName("idproductos_materiales")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("tinyint unsigned");

                entity.Property(e => e.IdMateriales)
                    .HasColumnName("id_materiales")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdMaterialesNavigation)
                    .WithMany(p => p.ProductosMateriales)
                    .HasForeignKey(d => d.IdMateriales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productos_materiales_cat_hilos_materiales1");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductosMateriales)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productos_materiales_tbl_producto1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasColumnName("nombre_rol")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TblProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_producto");

                entity.HasIndex(e => e.IdCalibre)
                    .HasName("fk_tbl_producto_cat_calibre1_idx");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(250);

                entity.Property(e => e.IdCalibre)
                    .HasColumnName("id_calibre")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_color")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdCalibreNavigation)
                    .WithMany(p => p.TblProducto)
                    .HasForeignKey(d => d.IdCalibre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbl_producto_cat_calibre1");
            });

            modelBuilder.Entity<UsuarioRoles>(entity =>
            {
                entity.HasKey(e => new { e.IdRol, e.IdUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("usuario_roles");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_usuario_roles_cat_usuario1");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_roles_cat_usuario1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
