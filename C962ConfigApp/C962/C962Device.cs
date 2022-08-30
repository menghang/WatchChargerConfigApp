using C962ConfigApp.HID;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C962ConfigApp.C962
{
    internal class C962Device
    {
        private const ushort VID = 0;
        private const ushort PID = 0;

        private readonly Hid hid;
        private HidDevice? device = null;

        public C962Device()
        {
            this.hid = new();
        }

        public bool GetDevice()
        {
            Collection<HidDevice> devs = new();
            Hid.GetHidDeviceList(devs, VID, PID);
            if (devs != null && devs.Count > 0)
            {
                this.device = devs[0];
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
