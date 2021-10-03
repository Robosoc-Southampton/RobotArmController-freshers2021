using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBControllerViewer.Core;

namespace XBControllerViewer.Model
{
    public class ButtonDisplayModel : ObservableObject
    {
        public string Name { get; }

        private bool _value;

        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }


        public ButtonDisplayModel(string name)
        {
            Name = name;
        }
    }
}
