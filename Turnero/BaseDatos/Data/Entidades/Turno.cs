﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    nameof(FechaTurno),
    nameof(PeluqueroId),
    Name = "TurnoFechaPeluquero",
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

