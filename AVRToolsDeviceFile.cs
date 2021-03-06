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
using System.IO;
using System.Xml.Serialization;

namespace atpgm.avrxml
{
    [Serializable()]
    [XmlRoot("avr-tools-device-file")]
    public class AVRToolsDeviceFile
    {
        [XmlArray("variants")]
        [XmlArrayItem("variant", typeof(Variant))]
        public Variant[] Variants { get; set; }

        [XmlArray("devices")]
        [XmlArrayItem("device", typeof(Device))]
        public Device[] Devices { get; set; }

        [XmlArray("modules")]
        [XmlArrayItem("module", typeof(Module))]
        public Module[] Modules { get; set; }

        public static AVRToolsDeviceFile Load(string path)
        {
            AVRToolsDeviceFile deviceFile = null;

            XmlSerializer serializer = new XmlSerializer(typeof(AVRToolsDeviceFile));

            using (StreamReader reader = new StreamReader(path))
            {
                deviceFile = (AVRToolsDeviceFile)serializer.Deserialize(reader);
            }

            return deviceFile;
        }

        /// <summary>
        /// Attempt to find module by name
        /// </summary>
        public Module GetModule(string name)
        {
            try
            {
                return (from module in Modules where module.Name == name select module).Single();
            }
            catch
            {
                return null;
            }
        }
    }
}
