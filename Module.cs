﻿#region License Information (MIT)
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
    public class Module
    {
        [XmlAttribute("name")]
        public string Name = "";

        [XmlAttribute("name2")]
        public string Name2 = "";

        [XmlAttribute("id")]
        public string ID = "";

        [XmlAttribute("version")]
        public string Version = "";

        [XmlAttribute("caption")]
        public string Caption = "";

        [XmlElement("register-group")]
        public List<RegisterGroup> RegisterGroups { get; set; }

        [XmlElement("value-group")]
        public List<ValueGroup> ValueGroups { get; set; }

        [XmlElement("instance")]
        public List<Instance> Instances { get; set; }


        /// <summary>
        /// Attempt to find an value group by name
        /// </summary>
        public ValueGroup GetValueGroup(string name)
        {
            try
            {
                return (from a in ValueGroups where a.Name == name select a).Single();
            }
            catch
            {
                return null;
            }
        }
    }
}
