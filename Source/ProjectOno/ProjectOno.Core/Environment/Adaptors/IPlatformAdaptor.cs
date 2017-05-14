using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Environment.Adaptors
{
    /// <summary>
    /// A "PlatformAdaptor" should be made in each environment specific project
    /// </summary>
    public interface IPlatformAdaptor
    {
        void SetFullScreen(bool value);
        void QuitApplication();
    }
}
