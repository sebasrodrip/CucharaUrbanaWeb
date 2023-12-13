using System;
using System.Collections.Generic;
using Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Entities
{
    public partial class CucharaUrbanaContext : IdentityDbContext<ApplicationUser>
    {
        public CucharaUrbanaContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<CucharaUrbanaContext>();
            optionBuilder.UseSqlServer(Util.ConnectionString);
        }

        public CucharaUrbanaContext(DbContextOptions<CucharaUrbanaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Reservacion> Reservacions { get; set; } = null!;
        public virtual DbSet<TipoPago> TipoPagos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Util.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");

                entity.Property(e => e.CarritoId).HasColumnName("CarritoID");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProductoID_Carrito");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__F353C1C5992211C5");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.FacturaId).HasColumnName("FacturaID");

                entity.Property(e => e.CarritoId).HasColumnName("CarritoID");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TipoPagoId).HasColumnName("TipoPagoID");

                entity.HasOne(d => d.Carrito)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CarritoId)
                    .HasConstraintName("fk_CarritoId_Factura");

                entity.HasOne(d => d.TipoPago)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.TipoPagoId)
                    .HasConstraintName("fk_TipoPagoID_DetalleFactura");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

                entity.Property(e => e.EstadoPedido)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPedido).HasColumnType("datetime");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("fk_ProductoID_Pedidos");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

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

                entity.Property(e => e.ReservacionId).HasColumnName("ReservacionID");

                entity.Property(e => e.FechaReservacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.MetodoPagoId)
                    .HasName("PK__TipoPago__A8FEAF74B0EEEEBE");

                entity.ToTable("TipoPago");

                entity.Property(e => e.MetodoPagoId).HasColumnName("MetodoPagoID");

                entity.Property(e => e.TipoPago1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoPago");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
