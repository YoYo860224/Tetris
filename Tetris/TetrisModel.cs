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
            public Block()
            {

                cube = CUBE.NONE;
                cube_state = CUBE_STATE.NONE;
            }
            public Block(CUBE c, CUBE_STATE cs)
            {
                cube = c;
                cube_state = cs;
            }

        }

        private STATE nowState;
        private Block[,] block;
        private Block[,] nextBlock;
        private int blockx = 24, blocky = 10;       // BLOCK SIZE
        private int nextBlockx = 4, nextBlocky = 4; // NEXTBLOCK SIZE
        private int timer;
        private int score;
        private int level;
        private int[,] nowCubePos;                  // Now cube position
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
            block = new Block[blockx, blocky];      //遊戲BLOCK 24*10  4格看不到
            for (int i = 0; i < blockx; i++)
            {
                for (int j = 0; j < blocky; j++)
                {
                    block[i, j] = new Block();
                }
            }
            nextBlock = new Block[nextBlockx, nextBlocky];//下個方塊 4*4
            for (int i = 0; i < nextBlockx; i++)
            {
                for (int j = 0; j < nextBlocky; j++)
                {
                    nextBlock[i, j] = new Block();
                }
            }

            //set now cube position
            nowCubePos = new int[5, 2];
            for(int i =0;i<5 ;i++)
            {
                for(int j = 0;j<2 ;j++)
                {
                    nowCubePos[i, j] = -1;
                }
            }
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

            SetState(STATE.DOING);
            tetrisView.ViewUpdate();
        }

        public void GamePause()
        {
            SetState(STATE.PAUSE);

            tetrisView.ViewUpdate();
        }

        public void GameOver()
        {
            SetTimer(0);
            SetScore(0);
            SetLevel(1);
            SetState(STATE.STOP);
            /*for (int col = 0; col < blocky; col++)
            {
                for (int row = 0; row < blockx; row++)
                {
                    block[row, col].cube = CUBE.S_RE;
                }
            }
            for (int col = 0; col < nextBlocky; col++)
            {
                for (int row = 0; row < nextBlockx; row++)
                {
                    nextBlock[row, col].cube = CUBE.S_RE;
                }
            }*/
            tetrisView.ViewUpdate();
        }

        
        public void CubeAutoDown()
        {
            //if cube hit bottom we need to scan the block for delete row and then create new cube and next cube
            //if not hit we need call move down
            if (CubeHitBottom())
            {
                BlockScan();

                //change the cube state to OK
                for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube_state = CUBE_STATE.OK;
                    }
                }
                CubeCreate();
                NextCreate();
            }
            else
            {
                CubeMoveDown();
            }

            tetrisView.ViewUpdate();
        }

        // 判斷方塊下面有沒有HIT
        public bool CubeHitBottom() {
            for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
            {
                // 判斷是不是T型
                if (nowCubePos[i, 0] != -1)
                {
                    // check down edge
                    if (nowCubePos[i, 0] - 1 < 0)
                    {
                        return true;
                    }
                    // check down
                    else if (block[(nowCubePos[i, 0] - 1), nowCubePos[i, 1]].cube_state == CUBE_STATE.OK)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }
        // 判斷方塊左邊有沒有HIT
        public bool CubeHitLeft()
        {
            for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
            {   
                // 判斷是不是T型
                if (nowCubePos[i, 0] != -1)
                {
                    // check left edge
                    if (nowCubePos[i, 1] - 1 < 0)
                    {
                        return true;
                    }
                    // check left
                    else if (block[nowCubePos[i, 0], (nowCubePos[i, 1] - 1)].cube_state == CUBE_STATE.OK)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        // 判斷方塊右邊有沒有HIT
        public bool CubeHitRight()
        {
            for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
            {
                // 判斷是不是T型
                if (nowCubePos[i, 0] != -1)
                {
                    // check right edge
                    if (nowCubePos[i, 1] + 1 > 9)
                    {
                        return true;
                    }

                    // check right
                    else if (block[nowCubePos[i, 0], (nowCubePos[i, 1] + 1)].cube_state == CUBE_STATE.OK)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
        // 掃描需要消除的ROW
        public void BlockScan()
        {
            for (int i = 0; i < blockx; i++)
            {
                for (int j = 0; j < blocky; j++)
                {
                    if (block[i, j].cube_state != CUBE_STATE.OK)
                    {
                        break;
                    }
                    if (j == (blocky - 1))
                    {
                        DeleteBlockRow(i);
                    }
                }
            }
        }
        // 消除ROW並加分數
        public void DeleteBlockRow(int x)
        {
            int sc = 0, point = 10;
            for (int j = 0; j < 10; j++) {
                block[x, j] = new Block(CUBE.NONE, CUBE_STATE.DELETE);
            }
            sc = sc + point;
            SetScore(sc);
        }

        public void CubeCreate()
        {
            //you need to change not only block but also nowCubePos
        }

        private void NextCreate()
        {

        }

        ///////////////// people Control /////////////////

        //cube go down to bottom
        public void CubeGoDown()
        {
            //call move down until cube hit bottom
            for(;!CubeHitBottom();)
            {
                CubeMoveDown();
            }
        }

        public void CubeMoveDown()
        {
            //check if cube is hit the bottom cube or side will do not thing
            if (!CubeHitBottom())
            {
                //record new cube type
                CUBE cubeType = CUBE.NONE;
                if (nowCubePos[0, 0] != -1)
                    cubeType = block[nowCubePos[0, 0], (nowCubePos[0, 1])].cube;

                //erase the moving cube
                for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube_state = CUBE_STATE.NONE;
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube = CUBE.NONE;

                        //record the new cube position
                        nowCubePos[i, 0] -= 1;
                    }
                }

                //set the new position
                for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube_state = CUBE_STATE.MOVE;
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube = cubeType;
                    }
                }
                tetrisView.ViewUpdate();
            }
        }

        public void CubeMoveRight()
        {
            //check if cube is hit the right cube or side will do not thing
            if (!CubeHitRight())
            {
                //record new cube type
                CUBE cubeType = CUBE.NONE;
                if (nowCubePos[0, 0] != -1)
                    cubeType = block[nowCubePos[0, 0], (nowCubePos[0, 1])].cube;

                //erase the moving cube
                for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube_state = CUBE_STATE.NONE;
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube = CUBE.NONE;

                        //record the new cube position
                        nowCubePos[i, 1] += 1;
                    }
                }

                //set the new position
                for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube_state = CUBE_STATE.MOVE;
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube = cubeType;
                    }
                }
                tetrisView.ViewUpdate();
            }
        }

        public void CubeMoveLeft()
        {
            //check if cube is hit the left cube or side will do not thing
            if (!CubeHitLeft())
            {
                //record new cube type
                CUBE cubeType = CUBE.NONE;
                if (nowCubePos[0, 0] != -1)
                    cubeType = block[nowCubePos[0, 0], (nowCubePos[0, 1])].cube;

                //erase the moving cube
                for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube_state = CUBE_STATE.NONE;
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube = CUBE.NONE;

                        //record the new cube position
                        nowCubePos[i, 1] -= 1;
                    }
                }

                //set the new position
                for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube_state = CUBE_STATE.MOVE;
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube = cubeType;
                    }
                }
                tetrisView.ViewUpdate();
            }
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
