using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using XBControllerViewer.Core;

namespace XBControllerViewer.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public List<ControllerIOViewModel> Controllers { get; }
        public RelayCommand OnExit { get; }
        public RelayCommand OnMinimize { get; }
        public RelayCommand OnMaximize { get; }
        public RelayCommand OnClose { get; }
        public RelayCommand OnMouseDown { get; }
        public RelayCommand OnDrag { get; }

        public Dictionary<string, Dictionary<string, int>> EvaluateBindings
        {
            get
            {
                Dictionary<string, Dictionary<string, int>> ret = new Dictionary<string, Dictionary<string, int>>();

                foreach (ControllerIOViewModel controller in Controllers)
                {
                    ret.Add(controller.ControllerIndex.ToString(), controller.EvaluateBindings);
                }

                return ret;
            }
        }

        public MainViewModel()
        {
            Controllers = new List<ControllerIOViewModel>();
            for (uint i = 0; i < 4; i++)
            {
                Controllers.Add(new ControllerIOViewModel(i));
            }

            OnMinimize = new RelayCommand(
            (param) =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            OnMaximize = new RelayCommand(
            (param) =>
            {
                Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            });

            OnClose = new RelayCommand(
            (param) =>
            {
                foreach (ControllerIOViewModel controller in Controllers)
                {
                    XBControllerInterface.SetVibrate(controller.ControllerIndex, 0);
                }
                XBControllerInterface.Stop();

                Application.Current.MainWindow.Close();
            });

            OnMouseDown = new RelayCommand(
            (param) =>
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    Application.Current.MainWindow.DragMove();
                }
            });


            XBControllerInterface.Start();
        }
    }
}
