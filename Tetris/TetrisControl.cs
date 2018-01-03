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

        public void UserKeyDown(Keys k)
        {
            if (tetrisModel.GetState() == TetrisModel.STATE.DOING)
            {
                if (k == Keys.Up)
                {
                    tetrisModel.CubeRotate();
                }
                else if (k == Keys.Down)
                {
                    tetrisModel.CubeMoveDown();
                }
                else if (k == Keys.Right)
                {
                    tetrisModel.CubeMoveRight();
                }
                else if (k == Keys.Left)
                {
                    tetrisModel.CubeMoveLeft();
                }
                else if (k == Keys.Space)
                {
                    tetrisModel.CubeGoDown();
                }
                else if (k == Keys.C)
                {
                    tetrisModel.CubeChangeNext();
                }
            }
            else if (tetrisModel.GetState() == TetrisModel.STATE.STOP)
            {
                if (k == Keys.Space)
                {
                    tetrisModel.GameOverPanel();
                }
            }
        }

        public void UserButton(BUTTON b)
        {
            if (b == BUTTON.START)
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
            if (tetrisModel.GetState() == TetrisModel.STATE.DOING)
            {
                tetrisModel.CubeAutoDown();
            }
            else if (tetrisModel.GetState() == TetrisModel.STATE.STOP)
            {
                tetrisModel.GameOverPanel();
            }
        }

        public void SecTimerTrigger()
        {
            if (tetrisModel.GetState() == TetrisModel.STATE.DOING)
            {
                tetrisModel.SecTimerControl();
            }
        }
    }
}
