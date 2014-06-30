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
using System.Globalization;

namespace atpgm.avrxml
{
    [Serializable()]
    public class RegisterGroup
    {
        [XmlAttribute("name")]
        public string Name = "";

        /// <summary>
        /// Name of the matching module 
        /// in the "modules" section of the device file
        /// </summary>
        [XmlAttribute("name-in-module")]
        public string NameInModule = "";

        [XmlAttribute("address-space")]
        public string AddressSpace = "";

        [XmlIgnore]
        public UInt32 Offset = 0;

        [XmlAttribute("offset")]
        public string OffsetAsString
        {
            get
            {
                return "0x" + Offset.ToString("X");
            }
            set
            {
                Offset = UInt32.Parse(value.Replace("0x", ""), NumberStyles.HexNumber);
            }
        }

        [XmlElement("register")]
        public List<Register> Registers { get; set; }
    }
}
