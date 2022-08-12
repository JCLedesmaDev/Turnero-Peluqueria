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


        public DbSet<Turno> TablaTurnos { get; set; }
        public DbSet<Cliente> TablaClientes { get; set; }
        public DbSet<Peluquero> TablaPeluqueros { get; set; }



    }
}
