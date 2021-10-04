using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XBControllerViewer.Core;
using XBControllerViewer.Model;

namespace XBControllerViewer.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public XBController Controller { get; }

        public RelayCommand OnExit { get; }

        public ObservableCollection<IOBindingModel> Bindings { get; }

        public IOBindingModel SelectedBinding { get; set; }

        public RelayCommand CreateBinding { get; }
        public RelayCommand RemoveBinding { get; }

        public string InputBindingSelection { get; set; }
        public string OutputBindingName { get; set; }

        public Dictionary<string, int> EvaluateBindings
        {
            get
            {
                Dictionary<string, int> ret = new Dictionary<string, int>();

                foreach (IOBindingModel binding in Bindings)
                {
                    ret.Add(binding.Output, Controller.Getters[binding.Input].Invoke());
                }

                return ret;
            }
        }

        public MainViewModel()
        {
            Controller = new XBController();

            Bindings = new ObservableCollection<IOBindingModel>();

            OnExit = new RelayCommand(
            (param) =>
            {
                XBControllerInterface.SetVibrate(0, 0);
                XBControllerInterface.Stop();
            });

            CreateBinding = new RelayCommand(
            (param) =>
            {
                if (!Bindings.Any(binding => binding.Input == InputBindingSelection) && !Bindings.Any(binding => binding.Output == OutputBindingName))
                {
                    Bindings.Add(new IOBindingModel()
                    {
                        Input = InputBindingSelection,
                        Output = OutputBindingName
                    });
                }
            });

            RemoveBinding = new RelayCommand(
            (param) =>
            {
                _ = Bindings.Remove(SelectedBinding);
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
