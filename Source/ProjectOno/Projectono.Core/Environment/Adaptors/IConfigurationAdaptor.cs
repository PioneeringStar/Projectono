﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projectono.Core.Environment.Adaptors
{
    public interface IConfigurationAdaptor
    {
        Task<XElement> LoadConfiguration(string name);
        Task WriteConfiguration(string name, XElement data);
    }
}
