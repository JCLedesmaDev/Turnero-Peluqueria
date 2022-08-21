using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string Nombre { get; set; } = String.Empty;

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string Apellido { get; set; } = String.Empty;

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(9, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(20, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string NumeroTelefono { get; set; } = String.Empty;

        /// TODO: Agregar prop de Email.

        // Determina que esta haciendo una propiedad inversa con la propiedad
        // "Cliente" de la clase "Turno"
        [InverseProperty("Cliente")] 
        public List<Turno> ListaTurnos { get; set; }
    }
} 