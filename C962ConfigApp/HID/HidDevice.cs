using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C962ConfigApp.HID
{
    internal class HidDevice
    {
        public string Path { get; private set; } = string.Empty;
        public int OutputReportLength { get; private set; } = -1;
        public int InputReportLength { get; private set; } = -1;

        public FileStream? UsbFs { get; set; } = null;
        public IntPtr UsbDevice { get; set; } = IntPtr.Zero;

        public HidDevice(string path, int inputReportLength, int outputReportLength)
        {
            this.Path = path;
            this.InputReportLength = inputReportLength;
            this.OutputReportLength = outputReportLength;
        }
    }
}
