using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using XBControllerViewer.Core;

using static System.Net.Mime.MediaTypeNames;

namespace XBControllerViewer.Model
{

    public enum ButtonMasks
    {
        XINPUT_GAMEPAD_DPAD_UP = 0x0001,
        XINPUT_GAMEPAD_DPAD_DOWN = 0x0002,
        XINPUT_GAMEPAD_DPAD_LEFT = 0x0004,
        XINPUT_GAMEPAD_DPAD_RIGHT = 0x0008,
        XINPUT_GAMEPAD_START = 0x0010,
        XINPUT_GAMEPAD_BACK = 0x0020,
        XINPUT_GAMEPAD_LEFT_THUMB = 0x0040,
        XINPUT_GAMEPAD_RIGHT_THUMB = 0x0080,
        XINPUT_GAMEPAD_LEFT_SHOULDER = 0x0100,
        XINPUT_GAMEPAD_RIGHT_SHOULDER = 0x0200,
        XINPUT_GAMEPAD_A = 0x1000,
        XINPUT_GAMEPAD_B = 0x2000,
        XINPUT_GAMEPAD_X = 0x4000,
        XINPUT_GAMEPAD_Y = 0x8000,
    }

    public class XBController
    {
        public DualAxisDisplayModel LStick { get; }
        public DualAxisDisplayModel RStick { get; }
        public SingleAxisDisplayModel LTrigger { get; }
        public SingleAxisDisplayModel RTrigger { get; }

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
        }

        public void SetState(XBControllerInterface.XBControllerState state)
        {
            LStick.XValue = state.thumbLX;
            LStick.YValue = state.thumbLY;
            RStick.XValue = state.thumbRX;
            RStick.YValue = state.thumbRY;

            LTrigger.Value = state.leftTrigger;
            RTrigger.Value = state.rightTrigger;
        }
    }
}