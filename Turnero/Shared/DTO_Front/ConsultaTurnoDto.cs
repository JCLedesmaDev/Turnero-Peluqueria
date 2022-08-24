using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
