using C962ConfigApp.C962;
using C962ConfigApp.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace C962ConfigApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowVM view;
        private C962Device dev;
        public MainWindow()
        {
            InitializeComponent();
            this.view = new();
            this.DataContext = this.view;

            dev = new();
        }

        private void ButtonLockUnlock_Click(object sender, RoutedEventArgs e)
        {
            this.view.NotLocked = !this.view.NotLocked;
        }

        private async void ButtonReadC962_Click(object sender, RoutedEventArgs e)
        {
            if (!dev.GetDevice())
            {
                return;
            }
            for (byte id = 0x00; id <= 0x0c; id++)
            {
                byte[]? data = await dev.GetItem(id);
                if (data != null)
                {
                    Trace.WriteLine(data);
                }
            }

        }
    }
}
