using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class CucharaUrbanaContext : DbContext
    {
        public CucharaUrbanaContext()
        {
        }

        public CucharaUrbanaContext(DbContextOptions<CucharaUrbanaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Reservacion> Reservacions { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<TipoPago> TipoPagos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=CucharaUrbana;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");

                entity.Property(e => e.CarritoId)
                    .ValueGeneratedNever()
                    .HasColumnName("CarritoID");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProductoID_Carrito");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UsuarioID_Carrito");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__F353C1C53D894E2D");

                entity.Property(e => e.CategoriaId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoriaID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.DetalleId)
                    .HasName("PK__DetalleF__6E19D6FA5E70F24F");

                entity.ToTable("DetalleFactura");

                entity.Property(e => e.DetalleId)
                    .ValueGeneratedNever()
                    .HasColumnName("DetalleID");

                entity.Property(e => e.FacturaId).HasColumnName("FacturaID");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TipoPagoId).HasColumnName("TipoPagoID");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("fk_FacturaID_DetalleFactura");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProductoID_DetalleFactura");

                entity.HasOne(d => d.TipoPago)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.TipoPagoId)
                    .HasConstraintName("fk_TipoPagoID_DetalleFactura");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.FacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("FacturaID");

                entity.Property(e => e.EstadoPago)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFactura).HasColumnType("date");

                entity.Property(e => e.MetodoPagoId).HasColumnName("MetodoPagoID");

                entity.Property(e => e.PagoId).HasColumnName("PagoID");

                entity.Property(e => e.TipoPagoId).HasColumnName("TipoPagoID");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.MetodoPago)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.MetodoPagoId)
                    .HasConstraintName("fk_MetodoPagoID_Factura");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UsuarioID_Factura");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.PedidoId)
                    .ValueGeneratedNever()
                    .HasColumnName("PedidoID");

                entity.Property(e => e.EstadoPedido)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPedido).HasColumnType("datetime");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("fk_ProductoID_Pedidos");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("fk_UsuarioID_Pedidos");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductoID");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("fk_CategoriaID_Producto");
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.ToTable("Reservacion");

                entity.Property(e => e.ReservacionId)
                    .ValueGeneratedNever()
                    .HasColumnName("ReservacionID");

                entity.Property(e => e.FechaReservacion).HasColumnType("datetime");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("fk_UsuarioID_Reservacion");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.RolId)
                    .ValueGeneratedNever()
                    .HasColumnName("RolID");

                entity.Property(e => e.NombreRol).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.MetodoPagoId)
                    .HasName("PK__TipoPago__A8FEAF7443AD9EAE");

                entity.ToTable("TipoPago");

                entity.Property(e => e.MetodoPagoId)
                    .ValueGeneratedNever()
                    .HasColumnName("MetodoPagoID");

                entity.Property(e => e.TipoPago1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoPago");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuario__531402F397573C75")
                    .IsUnique();

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsuarioID");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK__Usuario__RolID__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
