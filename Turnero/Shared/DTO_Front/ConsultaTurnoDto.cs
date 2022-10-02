using System.ComponentModel.DataAnnotations;

namespace Turnero.Shared.DTO_Front
{
    public class ConsultaTurnoDto
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int IdPeluquero { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public DateTime FechaHoraCorte { get; set; }
    }
}
