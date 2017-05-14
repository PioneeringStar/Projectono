using ProjectOno.Environment;
using ProjectOno.Environment.Adaptors;
using System;
using System.Threading;

namespace ProjectOno.App.Environment.Adaptors
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