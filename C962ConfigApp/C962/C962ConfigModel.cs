using C962ConfigApp.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C962ConfigApp.C962
{
    internal class C962ConfigModel : BaseViewModel
    {
        internal class VendorLockModel
        {
            public byte Value { get; set; } = 0;
            public string Mode { get; set; } = string.Empty;
        }

        public List<VendorLockModel> VendorLockList { get; private set; }
        private VendorLockModel vendorLock;
        public VendorLockModel VendorLock
        {
            get => this.vendorLock;
            set => SetProperty(ref this.vendorLock, value);
        }

        private ushort usbVID = 0x00;
        public ushort UsbVIDVal
        {
            get => this.usbVID;
            set => this.usbVID = value;
        }
        public string UsbVID
        {
            get => "0x" + Convert.ToString(this.usbVID, 16).PadLeft(4, '0');
            set
            {
                try
                {
                    if (value.StartsWith("0x"))
                    {
                        this.usbVID = Convert.ToUInt16(value, 16);
                    }
                    else
                    {
                        this.usbVID = Convert.ToUInt16(value, 10);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    this.usbVID = 0;
                }
                OnPropertyChanged(nameof(this.UsbVID));
            }
        }

        private ushort usbPID = 0x00;
        public ushort UsbPIDVal
        {
            get => this.usbPID;
            set => this.usbPID = value;
        }
        public string UsbPID
        {
            get => "0x" + Convert.ToString(this.usbPID, 16).PadLeft(4, '0');
            set
            {
                try
                {
                    if (value.StartsWith("0x"))
                    {
                        this.usbPID = Convert.ToUInt16(value, 16);
                    }
                    else
                    {
                        this.usbPID = Convert.ToUInt16(value, 10);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    this.usbPID = 0;
                }
                OnPropertyChanged(nameof(this.UsbPID));
            }
        }

        internal class PowerModeModel
        {
            public byte Value { get; set; } = 0;
            public string Mode { get; set; } = string.Empty;
        }

        public List<PowerModeModel> PowerModeList { get; private set; }
        private PowerModeModel powerMode;
        public PowerModeModel PowerMode
        {
            get => this.powerMode;
            set => SetProperty(ref this.powerMode, value);
        }

        private string vendorName = string.Empty;
        public byte[] VendorNameVal
        {
            get => Encoding.UTF8.GetBytes(this.vendorName);
            set => this.vendorName = Encoding.UTF8.GetString(value);
        }
        public string VendorName
        {
            get => this.vendorName;
            set => SetProperty(ref this.vendorName, value);
        }

        private string productName = string.Empty;
        public byte[] ProductNameVal
        {
            get => Encoding.UTF8.GetBytes(this.productName);
            set => this.productName = Encoding.UTF8.GetString(value);
        }
        public string ProductName
        {
            get => this.productName;
            set => SetProperty(ref this.productName, value);
        }

        private string modelName = string.Empty;
        public byte[] ModelNameVal
        {
            get => Encoding.UTF8.GetBytes(this.modelName);
            set => this.modelName = Encoding.UTF8.GetString(value);
        }
        public string ModelName
        {
            get => this.modelName;
            set => SetProperty(ref this.modelName, value);
        }

        private string serialNumber = string.Empty;
        public byte[] SerialNumberVal
        {
            get => Encoding.UTF8.GetBytes(this.serialNumber);
            set => this.serialNumber = Encoding.UTF8.GetString(value);
        }
        public string SerialNumber
        {
            get => this.serialNumber;
            set => SetProperty(ref this.serialNumber, value);
        }

        private string vendorID = string.Empty;
        public byte[] VendorIDVal
        {
            get => Encoding.UTF8.GetBytes(this.vendorID);
            set => this.vendorID = Encoding.UTF8.GetString(value);
        }
        public string VendorID
        {
            get => this.vendorID;
            set => SetProperty(ref this.vendorID, value);
        }

        private string productID = string.Empty;
        public byte[] ProductIDVal
        {
            get => Encoding.UTF8.GetBytes(this.productID);
            set => this.productID = Encoding.UTF8.GetString(value);
        }
        public string ProductID
        {
            get => this.productID;
            set => SetProperty(ref this.productID, value);
        }

        private string productPlanUID = string.Empty;
        public byte[] ProductPlanUIDVal
        {
            get => Encoding.UTF8.GetBytes(this.productPlanUID);
            set => this.productPlanUID = Encoding.UTF8.GetString(value);
        }
        public string ProductPlanUID
        {
            get => this.productPlanUID;
            set => SetProperty(ref this.productPlanUID, value);
        }

        private ushort acr = 0;
        public ushort ACRVal
        {
            get => this.acr;
            set => this.acr = value;
        }
        public string ACR
        {
            get => Convert.ToString(this.acr);
            set
            {
                try
                {
                    this.acr = Convert.ToUInt16(value);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    this.acr = 0;
                }
                OnPropertyChanged(nameof(this.ACR));
            }
        }

        public C962ConfigModel()
        {
            this.VendorLockList = new() {
                new VendorLockModel() { Value = 0, Mode = "Unlocked" },
                new VendorLockModel() { Value = 1, Mode = "Temporary Lock" },
                new VendorLockModel() { Value = 2, Mode = "Permanent Lock" } };
            this.vendorLock = VendorLockList[0];

            this.PowerModeList = new() {
                new PowerModeModel() { Value = 0, Mode = "USB-A" },
                new PowerModeModel() { Value = 1, Mode = "USB-C" },
                new PowerModeModel() { Value = 2, Mode = "Fixed Supply" } };
            this.powerMode = this.PowerModeList[0];
        }
    }
}
