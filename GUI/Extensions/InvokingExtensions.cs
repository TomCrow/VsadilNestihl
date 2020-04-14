using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.Extensions
{
    public static class InvokingExtensions
    {
        public static void InvokeIfRequired(this System.ComponentModel.ISynchronizeInvoke obj, System.Windows.Forms.MethodInvoker action)
        {
            if (obj.InvokeRequired)
            {
                var args = new object[0];
                obj.Invoke(action, args);
            }
            else
            {
                action();
            }
        }
    }
}
