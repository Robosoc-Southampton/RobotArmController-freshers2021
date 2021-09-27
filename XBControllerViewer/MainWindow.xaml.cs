using System;
using System.Diagnostics;
using System.Threading.Tasks;
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
            XBControllerInterface.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (XBControllerInterface.IsConnected(0))
            {
                Debug.WriteLine(XBControllerInterface.GetState(0));
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            XBControllerInterface.SetVibrate(0, 0);
            XBControllerInterface.Stop();
        }
    }
}
