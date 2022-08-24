using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Turnero.Shared.Comun;

namespace Turnero.Helper
{
    public class ErrorHelper
    {
        public static List<ModelErrors> GetModelStateErrors(ModelStateDictionary Model)
        {
            return Model.Select(x=> new ModelErrors(){ 
                Key = x.Key,
                Messages = x.Value.Errors.Select(y => y.ErrorMessage).ToList()
            }).ToList();
        }
    }

}