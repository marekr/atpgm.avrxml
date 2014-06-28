#region License Information (MIT)
/*
    The MIT License (MIT)

    Copyright (c) 2014 Marek Roszko

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
#endregion License Information (MIT)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace atpgm.avrxml
{
    [Serializable()]
    public class Device
    {
        [XmlAttribute("name")]
        public string Name = "";

        [XmlAttribute("architecture")]
        public string Architecture = "";

        [XmlAttribute("family")]
        public string Family = "";

        [XmlAttribute("series")]
        public string Series = "";

        [XmlArray("address-spaces")]
        [XmlArrayItem("address-space", typeof(AddressSpace))]
        public AddressSpace[] AddressSpaces { get; set; }

        [XmlArray("interfaces")]
        [XmlArrayItem("interface", typeof(Interface))]
        public Interface[] Interfaces { get; set; }

        [XmlArray("property-groups")]
        [XmlArrayItem("property-group", typeof(PropertyGroup))]
        public PropertyGroup[] PropertyGroups { get; set; }

        [XmlArray("peripherals")]
        [XmlArrayItem("module", typeof(Module))]
        public Module[] Peripherals { get; set; }

        /// <summary>
        /// Size of FLASH memory segment
        /// </summary>
        public UInt64 FlashSize
        {
            get
            {
                try
                {
                    return (from a in AddressSpaces from b in a.MemorySegments where b.Type == "flash" select b.Size).First();
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Size of SRAM memory segment
        /// </summary>
        public UInt64 SRAMSize
        {
            get
            {
                try
                {
                    return (from a in AddressSpaces from b in a.MemorySegments where b.External == false && b.Type == "ram" select b.Size).First();
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
