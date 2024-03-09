﻿// <auto-generated />
using System;
using LogicaAccesoDatos.BaseDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(SGMVContext))]
    partial class SGMVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiasDemora")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRecepcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<bool>("Recibida")
                        .HasColumnType("bit");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.CompraRepuesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RepuestoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("RepuestoId");

                    b.ToTable("CompraRepuestos");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Nacional")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Repuesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompraId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Medida")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasColumnType("int");

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.ToTable("Repuestos");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.TipoRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoRoles");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Confirmacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Compra", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesNegocio.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.CompraRepuesto", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesNegocio.Compra", "Compra")
                        .WithMany("ListaCompraRepuesto")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.EntidadesNegocio.Repuesto", "Repuesto")
                        .WithMany("ListaCompraRepuesto")
                        .HasForeignKey("RepuestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Repuesto");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Proveedor", b =>
                {
                    b.OwnsOne("LogicaNegocio.ValueObject.NombreProveedor", "Nombre", b1 =>
                        {
                            b1.Property<int>("ProveedorId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("ProveedorId");

                            b1.HasIndex("Valor")
                                .IsUnique();

                            b1.ToTable("Proveedores");

                            b1.WithOwner()
                                .HasForeignKey("ProveedorId");
                        });

                    b.Navigation("Nombre")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Repuesto", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesNegocio.Compra", null)
                        .WithMany("ListaRepuestos")
                        .HasForeignKey("CompraId");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Usuario", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesNegocio.TipoRol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Compra", b =>
                {
                    b.Navigation("ListaCompraRepuesto");

                    b.Navigation("ListaRepuestos");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Repuesto", b =>
                {
                    b.Navigation("ListaCompraRepuesto");
                });
#pragma warning restore 612, 618
        }
    }
}
