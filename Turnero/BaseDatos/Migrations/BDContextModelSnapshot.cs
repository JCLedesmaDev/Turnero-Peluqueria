﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Turnero.BaseDatos;

#nullable disable

namespace Turnero.BaseDatos.Migrations
{
    [DbContext(typeof(BDContext))]
    partial class BDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Turnero.Shared.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NumeroTelefono" }, "ClienteNumeroTelefono_UQ")
                        .IsUnique();

                    b.ToTable("TablaClientes");
                });

            modelBuilder.Entity("Turnero.Shared.Peluquero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ImagenPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DNI" }, "PeluqueroDNI_UQ")
                        .IsUnique();

                    b.ToTable("TablaPeluqueros");
                });

            modelBuilder.Entity("Turnero.Shared.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaTurno")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeluqueroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("PeluqueroId");

                    b.HasIndex(new[] { "FechaTurno", "PeluqueroId", "ClienteId" }, "TurnoFechaPeluqueroCliente")
                        .IsUnique();

                    b.ToTable("TablaTurnos");
                });

            modelBuilder.Entity("Turnero.Shared.Turno", b =>
                {
                    b.HasOne("Turnero.Shared.Cliente", "Cliente")
                        .WithOne("Turno")
                        .HasForeignKey("Turnero.Shared.Turno", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turnero.Shared.Peluquero", "Peluquero")
                        .WithMany("ListaTurnos")
                        .HasForeignKey("PeluqueroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Peluquero");
                });

            modelBuilder.Entity("Turnero.Shared.Cliente", b =>
                {
                    b.Navigation("Turno")
                        .IsRequired();
                });

            modelBuilder.Entity("Turnero.Shared.Peluquero", b =>
                {
                    b.Navigation("ListaTurnos");
                });
#pragma warning restore 612, 618
        }
    }
}