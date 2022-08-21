using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string ImagenPerfil { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(8, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(10, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string DNI { get; set; }

        // Determina que esta haciendo una propiedad inversa con la propiedad
        // "Peluquero" de la clase "Turno"
        [InverseProperty("Peluquero")]
        public List<Turno> ListaTurnos { get; set; }

    }
}
