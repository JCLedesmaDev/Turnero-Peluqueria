using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Turnero.BaseDatos.Data.Comun;

namespace Turnero.BaseDatos.Data.Entidades
{
    [Index(
        nameof(NumeroTelefono),
        Name = "ClienteNumeroTelefono_UQ",
        IsUnique = true)]

    public class Cliente : EntityBase
    {
        public string Nombre { get; set; } = String.Empty;
        public string Apellido { get; set; } = String.Empty;
        public string NumeroTelefono { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        // Determina que esta haciendo una propiedad inversa con la propiedad
        // "Cliente" de la clase "Turno"
        [InverseProperty("Cliente")]
        public List<Turno> ListaTurnos { get; set; }
    }
}