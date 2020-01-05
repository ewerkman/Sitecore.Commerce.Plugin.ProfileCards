// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackingFieldModel.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.ProfileCards.Models
{
    using Sitecore.Commerce.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;

    /// <inheritdoc />
    /// <summary>
    /// The TrackingFieldModel.
    /// </summary>
    [XmlRoot(ElementName = "tracking"), XmlType("tracking")]
    public class Tracking
    {
        [XmlElement("profile")]
        public List<Profile> Profiles { get; } = new List<Profile>();

        public void AddProfile(Profile profile)
        {
            Profiles.RemoveAll(p => p.Id == profile.Id);
            Profiles.Add(profile);
        }
    }
}