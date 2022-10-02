using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Turnero.BaseDatos.Data.Comun;

namespace Turnero.BaseDatos.Data.Entidades
{
    [Index(
    nameof(DNI),
    Name = "PeluqueroDNI_UQ",
    IsUnique = true)]
    public class Peluquero : EntityBase
    {
        public string Nombre { get; set; }
        public string ImagenPerfil { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string DNI { get; set; }

        // Determina que esta haciendo una propiedad inversa con la propiedad
        // "Peluquero" de la clase "Turno"
        [InverseProperty("Peluquero")]
        public List<Turno> ListaTurnos { get; set; }

    }
}
