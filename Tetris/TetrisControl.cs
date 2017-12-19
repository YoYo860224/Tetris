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
                if (c == Keys.Up)
                {
                    tetrisModel.CubeRotate();
                }
                else if (c == Keys.Down)
                {
                    tetrisModel.CubeMoveDown();
                }
                else if (c == Keys.Right)
                {
                    tetrisModel.CubeMoveRight();
                }
                else if (c == Keys.Left)
                {
                    tetrisModel.CubeMoveLeft();
                }
                else if (c == Keys.Space)
                {
                    tetrisModel.CubeGoDown();
                }
                else if (c == Keys.C)   // 更換方塊
                {
                    tetrisModel.CubeChangeNext();
                }
            }
            else if (tetrisModel.GetState() == TetrisModel.STATE.STOP)
            {
                if (c == Keys.Space)
                {
                    tetrisModel.GameOverPanel();
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
            else if (tetrisModel.GetState() == TetrisModel.STATE.STOP)
            {
                tetrisModel.GameOverPanel();
            }
        }

        public void SecTimerTrigger()
        {
            if (tetrisModel.GetState().Equals(TetrisModel.STATE.DOING))
            {
                tetrisModel.SetTimer(tetrisModel.GetTimer() + 1);
                tetrisModel.LevelUp();
            }
        }
    }
}
