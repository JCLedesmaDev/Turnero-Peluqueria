using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnero.Shared.Comun;

namespace Turnero.Shared.DTO_Back
{
    public class ResponseDto<TypeData>
    {
        public TypeData Data { get; set; }
        public List<ModelErrors> ErrorModels { get; set; }
        public string MessageError { get; set; }
    }
}
