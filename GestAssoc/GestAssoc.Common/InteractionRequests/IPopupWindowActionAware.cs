using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace GestAssoc.Common.InteractionRequests
{
    public interface IPopupWindowActionAware
    {
        Window HostWindow { get; set; }

        INotification HostNotification { get; set; }
    }
}
