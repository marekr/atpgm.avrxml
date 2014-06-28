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
    public class MemorySegment
    {
        [XmlAttribute("name")]
        public string Name = "";

        [XmlAttribute("start")]
        public string start = "";

        [XmlIgnore]
        public UInt32 PageSize;

        [XmlAttribute("pagesize")]
        public string PageSizeAsString
        {
            get
            {
                return "0x"+PageSize.ToString("X");
            }
            set
            {
                PageSize = UInt32.Parse(value.Replace("0x", ""), NumberStyles.HexNumber);
            }
        }

        [XmlIgnore]
        public UInt64 Size;

        [XmlAttribute("size")]
        public string SizeAsString
        {
            get
            {
                return "0x"+Size.ToString("X");
            }
            set
            {
                Size = UInt64.Parse(value.Replace("0x", ""), NumberStyles.HexNumber);
            }
        }

        [XmlIgnore]
        public bool External = false;

        [XmlAttribute("external")]
        public string ExternalAsString
        {
            get
            {
                return External ? "1" : "0";
            }
            set
            {
                External = Convert.ToBoolean(Convert.ToInt16(value));
            }
        }

        [XmlIgnore]
        public bool Exec = false;

        [XmlAttribute("exec")]
        public string ExecAsString
        {
            get
            {
                return Exec ? "1" : "0";
            }
            set
            {
                Exec = Convert.ToBoolean(Convert.ToInt16(value));
            }
        }

        [XmlAttribute("type")]
        public string Type = "";

        [XmlAttribute("rw")]
        public string RW = "";
    }
}
