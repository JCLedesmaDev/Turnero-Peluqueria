using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnero.Shared.DTO_Back.Peluquero
{
    public class PeluqueroData
    {
        public int Id { get; set; }  
        public string ImagenPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
    }

}
