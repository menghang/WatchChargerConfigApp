using C962ConfigApp.HID;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C962ConfigApp.C962
{
    internal class C962Device
    {
        private const ushort VID = 0x05ac;
        private const ushort PID = 0x0504;

        private readonly Hid hid;
        private HidDevice? device = null;

        public C962Device()
        {
            this.hid = new();
        }

        public bool GetDevice()
        {
            this.hid.GetHidDeviceList(out Collection<HidDevice> devs, VID, PID);
            if (devs != null && devs.Count > 0)
            {
                this.device = devs[0];
                return true;
            }
            else
            {
                this.device = null;
                return false;
            }
        }

        public async Task<byte[]?> GetItem(byte ItemID)
        {
            if (this.device != null)
            {
                try
                {
                    if (this.hid.OpenDevice(device) != Hid.HID_RETURN.SUCCESS)
                    {
                        return null;
                    }
                    if (await this.hid.WriteAsync(device, new byte[] { 0xA1, ItemID }) != Hid.HID_RETURN.SUCCESS)
                    {
                        return null;
                    }
                    byte[]? data = await this.hid.ReadAsync(device);
                    return data;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    return null;
                }
                finally
                {
                    hid.CloseDevice(device);
                }
            }
            else
            {
                return null;
            }
        }

    }
}
