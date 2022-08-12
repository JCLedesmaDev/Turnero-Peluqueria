using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(9, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(20, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string NumeroTelefono { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int TurnoId { get; set; }

        /// TODO: Agregar prop de Email.


        [ForeignKey("TurnoId")]
        public Turno Turno { get; set; }
    }
}