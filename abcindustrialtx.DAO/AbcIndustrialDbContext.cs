using System;
using abcindustrialtx.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<ExistenciaMateriales> ExistenciaMateriales { get; set; }
        public virtual DbSet<HilosExistencias> HilosExistencias { get; set; }
        public virtual DbSet<HilosProductoMaterial> HilosProductoMaterial { get; set; }
        public virtual DbSet<HilosProductos> HilosProductos { get; set; }
        public virtual DbSet<HilosProductosPedidos> HilosProductosPedidos { get; set; }
        public virtual DbSet<ProductoPresentacion> ProductoPresentacion { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosRoles> UsuariosRoles { get; set; }

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
                    .HasColumnType("bit(1)");
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

                entity.Property(e => e.HexadecimalColor)
                    .IsRequired()
                    .HasColumnName("hexadecimal_color")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
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

                entity.Property(e => e.ColorMaterial)
                    .IsRequired()
                    .HasColumnName("color_material")
                    .HasMaxLength(100);

                entity.Property(e => e.NombreMaterial)
                    .IsRequired()
                    .HasColumnName("nombre_material")
                    .HasMaxLength(100);
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
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Presentacion)
                    .IsRequired()
                    .HasColumnName("presentacion")
                    .HasMaxLength(250);
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

                entity.Property(e => e.AuditType)
                    .IsRequired()
                    .HasColumnName("audit_type")
                    .HasMaxLength(50);

                entity.Property(e => e.AuditUsername)
                    .IsRequired()
                    .HasColumnName("audit_username")
                    .HasMaxLength(100);

                entity.Property(e => e.ChangedColumns)
                    .HasColumnName("changed_columns")
                    .HasMaxLength(0);

                entity.Property(e => e.KeyValues)
                    .HasColumnName("key_values")
                    .HasMaxLength(250);

                entity.Property(e => e.NewValues)
                    .HasColumnName("new_values")
                    .HasMaxLength(0);

                entity.Property(e => e.OldValues)
                    .HasColumnName("old_values")
                    .HasMaxLength(0);

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<ExistenciaMateriales>(entity =>
            {
                entity.HasKey(e => e.IdExistenciaMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("existencia_materiales");

                entity.HasIndex(e => e.IdMaterial)
                    .HasName("IXFK_existencia_materiales_cat_material");

                entity.Property(e => e.IdExistenciaMaterial)
                    .HasColumnName("id_existencia_material")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("fecha_modificacion")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("id_material")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.ExistenciaMateriales)
                    .HasForeignKey(d => d.IdMaterial)
                    .HasConstraintName("FK_existencia_materiales_cat_material");
            });

            modelBuilder.Entity<HilosExistencias>(entity =>
            {
                entity.HasKey(e => e.IdExistencia)
                    .HasName("PRIMARY");

                entity.ToTable("hilos_existencias");

                entity.Property(e => e.IdExistencia)
                    .HasColumnName("id_existencia")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CantidadBobinas).HasColumnName("cantidad_bobinas");

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_color")
                    .HasColumnType("int unsigned");
            });

            modelBuilder.Entity<HilosProductoMaterial>(entity =>
            {
                entity.HasKey(e => new { e.IdHilosproducto, e.IdMaterial })
                    .HasName("PRIMARY");

                entity.ToTable("hilos_producto_material");

                entity.HasIndex(e => e.IdHilosproducto)
                    .HasName("IXFK_hilos_producto_material_hilos_productos");

                entity.HasIndex(e => e.IdMaterial)
                    .HasName("IXFK_hilos_producto_material_cat_material");

                entity.Property(e => e.IdHilosproducto)
                    .HasColumnName("id_hilosproducto")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("id_material")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");

                entity.HasOne(d => d.IdHilosproductoNavigation)
                    .WithMany(p => p.HilosProductoMaterial)
                    .HasForeignKey(d => d.IdHilosproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_hilos_producto_material_hilos_productos");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.HilosProductoMaterial)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_hilos_producto_material_cat_material");
            });

            modelBuilder.Entity<HilosProductos>(entity =>
            {
                entity.HasKey(e => e.IdHilosproducto)
                    .HasName("PRIMARY");

                entity.ToTable("hilos_productos");

                entity.HasIndex(e => e.IdCalibre)
                    .HasName("IXFK_hilos_productos_cat_calibre");

                entity.HasIndex(e => e.IdColor)
                    .HasName("IXFK_hilos_productos_cat_colores");

                entity.HasIndex(e => e.IdExistencia)
                    .HasName("IXFK_hilos_productos_hilos_existencias");

                entity.Property(e => e.IdHilosproducto)
                    .HasColumnName("id_hilosproducto")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.IdCalibre)
                    .HasColumnName("id_calibre")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdColor)
                    .HasColumnName("id_color")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdExistencia)
                    .HasColumnName("id_existencia")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.PorcentajeColor)
                    .HasColumnName("porcentaje_color")
                    .HasColumnType("decimal(3,0)");

                entity.HasOne(d => d.IdCalibreNavigation)
                    .WithMany(p => p.HilosProductos)
                    .HasForeignKey(d => d.IdCalibre)
                    .HasConstraintName("FK_hilos_productos_cat_calibre");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.HilosProductos)
                    .HasForeignKey(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_hilos_productos_cat_colores");

                entity.HasOne(d => d.IdExistenciaNavigation)
                    .WithMany(p => p.HilosProductos)
                    .HasForeignKey(d => d.IdExistencia)
                    .HasConstraintName("FK_hilos_productos_hilos_existencias");
            });

            modelBuilder.Entity<HilosProductosPedidos>(entity =>
            {
                entity.HasKey(e => e.IdDetallePedido)
                    .HasName("PRIMARY");

                entity.ToTable("hilos_productos_pedidos");

                entity.HasIndex(e => e.IdHilosproducto)
                    .HasName("IXFK_hilos_productos_pedidos_hilos_productos");

                entity.Property(e => e.IdDetallePedido)
                    .HasColumnName("id_detalle_pedido")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.IdHilosproducto)
                    .HasColumnName("id_hilosproducto")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdHilosproductoNavigation)
                    .WithMany(p => p.HilosProductosPedidos)
                    .HasForeignKey(d => d.IdHilosproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_hilos_productos_pedidos_hilos_productos");
            });

            modelBuilder.Entity<ProductoPresentacion>(entity =>
            {
                entity.HasKey(e => new { e.IdPresentacion, e.IdHilosproducto })
                    .HasName("PRIMARY");

                entity.ToTable("producto_presentacion");

                entity.HasIndex(e => e.IdHilosproducto)
                    .HasName("IXFK_producto_presentacion_hilos_productos");

                entity.HasIndex(e => e.IdPresentacion)
                    .HasName("IXFK_producto_presentacion_cat_presentacion");

                entity.Property(e => e.IdPresentacion)
                    .HasColumnName("id_presentacion")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdHilosproducto)
                    .HasColumnName("id_hilosproducto")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)");

                entity.HasOne(d => d.IdHilosproductoNavigation)
                    .WithMany(p => p.ProductoPresentacion)
                    .HasForeignKey(d => d.IdHilosproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_producto_presentacion_hilos_productos");

                entity.HasOne(d => d.IdPresentacionNavigation)
                    .WithMany(p => p.ProductoPresentacion)
                    .HasForeignKey(d => d.IdPresentacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_producto_presentacion_cat_presentacion");
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
                    .HasMaxLength(50);
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
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasColumnName("password_hash");

                entity.Property(e => e.PasswordSalt).HasColumnName("password_salt");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(10);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100);

                entity.Property(e => e.UsrActivo)
                    .HasColumnName("usr_activo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fecha_alta")
                    .HasColumnType("date");
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
