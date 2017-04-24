using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOno.Environment.Adaptors
{
    public interface IPlatformAdaptor
    {
        bool FullScreenEnabled { get; set; }
    }
}
