using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public class TetrisControl
    {
        public enum CMD
        {
            ROTATE,
            RIGHT,
            LEFT,
            MOVEDOWN,
            GODOWN,
            CHANGE
        }

        public enum BUTTON
        {
            START,
            PAUSE,
            STOP
        }

        private TetrisModel tetrisModel;

        public TetrisControl(TetrisModel model)
        {
            tetrisModel = model;
        }

        public void UserKeyDown(Keys c)
        {

        }

        public void UserButton(BUTTON b)
        {

        }

        public void TimerTrigger()
        {

        }

        public void SecTimerTrigger()
        {
        }
    }
}
