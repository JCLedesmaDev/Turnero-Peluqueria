using Turnero.Client.Models;

namespace Turnero.Client.StoreGlobal
{
    public class GlobalState
    {
        public bool ShowLoader { get; set; }
        public ModalModels? MessageModal { get; set; }
    }
}
