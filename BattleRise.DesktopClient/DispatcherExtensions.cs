using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BattleRise.DesktopClient
{
    public static class DispatcherExtensions
    {
        public static void Do(this DispatcherObject dispatcherObject, Action action)
        {
            if (dispatcherObject.CheckAccess())
                action();
            else
                dispatcherObject.Dispatcher.Invoke(action);
        }
    }
}
