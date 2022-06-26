using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnero.Shared;

namespace Turnero.BaseDatos
{
    public class BDContext: DbContext
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
