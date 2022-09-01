using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Turnero.BaseDatos.Data.Comun;

namespace Turnero.BaseDatos.Data.Entidades
{

    /*
        Clave primaria: [Index()]
        No puede existir otro turno que tenga repetido al mismo tiempo, los siguientes datos:
        - FechaTurno
        - PeluqueroId
        Es decir, puede estar existir un turno con la misma FechaTurno pero tiene que ser con otro Peluquero
        o viceversa.
    
        Clave Foranea: [ForeignKey("PeluqueroId")]
        La dupla de poner un campo Int PeluqueriaId y luego otro campo Peluquero Peluquero, es para que la BD me traiga
        los datos que coincidan con PeluqueriaId
        De esta manera, generamos las claves foraneas, las cuales me permitiran hacer las 
        relaciones entre las diferentes tablas.
     
    */

    [Index(
        nameof(FechaTurnoReservado),
        nameof(PeluqueroId),
        Name = "TurnoFechaPeluquero",
        IsUnique = true)]
    public class Turno : EntityBase
    {
        public int PeluqueroId { get; set; }
        public int ClienteId { get; set; }
        
        // Momento en el que se reserva el turno
        public DateTime FechaCreacionTurno { get; set; } 
        
        // Horario inicial del corte
        public DateTime FechaTurnoReservado { get; set; }

        // Horario final del corte. ( FechaTurnoReservado + 30 min )
        public DateTime FechaTurnoReservadoFinal { get; set; } 

        [ForeignKey("PeluqueroId")]
        public Peluquero Peluquero { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

    }
}

