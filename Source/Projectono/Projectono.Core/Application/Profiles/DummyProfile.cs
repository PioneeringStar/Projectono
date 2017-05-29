using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projectono.Core.Environment.Adaptors;
using Projectono.Core.Environment.TypeConversion;

namespace Projectono.Core.Application.Profiles
{
    public class DummyProfile : Profile
    {
        public DummyProfile(IConfigurationAdaptor config, ITypeConverter[] converters) : base(config, converters) { }

        public override string Name { get { return "Test Printer"; } }

        public override Setting[] CreateDefaultSettings()
        {
            return new[] {
                new Setting { Name = "String Setting", Value = "Default Value" },
                new Setting { Name = "Number Setting", Value = 10, Min = 1, Max = 10 },
                new Setting { Name = "Boolean Setting", Value = false }
            };
        }

        public override Task MoveZAxis(double distance)
        {
            return Task.Factory.StartNew(() => { });
        }

        public override Task NotifyPrintComplete()
        {
            return Task.Factory.StartNew(() => { });
        }

        public override Task NotifyPrintStart()
        {
            return Task.Factory.StartNew(() => { });
        }
    }
}
