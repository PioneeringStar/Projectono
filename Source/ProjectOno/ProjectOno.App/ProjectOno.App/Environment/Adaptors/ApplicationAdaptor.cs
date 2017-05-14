using System;
using ProjectOno.Environment;
using ProjectOno.Environment.Adaptors;
                
namespace ProjectOno.App.Environment.Adaptors
{
	[Dependency.Transient]
	public class ApplicationAdaptor : IApplicationAdaptor
	{
		public void Shutdown() {
			throw new NotImplementedException();
		}
	}
}
