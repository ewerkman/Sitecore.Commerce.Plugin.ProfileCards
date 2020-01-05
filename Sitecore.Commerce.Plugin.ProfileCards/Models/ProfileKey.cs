using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sitecore.Commerce.Plugin.ProfileCards.Models
{
    [XmlRoot("key")]
    public class ProfileKey
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("value")]
        public long Value { get; set; }

        public ProfileKey()
        {
        }

        public ProfileKey(string name, long value)
        {
            Name = name;
            Value = value;
        }
    }
}
