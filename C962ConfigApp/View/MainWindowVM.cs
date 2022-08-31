using C962ConfigApp.C962;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C962ConfigApp.View
{
    internal class MainWindowVM : BaseViewModel
    {
        public C962ConfigModel C962 { get; set; } = new();

        internal class SelectionModel : BaseViewModel
        {
            private bool enableVendorLock = true;
            public bool EnableVendorLock
            {
                get => this.enableVendorLock;
                set => SetProperty(ref this.enableVendorLock, value);
            }

            private bool enableUsbVID = true;
            public bool EnableUsbVID
            {
                get => this.enableUsbVID;
                set => SetProperty(ref this.enableUsbVID, value);
            }

            private bool enableUsbPID = true;
            public bool EnableUsbPID
            {
                get => this.enableUsbPID;
                set => SetProperty(ref this.enableUsbPID, value);
            }

            private bool enablePowerMode = true;
            public bool EnablePowerMode
            {
                get => this.enablePowerMode;
                set => SetProperty(ref this.enablePowerMode, value);
            }

            private bool enableVendorName = true;
            public bool EnableVendorName
            {
                get => this.enableVendorName;
                set => SetProperty(ref this.enableVendorName, value);
            }

            private bool enableProductName = true;
            public bool EnableProductName
            {
                get => this.enableProductName;
                set => SetProperty(ref this.enableProductName, value);
            }

            private bool enableModelName = true;
            public bool EnableModelName
            {
                get => this.enableModelName;
                set => SetProperty(ref this.enableModelName, value);
            }

            private bool enableSerialNumber = true;
            public bool EnableSerialNumber
            {
                get => this.enableSerialNumber;
                set => SetProperty(ref this.enableSerialNumber, value);
            }

            private bool enableVendorID = false;
            public bool EnableVendorID
            {
                get => this.enableVendorID;
                set => SetProperty(ref this.enableVendorID, value);
            }

            private bool enableProductID = false;
            public bool EnableProductID
            {
                get => this.enableProductID;
                set => SetProperty(ref this.enableProductID, value);
            }

            private bool enableProductPlanUID = true;
            public bool EnableProductPlanUID
            {
                get => this.enableProductPlanUID;
                set => SetProperty(ref this.enableProductPlanUID, value);
            }

            private bool enableACR = true;
            public bool EnableACR
            {
                get => this.enableACR;
                set => SetProperty(ref this.enableACR, value);
            }
        }

        public SelectionModel Selection { get; set; } = new();

        private bool notLocked = false;
        public bool NotLocked
        {
            get => this.notLocked;
            set
            {
                SetProperty(ref this.notLocked, value);
                OnPropertyChanged(nameof(this.Locked));
            }
        }

        public bool Locked
        {
            get => !this.notLocked;
        }
    }
}
