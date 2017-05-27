using Projectono.Environment;
using Projectono.Environment.Adaptors;
using System;
using Windows.ApplicationModel.Core;

namespace Projectono.App.Environment.Adaptors
{
    [Dependency.Transient]
    public class PlatformAdaptor : IPlatformAdaptor
    {
		public void QuitApplication()
		{
            CoreApplication.Exit();
		}

		public void SetFullScreen(bool value)
		{
			throw new NotImplementedException();
		}
	}
}
