using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnero.BaseDatos.Data.Comun
{
    public class EntityBase
    {
        [Key] /// Definimos este Id como la Clave primaria.
        public int Id { get; set; }
    }
}
