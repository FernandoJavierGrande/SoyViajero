﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoyViajero.BBDD.Data;

#nullable disable

namespace SoyViajero.BBDD.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SoyViajero.BBDD.Data.Entidades.Cuenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("TipoDeCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("SoyViajero.BBDD.Data.Entidades.CuentaHostel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "CuentaId" }, "CuentaId_UQ")
                        .IsUnique();

                    b.ToTable("CuentasHostel");
                });

            modelBuilder.Entity("SoyViajero.BBDD.Data.Entidades.CuentaViajero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "CuentaId" }, "CuentaId_UQ")
                        .IsUnique()
                        .HasDatabaseName("CuentaId_UQ1");

                    b.ToTable("CuentasViajeros");
                });

            modelBuilder.Entity("SoyViajero.BBDD.Data.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SoyViajero.BBDD.Data.Entidades.Cuenta", b =>
                {
                    b.HasOne("SoyViajero.BBDD.Data.Entidades.Usuario", null)
                        .WithMany("cuentas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoyViajero.BBDD.Data.Entidades.CuentaHostel", b =>
                {
                    b.HasOne("SoyViajero.BBDD.Data.Entidades.Cuenta", "Cuenta")
                        .WithMany()
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("SoyViajero.BBDD.Data.Entidades.CuentaViajero", b =>
                {
                    b.HasOne("SoyViajero.BBDD.Data.Entidades.Cuenta", "Cuenta")
                        .WithMany()
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("SoyViajero.BBDD.Data.Entidades.Usuario", b =>
                {
                    b.Navigation("cuentas");
                });
#pragma warning restore 612, 618
        }
    }
}
