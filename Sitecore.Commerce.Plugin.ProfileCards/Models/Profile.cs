// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileModel.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.ProfileCards.Models
{
    using Sitecore.Commerce.Core;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <inheritdoc />
    /// <summary>
    /// The ProfileModel.
    /// </summary>
    public class Profile
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("presets")]
        public string Presets { get; set; }

        [XmlElement("key")]
        public List<ProfileKey> Keys { get; set; } = new List<ProfileKey>();

        public Profile()
        { }

        public Profile(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}