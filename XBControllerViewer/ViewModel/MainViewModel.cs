using XBControllerViewer.Core;

namespace XBControllerViewer.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand OnExit { get; }

        public MainViewModel()
        {
            XBControllerInterface.Start();

            OnExit = new RelayCommand(
            (param) =>
            {
                XBControllerInterface.SetVibrate(0, 0);
                XBControllerInterface.Stop();
            });
        }
    }
}
