using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisModel
    {
        public enum STATE
        {
            STOP,
            DOING,
            PAUSE
        };
        public enum CUBE
        {
            NONE = 0,   
            T = 1,
            L,
            L_RE,
            S,
            S_RE,
            I,
            SQUARE,
            IS_MOVE,
            T_MOVING,
            L_MOVING,
            L_RE_MOVING,
            S_MOVING,
            S_RE_MOVING,
            I_MOVING,
            SQUARE_MOVING,
        };

        private STATE nowState;
        private CUBE[,] block;
        private CUBE nextCube;
        private int timer;
        private int score;
        private int level;

        private TetrisView tetrisView;

        public TetrisModel(TetrisView view) {
            nowState = STATE.STOP;
            tetrisView = view;
        }

        public void SetState(STATE state)
        {
            nowState = state;
        }

        public STATE GetState()
        {
            return nowState;
        }

        public void SetTimer(int t)
        {
            timer = t;
        }

        public int GetTimer()
        {
            return timer;
        }

        public void SetLevel(int l)
        {
            level = l;
        }

        public int GetLevel()
        {
            return level;
        }

        public void SetScore(int s)
        {
            score = s;
        }
    
        public int GetScore()
        {
            return score;
        }

        /////////////////  about Cube  ///////////////////
        public CUBE[,] GetBlock()
        {
            return block;
        }

        public void GameStart()
        {

        }

        public void GamePause()
        {

        }

        public void GameOver()
        {

        }

        public void CubeAutoDown()
        {

        }

        public void BlockScan()
        {

        }

        public void DeleteBlockRow(int i)
        {

        }

        public void CubeCreate()
        {

        }
        //////////////////////////////////////////////////

        ///////////////// people Control /////////////////
        public void CubeGoDown()
        {

        }

        public void CubeMoveDown()
        {

        }

        public void CubeMoveRight()
        {

        }

        public void CubeMoveLeft()
        {

        }

        public void CubeRotate()
        {

        }

        public void CubeChangeNext()
        {

        }
        //////////////////////////////////////////////////
    }
}
