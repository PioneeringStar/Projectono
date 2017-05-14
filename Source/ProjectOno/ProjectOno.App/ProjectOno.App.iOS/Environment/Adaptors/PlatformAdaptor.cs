using ProjectOno.Environment;
using ProjectOno.Environment.Adaptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Foundation;
using UIKit;

namespace ProjectOno.Environment.Adaptors
{
    [Dependency.Transient]
    public class PlatformAdaptor : IPlatformAdaptor
    {
        public void QuitApplication()
        {
            Thread.CurrentThread.Abort();
        }

        public void SetFullScreen(bool value)
        {
            throw new NotImplementedException();
        }
    }
}