using System.Diagnostics;
using System.Threading.Tasks;
using XBControllerViewer.Core;
using XBControllerViewer.Model;

namespace XBControllerViewer.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public XBController Controller { get; }

        public RelayCommand OnExit { get; }

        public MainViewModel()
        {
            Controller = new XBController();

            OnExit = new RelayCommand(
            (param) =>
            {
                XBControllerInterface.SetVibrate(0, 0);
                XBControllerInterface.Stop();
            });

            Task update = new Task(() =>
            {
                while (true)
                {
                    if (XBControllerInterface.IsConnected(0) && XBControllerInterface.HasData(0))
                    {
                        XBControllerInterface.XBControllerState state = XBControllerInterface.GetState(0);
                        Controller.SetState(state);
                    }
                }
            });
            update.Start();

            XBControllerInterface.Start();
        }
    }
}
