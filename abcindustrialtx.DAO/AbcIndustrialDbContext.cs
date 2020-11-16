using abcindustrialtx.Entities;
using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<CatMaterial> CatMaterial { get; set; }
        public virtual DbSet<CatPresentacion> CatPresentacion { get; set; }
        public virtual DbSet<DetallesLogs> DetallesLogs { get; set; }
        public virtual DbSet<ProductoMaterial> ProductoPresentacion { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosRoles> UsuariosRoles { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<ProductoColor> ProductoColor { get; set; }
        public virtual DbSet<Pedidos> Pedido { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=abcindustrial_db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedidos");

                entity.Property(e => e.IdPedido)
                    .HasColumnName("id_pedido")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("nombre_cliente")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdStatus)
                    .HasColumnName("id_status")
                    .HasColumnType("int");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int");
               
                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");
                entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_pedido");

                entity.Property(e => e.IdDetalle)
                    .HasColumnName("id_detalle")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasColumnName("observaciones")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdPedido)
                    .HasColumnName("id_pedido")
                    .HasColumnType("int");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int");

                entity.HasOne(d => d.Pedido)
                   .WithMany(p => p.DetallePedido)
                   .HasForeignKey(d => d.IdPedido)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_detalle_pedido_pedidos_id_pedido");

                entity.HasOne(d => d.Producto)
                   .WithMany(p => p.DetallePedido)
                   .HasForeignKey(d => d.IdProducto)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_detalle_cat_productos_id_producto");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");
                entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("cat_productos");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdCalibre)
                    .HasColumnName("id_calibre")
                    .HasColumnType("int");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdPresentacion)
                    .HasColumnName("id_presentacion")
                    .HasColumnType("int");

                entity.HasOne(d => d.Calibre)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCalibre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cat_productos_cat_calibres_id_calibre");

                entity.HasOne(d => d.Presentacion)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdPresentacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cat_productos_cat_presentacion_id_presentacion");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");
                entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            });


            modelBuilder.Entity<ProductoColor>(entity =>
            {
                entity.HasKey(e => e.IdProductoColor)
                    .HasName("PRIMARY");

                entity.ToTable("producto_color");

                entity.Property(e => e.IdProductoColor)
                    .HasColumnName("id_prod_color")
                    .HasColumnType("int");

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_color")
                    .HasColumnType("int");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int");

                entity.Property(e => e.Porcentaje)
                    .HasColumnName("porcentaje")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");

                entity.HasOne<CatColores>(d => d.Color)
                   .WithMany(p => p.ProductoColor)
                   .HasForeignKey(d => d.IdColor);

                entity.HasOne(d => d.Producto)
                   .WithMany(p => p.ProductoColor)
                   .HasForeignKey(d => d.IdProducto)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_producto_color_cat_productos_id_producto");
            });

            modelBuilder.Entity<ProductoMaterial>(entity =>
            {
                entity.HasKey(e => e.IdProductoMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("producto_material");

                entity.Property(e => e.IdProductoMaterial)
                    .HasColumnName("id_prod_material")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("id_material")
                    .HasColumnType("int");

                entity.HasOne <CatMaterial>(d => d.Material)
                   .WithMany(p => p.ProductoMaterial)
                   .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_producto_material_cat_material_id_material");

                entity.HasOne(d => d.Producto)
                  .WithMany(p => p.ProductoMaterial)
                  .HasForeignKey(d => d.IdProducto)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_producto_material_cat_productos_id_producto");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");
                entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            });
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
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Calibre)
                    .HasColumnName("calibre")
                    .HasColumnType("decimal(10,2) unsigned");

                entity.HasMany(e => e.Productos)
                .WithOne(s => s.Calibre)
                .HasForeignKey(s => s.IdCalibre).IsRequired();

                entity.Property(e => e.FechaModificacion).HasColumnName("fecha_modificacion");
            });

            modelBuilder.Entity<CatColores>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PRIMARY");

                entity.ToTable("cat_colores");

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_color")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FechaAlta).HasColumnName("fecha_alta");

                entity.Property(e => e.HexadecimalColor)
                    .IsRequired()
                    .HasColumnName("hexadecimal_color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatMaterial>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("cat_material");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("id_material")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FechaAlta).HasColumnName("fecha_alta");

                entity.Property(e => e.NombreMaterial)
                    .IsRequired()
                    .HasColumnName("nombre_material")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatPresentacion>(entity =>
            {
                entity.HasKey(e => e.IdPresentacion)
                    .HasName("PRIMARY");

                entity.ToTable("cat_presentacion");

                entity.Property(e => e.IdPresentacion)
                    .HasColumnName("id_presentacion")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("decimal(10,2) unsigned");

                entity.Property(e => e.FechaAlta).HasColumnName("fecha_alta");

                entity.Property(e => e.Presentacion)
                    .IsRequired()
                    .HasColumnName("presentacion")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallesLogs>(entity =>
            {
                entity.HasKey(e => e.IdLogs)
                    .HasName("PRIMARY");

                entity.ToTable("detalles_logs");

                entity.Property(e => e.IdLogs)
                    .HasColumnName("id_logs")
                    .HasMaxLength(36)
                    .IsFixedLength();

                entity.Property(e => e.AuditDatetimeUtc).HasColumnName("audit_datetime_utc");

                entity.Property(e => e.AuditType)
                    .IsRequired()
                    .HasColumnName("audit_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AuditUsername)
                    .IsRequired()
                    .HasColumnName("audit_username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChangedColumns)
                    .HasColumnName("changed_columns")
                    .HasMaxLength(0)
                    .IsUnicode(false);

                entity.Property(e => e.KeyValues)
                    .HasColumnName("key_values")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NewValues)
                    .HasColumnName("new_values")
                    .HasMaxLength(0)
                    .IsUnicode(false);

                entity.Property(e => e.OldValues)
                    .HasColumnName("old_values")
                    .HasMaxLength(0)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(150)
                    .IsUnicode(false);
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
                    .HasColumnName("nombre_rol")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.CorreoElectronico)
                    .HasColumnName("correo_electronico")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnName("fecha_alta");

                entity.Property(e => e.PasswordHash).HasColumnName("password_hash");

                entity.Property(e => e.PasswordSalt).HasColumnName("password_salt");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsrActivo)
                    .HasColumnName("usr_activo")
                    .HasColumnType("bit(1)");
            });

            modelBuilder.Entity<UsuariosRoles>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdRol })
                    .HasName("PRIMARY");

                entity.ToTable("usuarios_roles");

                entity.HasIndex(e => e.IdRol)
                    .HasName("IXFK_usuarios_roles_roles");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IXFK_usuarios_roles_usuarios");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarios_roles_roles");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarios_roles_usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
