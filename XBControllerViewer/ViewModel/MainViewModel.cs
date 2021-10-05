using System.Collections.Generic;
using XBControllerViewer.Core;

namespace XBControllerViewer.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public List<ControllerIOViewModel> Controllers { get; }
        public RelayCommand OnExit { get; }

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

            OnExit = new RelayCommand(
            (param) =>
            {
                XBControllerInterface.SetVibrate(0, 0);
                XBControllerInterface.Stop();
            });


            XBControllerInterface.Start();
        }
    }
}
