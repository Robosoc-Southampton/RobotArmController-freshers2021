using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBControllerViewer.Core;

namespace XBControllerViewer.Model
{
    public class IOBindingModel : ObservableObject
    {
        private string _input;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }


        private string _output;
        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                OnPropertyChanged();
            }
        }

        public IOBindingModel()
        {

        }
    }
}
