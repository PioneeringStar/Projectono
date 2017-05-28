using Projectono.Core.Application.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projectono.Core.Application.Profiles
{
    public interface IProfile
    {
        /// <summary>
        /// The human readable name of this printer profile
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Encapsulates the asynchronous work needed to move the ZAxis of the printer<br />
        /// NOTE: This should include any work required "between" layers such as settling resin, etc.
        /// </summary>
        Task MoveZAxis(double distance);
        /// <summary>
        /// Encapsulates the asynchronous work needed to ready a new print or notify one has started<br />
        /// </summary>
        Task NotifyPrintStart();
        /// <summary>
        /// Encapsulates the asynchronous work needed to complete / finish a print or notify one has eneded
        /// </summary>
        Task NotifyPrintComplete();

        /// <summary>
        /// Retrieves the configurable meta settings for this profile asynchronously
        /// </summary>
        Task<Profile.Setting[]> ReadSettings();
        /// <summary>
        /// Updates the configurable meta settings for this profile asynchronously
        /// </summary>
        Task WriteSettings(Profile.Setting[] settings);
    }

    /// <summary>
    /// A base class that can be used for printer profiles
    /// </summary>
    public abstract class Profile : IProfile
    {
        public abstract string Name { get; }

        public abstract Task MoveZAxis(double distance);
        public abstract Task NotifyPrintStart();
        public abstract Task NotifyPrintComplete();

        public abstract Profile.Setting[] CreateDefaultSettings();

        private readonly IConfigurationProvider _config;

        protected Profile(IConfigurationProvider config)
        {
            _config = config;
        }

        public async Task<Profile.Setting[]> ReadSettings()
        {
            var xml = await _config.LoadConfiguration("PrinterProfile_" + Name);
            var settings = CreateDefaultSettings();
            foreach (var child in xml.Nodes().OfType<XElement>()) {
                var setting = settings.FirstOrDefault(s => s.Name == child.Attribute("Name").Value);
                if (setting == null) continue;
                // TODO: This needs value conversion services to parse to the defaults value type
            }
            return settings;
        }

        public async Task WriteSettings(Profile.Setting[] settings)
        {
            var defaults = CreateDefaultSettings();
            var xml = new XElement("Settings");
            foreach (var setting in settings) {
                var match = defaults.FirstOrDefault(d => d.Name == setting.Name);
                if (match == null) continue;
                // TODO: This needs value conversion services to appropriately format values to string
                var value = new XElement("Setting");
                value.SetAttributeValue("Name", match.Name);
                value.SetAttributeValue("Value", /* TODO: conversion here */ setting.Value);
                xml.Add(value);
            }
            await _config.WriteConfiguration("PrinterProfile_" + Name, xml);
        }

        /// <summary>
        /// Configurable value to be used by the profile to operate
        /// </summary>
        public class Setting
        {
            /// <summary>
            /// Human readable name of this profile setting
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// The current value of this profile setting
            /// </summary>
            public object Value { get; set; }
        }
    }
}
