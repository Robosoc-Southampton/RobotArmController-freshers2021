using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBControllerViewer.Core;

namespace XBControllerViewer.Model
{
    public class DualAxisDisplayModel : ObservableObject
    {
        private double _xValue = 0;
        public double XValue
        {
            get => _xValue;
            set
            {
                _xValue = value;
                OnPropertyChanged("PosAsString");
                OnPropertyChanged("RenderTransformX");
            }
        }

        public double XMaxScale { get; set; } = 100;

        private double _yValue = 0;
        public double YValue
        {
            get => _yValue;
            set
            {
                _yValue = value;
                OnPropertyChanged("PosAsString");
                OnPropertyChanged("RenderTransformY");
            }
        }

        public double YMaxScale { get; set; } = 100;

        public string PosAsString
        {
            get => $"{XValue}, {YValue}";
        }

        public int RenderTransformX
        {
            get => (int)(XValue / XMaxScale * 50);
        }

        public int RenderTransformY
        {
            get => (int)(-YValue / YMaxScale * 50);
        }

        public DualAxisDisplayModel()
        {

        }
    }
}
