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
            
            if (tetrisModel.GetState().Equals(TetrisModel.STATE.DOING))
            {
                if (c == Keys.A)
                {
                    tetrisModel.CubeMoveRight();
                }
                else if (c == Keys.D)
                {
                    tetrisModel.CubeMoveLeft();
                }
                else if (c == Keys.S)
                {
                    tetrisModel.CubeMoveDown();
                }
                else if (c == Keys.C)
                {
                    tetrisModel.CubeGoDown();
                }
                else if (c == Keys.Space)
                {
                    tetrisModel.CubeRotate();
                }
            }
        }

        public void UserButton(BUTTON b)
        {
            if(b == BUTTON.START)
            {
                tetrisModel.GameStart();
            }
            else if (b == BUTTON.PAUSE)
            {
                tetrisModel.GamePause();
            }
            else if (b == BUTTON.STOP)
            {
                tetrisModel.GameOver();
            }
        }

        public void TimerTrigger()
        {
            if (tetrisModel.GetState().Equals(TetrisModel.STATE.DOING))
            {
                tetrisModel.CubeAutoDown();
            }
        }

        public void SecTimerTrigger()
        {
            tetrisModel.SetTimer(tetrisModel.GetTimer() + 1);
        }
    }
}
