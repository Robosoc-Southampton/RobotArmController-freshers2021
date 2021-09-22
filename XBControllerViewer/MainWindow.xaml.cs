using System;
using System.Diagnostics;
using System.Windows;

namespace XBControllerViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"\n{DateTime.Now.ToLongTimeString()}: {XBControllerInterface.CountConnectedDevices()}");

            if (XBControllerInterface.CountConnectedDevices() > 0)
            {
                Debug.WriteLine(XBControllerInterface.GetState(0));
            }
        }
    }
}
