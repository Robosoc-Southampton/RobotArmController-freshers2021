using System;
using System.Collections.Generic;
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
using XBControllerViewer.Core;

namespace XBControllerViewer.Model
{
    public class SingleAxisDisplayModel : ObservableObject
    {
        private int _value = 0;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        private int _minScale = 0;
        public int MinScale
        {
            get => _minScale;
            set
            {
                _minScale = value;
                OnPropertyChanged();
            }
        }

        private int _maxScale = 100;
        public int MaxScale
        {
            get => _maxScale;
            set
            {
                _maxScale = value;
                OnPropertyChanged();
            }
        }

        public SingleAxisDisplayModel()
        {

        }
    }
}
