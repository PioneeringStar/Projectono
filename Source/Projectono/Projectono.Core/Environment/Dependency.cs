using System;
namespace Projectono.Environment
{
	public abstract class Dependency : Attribute
	{
		public class Instance : Dependency { }
		public class Singleton : Dependency { }
		public class Transient : Dependency { }
	}
}
