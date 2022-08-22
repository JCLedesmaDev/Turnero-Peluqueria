using Microsoft.EntityFrameworkCore;
using Turnero.BaseDatos.Data.Entidades;

namespace Turnero.BaseDatos.Data
{
    public class BDContext : DbContext
    {
        public BDContext(
            DbContextOptions<BDContext> options
        ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peluquero>().HasData(
               new Peluquero
               {
                   Id = 11,
                   Nombre = "David",
                   Apellido = "Gonzales",
                   DNI = "35.214.872",
                   ImagenPerfil = "",
                   Password = "ASD"
               },
               new Peluquero
               {
                   Id = 23,
                   Nombre = "Eduardo",
                   Apellido = "Del Valle",
                   DNI = "25.214.872",
                   ImagenPerfil = "",
                   Password = "ASD"
               }
            );

            modelBuilder.Entity<Turno>().HasData(
                new Turno
                {
                    Id=1, 
                    ClienteId=1234,
                    FechaCreacion= new DateTime(), 
                    FechaTurno=new DateTime(2022, 8, 22, 17, 30, 00),
                    PeluqueroId= 11,                    
                },
                new Turno
                {
                    Id = 2,
                    ClienteId = 3456,
                    FechaCreacion = new DateTime(),
                    FechaTurno = new DateTime(2022, 9, 22, 17, 30, 00),
                    PeluqueroId = 11
                },
                new Turno
                {
                    Id = 3,
                    ClienteId = 2345,
                    FechaCreacion = new DateTime(),
                    FechaTurno = new DateTime(2022, 9, 22, 17, 30, 00),
                    PeluqueroId = 23
                }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id=1234, Nombre = "Mariano",
                    Apellido="Cejas", NumeroTelefono="123123123",
                },
                new Cliente
                {
                    Id = 3456, Nombre = "Nacho",
                    Apellido = "Aguada", NumeroTelefono = "35124789",
                },
                new Cliente
                {
                    Id = 2345, Nombre = "Tincho",
                    Apellido = "Marin", NumeroTelefono = "435645323",
                } 
            );

        }

        public DbSet<Turno> TablaTurnos { get; set; }
        public DbSet<Cliente> TablaClientes { get; set; }
        public DbSet<Peluquero> TablaPeluqueros { get; set; }

    }
}
