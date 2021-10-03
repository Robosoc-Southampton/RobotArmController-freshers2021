using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using XBControllerViewer.Core;

using static System.Net.Mime.MediaTypeNames;

namespace XBControllerViewer.Model
{
    public class XBController
    {
        private enum Masks
        {
            U = 0x0001,
            D = 0x0002,
            L = 0x0004,
            R = 0x0008,
            ST = 0x0010,
            BA = 0x0020,
            LS = 0x0040,
            RS = 0x0080,
            LB = 0x0100,
            RB = 0x0200,
            A = 0x1000,
            B = 0x2000,
            X = 0x4000,
            Y = 0x8000
        }

        public struct ButtonMaskPair
        {
            public ButtonDisplayModel button { get; set; }
            public int mask;
        }

        public DualAxisDisplayModel LStick { get; }
        public DualAxisDisplayModel RStick { get; }
        public SingleAxisDisplayModel LTrigger { get; }
        public SingleAxisDisplayModel RTrigger { get; }

        public List<ButtonMaskPair> Buttons { get; }

        public XBController()
        {
            LStick = new DualAxisDisplayModel()
            {
                XMaxScale = 32767,
                YMaxScale = 32767
            };

            RStick = new DualAxisDisplayModel()
            {
                XMaxScale = 32767,
                YMaxScale = 32767
            };

            LTrigger = new SingleAxisDisplayModel()
            {
                MinScale = 0,
                MaxScale = 255
            };

            RTrigger = new SingleAxisDisplayModel()
            {
                MinScale = 0,
                MaxScale = 255
            };

            Buttons = new List<ButtonMaskPair>();
            foreach (Tuple<string, int> mask in Enum.GetValues(typeof(Masks)).Cast<Masks>().Select(x => new Tuple<string, int>(x.ToString(), (int)x)))
            {
                Buttons.Add(new ButtonMaskPair()
                {
                    button = new ButtonDisplayModel(mask.Item1),
                    mask = mask.Item2
                });
                Debug.WriteLine($"{mask.Item1}, {mask.Item2}");
            }
        }

        public void SetState(XBControllerInterface.XBControllerState state)
        {
            LStick.XValue = state.thumbLX;
            LStick.YValue = state.thumbLY;
            RStick.XValue = state.thumbRX;
            RStick.YValue = state.thumbRY;

            LTrigger.Value = state.leftTrigger;
            RTrigger.Value = state.rightTrigger;

            foreach (ButtonMaskPair pair in Buttons)
            {
                pair.button.Value = (state.buttons & pair.mask) > 0;
            }
        }
    }
}