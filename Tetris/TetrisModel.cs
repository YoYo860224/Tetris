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
        private short resetflag;
        private int[,] nowCubePos;// Now cube position
        private float timerInterval;
        private bool CubeIsChanged;//判斷方塊是否更換過
        private TetrisView tetrisView;

        public TetrisModel(TetrisView view) {
            tetrisView = view;
            InitAll();
        }

        public void InitAll()
        {
            CubeIsChanged = false;//初始為否
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
            timerInterval = 1000;
            resetflag = 0;
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
            if(resetflag == 1)
            {
                for (int col = 0; col < blocky; col++)
                {
                    for (int row = 0; row < blockx; row++)
                    {
                        block[row, col].cube = CUBE.NONE;
                    }
                }
                for (int col = 0; col < nextBlocky; col++)
                {
                    for (int row = 0; row < nextBlockx; row++)
                    {
                        nextBlock[row, col].cube = CUBE.NONE;
                    }
                }
            }
            resetflag = 0;
            if (nowState == STATE.STOP)//初始畫面
            {
                InitAll();
                CubeCreate();
                NextCreate();
            }
            SetState(STATE.DOING);
            tetrisView.ViewUpdate();
        }

        public void GamePause()
        {
            if (nowState == STATE.STOP) ;
            else
                SetState(STATE.PAUSE);

            tetrisView.ViewUpdate();
        }

        public void GameOver()
        {
            SetTimer(0);
            SetScore(0);
            SetLevel(1);
            SetState(STATE.STOP);
            for (int col = 0; col < blocky; col++)
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
            }
            resetflag = 1;
            tetrisView.ViewUpdate();
        }

        
        public void CubeAutoDown()
        {
            //if cube hit bottom we need to scan the block for delete row and then create new cube and next cube
            //if not hit we need call move down
            if (CubeHitBottom())
            {
                CubeIsChanged = false;

                //change the cube state to OK
                for (int i = 0; i < nowCubePos.GetUpperBound(0); i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], (nowCubePos[i, 1])].cube_state = CUBE_STATE.OK;
                    }
                }
                BlockScan();
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
            int count = 0;
            for (int i = 0; i < blockx; i++)
            {
                for (int j = 0; j < blocky; j++)
                {
                    if (block[i, j].cube_state != CUBE_STATE.NONE && i + 1 > 19)
                    {
                        GameOver();
                    }
                    if (block[i, j].cube_state == CUBE_STATE.OK)
                    {
                        count++;
                    }
                    if (count == 20)
                    {
                        DeleteBlockRow(i);
                        i = -1;                     
                    }
                    count = 0;
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
            for (int i = x; i < 23; i++) {
                for (int j = 0; j < 10; j++) {
                    block[i, j] = block[i + 1, j];
                }
            }
            sc = sc + point;
            SetScore(sc);
        }

        public void CubeCreate()
        {
            //you need to change not only block but also nowCubePos
            CUBE Cubetype = CUBE.NONE;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    nowCubePos[i, j] = -1;

                }
            }
            for (int i = 0; i < nextBlockx; i++)
            {
                for (int j = 0; j < nextBlocky; j++)
                {
                    block[i + 18, j + 3] = nextBlock[i, j];
                    if (nextBlock[i, j].cube != CUBE.NONE)
                        Cubetype = nextBlock[i, j].cube;
                }
            }
            switch (Cubetype)
            {
                case CUBE.T:
                    nowCubePos[0, 0] = 19;
                    nowCubePos[0, 1] = 4;
                    nowCubePos[1, 0] = 20;
                    nowCubePos[1, 1] = 4;
                    nowCubePos[2, 0] = 18;
                    nowCubePos[2, 1] = 4;
                    nowCubePos[3, 0] = 19;
                    nowCubePos[3, 1] = 5;
                    break;
                case CUBE.I:
                    nowCubePos[0, 0] = 20;
                    nowCubePos[0, 1] = 4;
                    nowCubePos[1, 0] = 21;
                    nowCubePos[1, 1] = 4;
                    nowCubePos[2, 0] = 19;
                    nowCubePos[2, 1] = 4;
                    nowCubePos[3, 0] = 18;
                    nowCubePos[3, 1] = 4;
                    break;
                case CUBE.SQUARE:
                    nowCubePos[0, 0] = 20;
                    nowCubePos[0, 1] = 4;
                    nowCubePos[1, 0] = 20;
                    nowCubePos[1, 1] = 5;
                    nowCubePos[2, 0] = 19;
                    nowCubePos[2, 1] = 4;
                    nowCubePos[3, 0] = 19;
                    nowCubePos[3, 1] = 5;
                    break;
                case CUBE.L:
                    nowCubePos[0, 0] = 19;
                    nowCubePos[0, 1] = 4;
                    nowCubePos[1, 0] = 20;
                    nowCubePos[1, 1] = 4;
                    nowCubePos[2, 0] = 18;
                    nowCubePos[2, 1] = 4;
                    nowCubePos[3, 0] = 18;
                    nowCubePos[3, 1] = 5;
                    break;
                case CUBE.L_RE:
                    nowCubePos[0, 0] = 19;
                    nowCubePos[0, 1] = 5;
                    nowCubePos[1, 0] = 20;
                    nowCubePos[1, 1] = 5;
                    nowCubePos[2, 0] = 18;
                    nowCubePos[2, 1] = 5;
                    nowCubePos[3, 0] = 18;
                    nowCubePos[3, 1] = 4;
                    break;
                case CUBE.S:
                    nowCubePos[0, 0] = 19;
                    nowCubePos[0, 1] = 4;
                    nowCubePos[1, 0] = 20;
                    nowCubePos[1, 1] = 4;
                    nowCubePos[2, 0] = 19;
                    nowCubePos[2, 1] = 5;
                    nowCubePos[3, 0] = 18;
                    nowCubePos[3, 1] = 5;
                    break;
                case CUBE.S_RE:
                    nowCubePos[0, 0] = 19;
                    nowCubePos[0, 1] = 4;
                    nowCubePos[1, 0] = 19;
                    nowCubePos[1, 1] = 5;
                    nowCubePos[2, 0] = 20;
                    nowCubePos[2, 1] = 5;
                    nowCubePos[3, 0] = 18;
                    nowCubePos[3, 1] = 4;
                    break;
            }
        }

        private void NextCreate()
        {
            Random rand = new Random();
            CUBE nextCube = (CUBE)(rand.Next() % 7 + 1);
            NextCreate(nextCube);
        }

        private void NextCreate(CUBE nextCube)
        {
            for (int i = 0; i < nextBlockx; i++)
            {
                for (int j = 0; j < nextBlocky; j++)
                {
                    nextBlock[i, j] = new Block(CUBE.NONE, CUBE_STATE.NONE);
                }
            }

            switch (nextCube)
            {
                case CUBE.T:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;

                case CUBE.I:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[3, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;

                case CUBE.SQUARE:
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;

                case CUBE.L:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[0, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;

                case CUBE.L_RE:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[0, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;

                case CUBE.S:
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[0, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;

                case CUBE.S_RE:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;
            }
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
            int[,] nextRotation = new int[5, 5]; //unit rotation array
            int[,] reset = new int[5, 2]; //temp of "nowCubeposition"
            int[] tempPosition = new int[2];
            int count = 1;
            CUBE cubeType = CUBE.NONE;

            if (cubeType == CUBE.SQUARE)
            {
                return;
            }

            if (nowCubePos[0, 0] != -1)
            {
                cubeType = block[nowCubePos[0, 0], (nowCubePos[0, 1])].cube;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    nextRotation[i, j] = 0;
                }
            }

            for (int i = 0; i < 5; i++)  //校正成原坐標
            {
                if (nowCubePos[i, 0] != -1)
                {
                    reset[i, 0] = nowCubePos[i, 0] - (nowCubePos[0, 0] - 2);
                    reset[i, 1] = nowCubePos[i, 1] - (nowCubePos[0, 1] - 2);
                    nextRotation[reset[i, 0], reset[i, 0]] = 1;
                }
            }

            int n = 5;
            for (int i = 0; i < n / 2; i++) //旋轉陣列
            {
                for (int j = i; j < n - 1 - i; j++)
                {
                    int temp = nextRotation[i, j];
                    nextRotation[i, j] = nextRotation[n - 1 - j, i];
                    nextRotation[n - 1 - j, i] = nextRotation[n - 1 - i, n - 1 - j];
                    nextRotation[n - 1 - i, n - 1 - j] = nextRotation[j, n - 1 - i];
                    nextRotation[j, n - 1 - i] = temp;
                }
            }

            for (int i = 0; i < 5; i++) //將轉好的方塊的相對坐標記錄下來
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 2 && j == 2)
                    {
                        continue;
                    }
                    if (nextRotation[i, j] == 1)
                    {
                        reset[count, 0] = i;
                        reset[count, 1] = j;
                        count++;
                    }
                }
            }

            tempPosition[0] = nowCubePos[0, 0] - 2; //計算轉換前的坐標距離
            tempPosition[1] = nowCubePos[0, 1] - 2;

            for (int i = 0; i < 5; i++) //判斷可否旋轉
            {
                if (reset[i, 0] + tempPosition[0] < 0 || reset[i, 1] + tempPosition[1] < 0 || reset[i, 1] + tempPosition[1] > 9)
                {
                    return;
                }
                if (block[reset[i, 0] + tempPosition[0], reset[i, 1] + tempPosition[1]].cube_state == CUBE_STATE.OK)
                {
                    return;
                }
            }

            if (reset[0, 0] != -1) //將旋轉後的方塊放回原位置
            {
                for (int i = 0; i < 5; i++)
                {
                    if (nowCubePos[i, 0] != -1)
                    {
                        block[nowCubePos[i, 0], nowCubePos[i, 1]].cube_state = CUBE_STATE.NONE;
                        nowCubePos[i, 0] = reset[i, 0] + tempPosition[0];
                        nowCubePos[i, 1] = reset[i, 1] + tempPosition[1];
                        block[nowCubePos[i, 0], nowCubePos[i, 1]].cube_state = CUBE_STATE.MOVE;
                        block[nowCubePos[i, 0], nowCubePos[i, 1]].cube = cubeType;
                    }
                }
                tetrisView.ViewUpdate();
            }
        }

        public void LevelUp()
        {
            if (timer > 0 && timer % 10 == 0)
            {
                this.SetLevel(this.GetLevel() + 1);               
                tetrisView.TimerIntervalSet((int)(timerInterval *= (float)0.9));
            }
        }

        public void CubeChangeNext()
        {
            if (!CubeIsChanged)
            {
                CubeIsChanged = true;
                CUBE now = new CUBE();
                for (int i = 0; i < blockx; i++)
                {
                    for (int j = 0; j < blocky; j++)
                    {
                        if ((block[i, j].cube_state == CUBE_STATE.MOVE))
                        {
                            now = block[i, j].cube;
                            block[i, j] = new Block(CUBE.NONE, CUBE_STATE.NONE);
                        }
                    }
                }
                CubeCreate();
                NextCreate(now);
            }
            tetrisView.ViewUpdate();
        }
        //////////////////////////////////////////////////
    }
}
