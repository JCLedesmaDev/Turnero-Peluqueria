using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turnero.Shared
{
    [Index(
    nameof(FechaTurno),
    nameof(PeluqueroId),
    nameof(ClienteId),
    Name = "TurnoFechaPeluqueroCliente",
    IsUnique = true)]
    public class Turno : EntityBase
    {
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime FechaTurno { get; set; }
        
        [Required(ErrorMessage = "Campo requerido")]
        public int PeluqueroId { get; set; }
        
        [Required(ErrorMessage = "Campo requerido")]
        public int ClienteId { get; set; }


        [ForeignKey("PeluqueroId")]
        public Peluquero Peluquero { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}

