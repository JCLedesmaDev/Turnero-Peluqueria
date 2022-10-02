using System.ComponentModel.DataAnnotations;

namespace Turnero.BaseDatos.Data.Comun
{
    public class EntityBase
    {
        [Key] /// Definimos este Id como la Clave primaria.
        public int Id { get; set; }
    }
}
