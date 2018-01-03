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
        private bool hasChange;
        private Block[,] nextBlock;

        private int timer;
        private int score;
        private int level;

        private TetrisView tetrisView;

        public TetrisModel(TetrisView view)
        {
            tetrisView = view;
            InitAll();
        }

        public void InitAll()
        {
            nowState = STATE.STOP;

            block = new Block[24, 10];
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    block[i, j] = new Block(CUBE.NONE,CUBE_STATE.NONE);
                }
            }

            nextBlock = new Block[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    nextBlock[i, j] = new Block(CUBE.NONE, CUBE_STATE.NONE);
                }
            }

            NextCreate();

            hasChange = false;

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
            if (nowState == STATE.STOP)
            {
                InitAll();
                nowStep = 0;
                CubeCreate();
                LevelControl();
            }           
            nowState = STATE.DOING;
            tetrisView.ButtonActive(false, true, true);           
        }

        public void GamePause()
        {
            nowState = STATE.PAUSE;
            tetrisView.ButtonActive(true, false, true);
        }

        public void GameOver()
        {
            nowState = STATE.STOP;
            tetrisView.TimerIntervalSet(30);
            tetrisView.ButtonActive(true, false, false);
        }

        public void CubeAutoDown()
        {
            CubeMoveDown();
            tetrisView.ViewUpdate();
        }

        public void BlockScan()
        {
            // the move block to bottom, need scan.
            hasChange = false;
            int allHas = 0;
      
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((block[i, j].cube_state == CUBE_STATE.MOVE) || (block[i, j].cube_state == CUBE_STATE.JOINT))
                    {
                        if (i == 19)
                        {
                            GameOver();
                            return;
                        }
                        block[i, j].cube_state = CUBE_STATE.OK;
                    }

                    if (block[i, j].cube_state != CUBE_STATE.NONE)
                        allHas++;

                    if (allHas == 10)
                    {
                        DeleteBlockRow(i);
                        i--;
                        allHas = 0;
                    }
                }
                allHas = 0;
            }

            CubeCreate();
            tetrisView.ViewUpdate();
        }

        public void DeleteBlockRow(int i)
        {
            for (int needDownRow = i ; needDownRow < 15; needDownRow++)
            {
                for (int j = 0; j < 10; j++)
                {
                    block[needDownRow, j] = block[needDownRow + 1, j];
                    block[needDownRow + 1, j] = new Block(CUBE.NONE, CUBE_STATE.NONE);
                }
            }
            score += 10;
            LevelControl();
        }

        public void CubeCreate()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    block[i + 18, j + 3] = nextBlock[i, j];
                }
            }

            NextCreate();
            tetrisView.ViewUpdate();
        }

        private void NextCreate()
        {
            Random rand = new Random();
            CUBE nextCube = (CUBE)(rand.Next() % 7 + 1);

            NextCreate(nextCube);
        }

        private void NextCreate(CUBE nextCube)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    nextBlock[i, j] = new Block(CUBE.NONE, CUBE_STATE.NONE);
                }
            }

            switch (nextCube)
            {
                case CUBE.T:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.JOINT);
                    nextBlock[2, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;
                case CUBE.I:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.JOINT);
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
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.JOINT);
                    nextBlock[2, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[0, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;
                case CUBE.L_RE:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[0, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.JOINT);
                    nextBlock[2, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;
                case CUBE.S:
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.JOINT);
                    nextBlock[0, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;
                case CUBE.S_RE:
                    nextBlock[0, 1] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[1, 1] = new Block(nextCube, CUBE_STATE.JOINT);
                    nextBlock[1, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    nextBlock[2, 2] = new Block(nextCube, CUBE_STATE.MOVE);
                    break;
            }

        }

        ///////////////// people Control /////////////////

        public void CubeGoDown()
        {
            while (!CubeMoveDown())

            tetrisView.ViewUpdate();
        }

        public bool CubeMoveDown()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((block[i, j].cube_state == CUBE_STATE.MOVE) || (block[i, j].cube_state == CUBE_STATE.JOINT))
                    {
                        if (i > 0)
                        {
                            if (block[i - 1, j].cube_state == CUBE_STATE.OK)
                            {
                                BlockScan();
                                return true;
                            }
                        }
                        else
                        {
                            BlockScan();
                            return true;
                        }
                    }
                }
            }

            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((block[i +1, j].cube_state == CUBE_STATE.MOVE) || (block[i + 1, j].cube_state == CUBE_STATE.JOINT))
                    {
                        block[i, j] = block[i + 1, j];
                        block[i + 1, j] = new Block(CUBE.NONE, CUBE_STATE.NONE);
                    }
                }
            }

            tetrisView.ViewUpdate();
            return false;
        }

        public void CubeMoveRight()
        {
            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((block[i, j].cube_state == CUBE_STATE.MOVE) || (block[i, j].cube_state == CUBE_STATE.JOINT))
                    {
                        if (j == 9)
                        {
                            return;
                        }

                        if (block[i, j + 1].cube_state == CUBE_STATE.OK)
                        {
                            return;
                        }
                    }
                }
            }

            for (int j = 8; j >= 0; j--)
            {
                for (int i = 0; i < 23; i++)
                {
                    if ((block[i, j].cube_state == CUBE_STATE.MOVE) || (block[i, j].cube_state == CUBE_STATE.JOINT))
                    {
                        block[i, j + 1] = block[i, j];
                        block[i, j] = new Block(CUBE.NONE, CUBE_STATE.NONE);
                    }
                }
            }

            tetrisView.ViewUpdate();
        }

        public void CubeMoveLeft()
        {
            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((block[i, j].cube_state == CUBE_STATE.MOVE) || (block[i, j].cube_state == CUBE_STATE.JOINT))
                    {
                        if (j == 0)
                        {
                            return;
                        }

                        if (block[i, j - 1].cube_state == CUBE_STATE.OK)
                        {
                            return;
                        }
                    }
                }
            }

            for (int j = 1; j <10; j++)
            {
                for (int i = 0; i < 23; i++)
                {
                    if ((block[i, j].cube_state == CUBE_STATE.MOVE) || (block[i, j].cube_state == CUBE_STATE.JOINT))
                    {
                        block[i, j - 1] = block[i, j];
                        block[i, j] = new Block(CUBE.NONE, CUBE_STATE.NONE);
                    }
                }
            }

            tetrisView.ViewUpdate();
        }

        public void CubeRotate()
        {
            int[,] theMoving = new int[4, 2];
            int[] theJoint = new int[2];
            CUBE cubeType = CUBE.NONE;
            int nowWho = 0;

            // find the moving cube
            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (block[i, j].cube_state == CUBE_STATE.MOVE)
                    {
                        cubeType = block[i, j].cube;

                        theMoving[nowWho, 0] = i;
                        theMoving[nowWho, 1] = j;
                        nowWho++;
                    }
                    else if (block[i, j].cube_state == CUBE_STATE.JOINT)
                    {
                        theMoving[3, 0] = i;
                        theMoving[3, 1] = j;
                        theJoint[0] = i;
                        theJoint[1] = j;
                    }
                }
            }

            if (cubeType == CUBE.SQUARE || cubeType==CUBE.NONE)
            {
                return;
            }

            int[,] willTo = new int[4, 2];

            for (int i = 0; i < 3; i++)
            {
                willTo[i, 1] = theMoving[i, 0] - theJoint[0];
                willTo[i, 0] = theMoving[i, 1] - theJoint[1];
                willTo[i, 0] *= -1;

                willTo[i, 0] += theJoint[0];
                willTo[i, 1] += theJoint[1];
            }

            // check over edge
            bool overEdgeL = false;
            bool overEdgeR = false;
            do
            {
                overEdgeL = false;
                overEdgeR = false;

                for (int i = 0; i < 3; i++)
                {
                    if (willTo[i, 1] < 0)
                    {
                        overEdgeL = true;
                    }

                    if (willTo[i, 1] > 9)
                    {
                        overEdgeR = true;
                    }
                }

                if (overEdgeL)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        willTo[i, 1]++;
                    }
                    theJoint[1]++;
                }

                if (overEdgeR)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        willTo[i, 1]--;
                    }
                    theJoint[1]--;
                }
            } while (overEdgeL || overEdgeR);

            // check overlap

            for (int i = 0; i < 3; i++)
            {
                if (block[willTo[i, 0], willTo[i, 1]].cube_state == CUBE_STATE.OK)
                    return;
            }
            if (block[theJoint[0], theJoint[1]].cube_state == CUBE_STATE.OK)
                return;

            // do

            for (int i = 0; i < 4; i++)
            {
                block[theMoving[i, 0], theMoving[i, 1]] = new Block(CUBE.NONE, CUBE_STATE.NONE);
            }

            for (int i = 0; i < 3; i++)
            {
                block[willTo[i,0], willTo[i,1]] = new Block(cubeType, CUBE_STATE.MOVE);
            }

            block[theJoint[0], theJoint[1]] = new Block(cubeType, CUBE_STATE.JOINT);

            tetrisView.ViewUpdate();
        }

        public void CubeChangeNext()
        {
            if (!hasChange)
            {
                hasChange = true;

                CUBE now = new CUBE();
                for (int i = 0; i < 24; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if ((block[i, j].cube_state == CUBE_STATE.MOVE) || (block[i, j].cube_state == CUBE_STATE.JOINT))
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

        //////////////////// timer ///////////////////////

        private void LevelControl()
        {
            level = score / 100 + 1;
            if (level > 10)
                level = 10;
            tetrisView.TimerIntervalSet(1000 - level * 90);
        }

        public void SecTimerControl()
        {
            timer++;
        }

        ///////////////// Show something /////////////////

        private int nowStep = 0;

        public void GameOverPanel()
        {
            int[,] over_text = new int[,]{ 
                { 19, 3 },{ 19, 4 },{ 19, 5 },{ 19, 6 },
                { 18, 3 },                    { 18, 6 },
                { 17, 3 },                    { 17, 6 },
                { 16, 3 },{ 16, 4 },{ 16, 5 },{ 16, 6 },

                { 14, 3 },                    { 14, 6 },
                { 13, 3 },                    { 13, 6 },
                { 12, 3 },                    { 12, 6 },
                          { 11, 4 },{ 11, 5 },

                { 9, 3 }, {  9, 4 },{  9, 5 },{  9, 6 },
                { 8, 3 }, 
                { 7, 3 }, {  7, 4 },{  7, 5 },
                { 6, 3 },
                { 5, 3 }, {  5, 4 },{  5, 5 },{  5, 6 },

                { 4, 3 }, {  4, 4 },{  4, 5 },{  4, 6 },
                { 3, 3 },                     {  3, 6 },
                { 2, 3 }, {  2, 4 },{  2, 5 },{  2, 6 },
                { 1, 3 },           {  1, 5 },
                { 0, 3 },                     {  0, 6 },
            };
            
            int x = nowStep / 10;
            int y = nowStep % 10;

            block[x, y].cube = CUBE.SQUARE;
            block[x, y].cube_state = CUBE_STATE.OK;

            for (int i = 0; i < over_text.Length / 2; i++)
            {
                if (over_text[i, 0] == x && over_text[i, 1] == y)
                {
                    if (x > 15)
                        block[x, y].cube = CUBE.T;
                    else if (x > 10)
                        block[x, y].cube = CUBE.S;
                    else if (x > 4)
                        block[x, y].cube = CUBE.L;
                    else
                        block[x, y].cube = CUBE.I;
                }
            }

            nowStep++;

            if (nowStep > 200)
                nowStep = 0;

            tetrisView.ViewUpdate();
        }
    }
}
