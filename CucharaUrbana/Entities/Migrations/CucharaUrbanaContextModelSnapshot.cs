﻿// <auto-generated />
using System;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(CucharaUrbanaContext))]
    partial class CucharaUrbanaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Entities.Carrito", b =>
                {
                    b.Property<int>("CarritoId")
                        .HasColumnType("int")
                        .HasColumnName("CarritoID");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("ProductoID");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("CarritoId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Carrito", (string)null);
                });

            modelBuilder.Entity("Entities.Entities.Categorium", b =>
                {
                    b.Property<int>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("CategoriaID");

                    b.Property<string>("Nombre")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("CategoriaId")
                        .HasName("PK__Categori__F353C1C53D894E2D");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Entities.Entities.DetalleFactura", b =>
                {
                    b.Property<int>("DetalleId")
                        .HasColumnType("int")
                        .HasColumnName("DetalleID");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("FacturaId")
                        .HasColumnType("int")
                        .HasColumnName("FacturaID");

                    b.Property<string>("NombreProducto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("ProductoID");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("TipoPagoId")
                        .HasColumnType("int")
                        .HasColumnName("TipoPagoID");

                    b.HasKey("DetalleId")
                        .HasName("PK__DetalleF__6E19D6FA5E70F24F");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("TipoPagoId");

                    b.ToTable("DetalleFactura", (string)null);
                });

            modelBuilder.Entity("Entities.Entities.Factura", b =>
                {
                    b.Property<int>("FacturaId")
                        .HasColumnType("int")
                        .HasColumnName("FacturaID");

                    b.Property<string>("EstadoPago")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("date");

                    b.Property<int?>("MetodoPagoId")
                        .HasColumnType("int")
                        .HasColumnName("MetodoPagoID");

                    b.Property<int?>("PagoId")
                        .HasColumnType("int")
                        .HasColumnName("PagoID");

                    b.Property<int?>("TipoPagoId")
                        .HasColumnType("int")
                        .HasColumnName("TipoPagoID");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("FacturaId");

                    b.HasIndex("MetodoPagoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("Entities.Entities.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int")
                        .HasColumnName("PedidoID");

                    b.Property<string>("EstadoPedido")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime");

                    b.Property<int>("MesaPedido")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("ProductoID");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("PedidoId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Entities.Entities.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("ProductoID");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("CategoriaID");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Entities.Entities.Reservacion", b =>
                {
                    b.Property<int>("ReservacionId")
                        .HasColumnType("int")
                        .HasColumnName("ReservacionID");

                    b.Property<int>("DetalleReservacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaReservacion")
                        .HasColumnType("datetime");

                    b.Property<TimeSpan>("HoraReservacion")
                        .HasColumnType("time");

                    b.Property<int>("MesaReservacion")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("ReservacionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservacion", (string)null);
                });

            modelBuilder.Entity("Entities.Entities.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .HasColumnType("int")
                        .HasColumnName("RolID");

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RolId");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Entities.Entities.TipoPago", b =>
                {
                    b.Property<int>("MetodoPagoId")
                        .HasColumnType("int")
                        .HasColumnName("MetodoPagoID");

                    b.Property<string>("TipoPago1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TipoPago");

                    b.HasKey("MetodoPagoId")
                        .HasName("PK__TipoPago__A8FEAF7443AD9EAE");

                    b.ToTable("TipoPago", (string)null);
                });

            modelBuilder.Entity("Entities.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RolId")
                        .HasColumnType("int")
                        .HasColumnName("RolID");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RolId");

                    b.HasIndex(new[] { "CorreoElectronico" }, "UQ__Usuario__531402F397573C75")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Entities.Utilities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Entities.Carrito", b =>
                {
                    b.HasOne("Entities.Entities.Producto", "Producto")
                        .WithMany("Carritos")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("fk_ProductoID_Carrito");

                    b.HasOne("Entities.Entities.Usuario", "Usuario")
                        .WithMany("Carritos")
                        .HasForeignKey("UsuarioId")
                        .IsRequired()
                        .HasConstraintName("fk_UsuarioID_Carrito");

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Entities.DetalleFactura", b =>
                {
                    b.HasOne("Entities.Entities.Factura", "Factura")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("FacturaId")
                        .HasConstraintName("fk_FacturaID_DetalleFactura");

                    b.HasOne("Entities.Entities.Producto", "Producto")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("fk_ProductoID_DetalleFactura");

                    b.HasOne("Entities.Entities.TipoPago", "TipoPago")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("TipoPagoId")
                        .HasConstraintName("fk_TipoPagoID_DetalleFactura");

                    b.Navigation("Factura");

                    b.Navigation("Producto");

                    b.Navigation("TipoPago");
                });

            modelBuilder.Entity("Entities.Entities.Factura", b =>
                {
                    b.HasOne("Entities.Entities.TipoPago", "MetodoPago")
                        .WithMany("Facturas")
                        .HasForeignKey("MetodoPagoId")
                        .HasConstraintName("fk_MetodoPagoID_Factura");

                    b.HasOne("Entities.Entities.Usuario", "Usuario")
                        .WithMany("Facturas")
                        .HasForeignKey("UsuarioId")
                        .IsRequired()
                        .HasConstraintName("fk_UsuarioID_Factura");

                    b.Navigation("MetodoPago");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Entities.Pedido", b =>
                {
                    b.HasOne("Entities.Entities.Producto", "Producto")
                        .WithMany("Pedidos")
                        .HasForeignKey("ProductoId")
                        .HasConstraintName("fk_ProductoID_Pedidos");

                    b.HasOne("Entities.Entities.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_UsuarioID_Pedidos");

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Entities.Producto", b =>
                {
                    b.HasOne("Entities.Entities.Categorium", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("fk_CategoriaID_Producto");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Entities.Entities.Reservacion", b =>
                {
                    b.HasOne("Entities.Entities.Usuario", "Usuario")
                        .WithMany("Reservacions")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_UsuarioID_Reservacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Entities.Usuario", b =>
                {
                    b.HasOne("Entities.Entities.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .HasConstraintName("FK__Usuario__RolID__4CA06362");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Utilities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Utilities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Utilities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Utilities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Entities.Categorium", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Entities.Entities.Factura", b =>
                {
                    b.Navigation("DetalleFacturas");
                });

            modelBuilder.Entity("Entities.Entities.Producto", b =>
                {
                    b.Navigation("Carritos");

                    b.Navigation("DetalleFacturas");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Entities.Entities.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Entities.Entities.TipoPago", b =>
                {
                    b.Navigation("DetalleFacturas");

                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("Entities.Entities.Usuario", b =>
                {
                    b.Navigation("Carritos");

                    b.Navigation("Facturas");

                    b.Navigation("Pedidos");

                    b.Navigation("Reservacions");
                });
#pragma warning restore 612, 618
        }
    }
}
