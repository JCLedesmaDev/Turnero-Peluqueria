using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnero.Shared
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
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string ImagenPerfil { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(2, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [MinLength(8, ErrorMessage = "Error de longuitud, minimo de {1} caracteres")]
        [MaxLength(10, ErrorMessage = "Error de longuitud, maximo de {1} caracteres")]
        public string DNI { get; set; }

        public List<Turno> ListaTurnos { get; set; }            
        
    }
}
