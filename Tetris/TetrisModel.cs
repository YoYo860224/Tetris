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
            NONE,   
            T,
            I,
            SQUARE,
            L,
            L_RE,
            S,
            S_RE,
        };

        public enum CUBE_STATE
        {
            NONE,
            OK,
            MOVE,
            JOINT,
            DELETE
        }

        public class Block
        {
            public CUBE cube = new CUBE();
            public CUBE_STATE cube_state = new CUBE_STATE();

            public Block(CUBE c, CUBE_STATE cs)
            {
                cube = c;
                cube_state = cs;
            }
        }

        private STATE nowState;
        private Block[,] block;
        private Block[,] nextBlock;

        private int timer;
        private int score;
        private int level;

        private TetrisView tetrisView;

        public TetrisModel(TetrisView view) {
            tetrisView = view;
            InitAll();
        }

        public void InitAll()
        {
            nowState = STATE.STOP;

            // new Block and init them to CUBE.NONE
            // TODO : ...


            NextCreate();

            timer = 0;
            score = 0;
            level = 1;
        }

        ///////////////////  get set  /////////////////////

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

        public Block[,] GetBlock()
        {
            return block;
        }

        public Block[,] GetNextBlock()
        {
            return nextBlock;
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

        private void NextCreate()
        {

        }

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
