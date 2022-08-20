using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnero.Shared.DTO_Back
{
    public class Response<TypeData>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public TypeData Data { get; set; }
    }
}
