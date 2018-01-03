using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisView : Form
    {
        protected PictureBox[,] allBlock;
        protected PictureBox[,] nextBlock;
        protected Dictionary<TetrisModel.CUBE, Color> ccMap;

        private TetrisModel tetrisModel;
        private TetrisControl tetrisControl;

        public TetrisView()
        {
            // init component
            InitializeComponent();
            MakeMainBlock();
            MakeNextBlock();
            SkinChange();

            // create "M" V "C"
            tetrisModel = new TetrisModel(this);
            tetrisControl = new TetrisControl(tetrisModel);

            ViewUpdate();
        }

        // for child class to change the form style
        virtual public void SkinChange()
        {
            ccMap = new Dictionary<TetrisModel.CUBE, Color>();
            ccMap.Add(TetrisModel.CUBE.NONE, Color.Black);
            ccMap.Add(TetrisModel.CUBE.T, Color.Blue);
            ccMap.Add(TetrisModel.CUBE.I, Color.Red);
            ccMap.Add(TetrisModel.CUBE.SQUARE, Color.Green);
            ccMap.Add(TetrisModel.CUBE.L, Color.Purple);
            ccMap.Add(TetrisModel.CUBE.L_RE, Color.Cyan);
            ccMap.Add(TetrisModel.CUBE.S, Color.Gold);
            ccMap.Add(TetrisModel.CUBE.S_RE, Color.Firebrick);
            return;
        }

        // for initial make mainBlock
        private void MakeMainBlock()
        {
            allBlock = new System.Windows.Forms.PictureBox[20, 10];

            blockPanel.SuspendLayout();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {                
                    allBlock[i, j] = new System.Windows.Forms.PictureBox();
                    allBlock[i, j].Location = new System.Drawing.Point((20 * j), (380 - 20 * i));
                    allBlock[i, j].Name = "pictureBox" + i.ToString() + j.ToString();
                    allBlock[i, j].Size = new System.Drawing.Size(19, 19);
                    allBlock[i, j].TabIndex = 0;
                    allBlock[i, j].TabStop = false;
                    allBlock[i, j].BackColor = Color.Black;

                    blockPanel.Controls.Add(this.allBlock[i, j]);
                }
            }

            blockPanel.ResumeLayout(false);

            //////////////////////   Unknown but maybe use.   ////////////////////////////////
            //   ((System.ComponentModel.ISupportInitialize)(allBlock[i, j])).BeginInit();  //
            //   ((System.ComponentModel.ISupportInitialize)(this.allBolck)).EndInit();     //
            //////////////////////////////////////////////////////////////////////////////////
        }

        // for initial make nextBlock
        private void MakeNextBlock()
        {
            nextBlock = new System.Windows.Forms.PictureBox[4, 4];

            nextPanel.SuspendLayout();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    nextBlock[i, j] = new System.Windows.Forms.PictureBox();
                    nextBlock[i, j].Location = new System.Drawing.Point((20 * j), (60 - 20 * i));
                    nextBlock[i, j].Name = "pictureBox" + i.ToString() + j.ToString();
                    nextBlock[i, j].Size = new System.Drawing.Size(19, 19);
                    nextBlock[i, j].TabIndex = 0;
                    nextBlock[i, j].TabStop = false;
                    nextBlock[i, j].BackColor = Color.Black;

                    nextPanel.Controls.Add(this.nextBlock[i, j]);
                }
            }

            nextPanel.ResumeLayout(false);
        }

        // Update bolck,score,time,levels' pic or txt or color
        public void ViewUpdate()
        {
            BlockPanelUpdate();
            NextPanelUpdate();
            TextComponentUpdate();
        }

        public void BlockPanelUpdate()
        {
            TetrisModel.Block[,] block = tetrisModel.GetBlock();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    allBlock[i, j].BackColor = ccMap[block[i, j].cube];
                }
            }
        }

        public void NextPanelUpdate()
        {
            TetrisModel.Block[,] next = tetrisModel.GetNextBlock();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    nextBlock[i, j].BackColor = ccMap[next[i, j].cube];
                }
            }
        }

        public void TextComponentUpdate()
        {
            timeLabel.Text = "Time : " + tetrisModel.GetTimer();
            levelLabel.Text = "Level : " + tetrisModel.GetLevel();
            scoreLabel.Text = "Score : " + tetrisModel.GetScore();
        }

        public void ButtonActive(bool start, bool pause, bool stop)
        {
            startButton.Enabled = start;
            pauseButton.Enabled = pause;
            stopButton.Enabled = stop;
        }

        public void TimerIntervalSet(int ms)
        {
            timer.Interval = ms;
        }

        // some event by UI
        // TODO: here

        private void startButton_Click(object sender, EventArgs e)
        {
            tetrisControl.UserButton(TetrisControl.BUTTON.START);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            tetrisControl.UserButton(TetrisControl.BUTTON.PAUSE);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            tetrisControl.UserButton(TetrisControl.BUTTON.STOP);
        }

        private void TetrisView_KeyDown(object sender, KeyEventArgs e)
        { 
            tetrisControl.UserKeyDown(e.KeyCode);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tetrisControl.TimerTrigger();
        }

        private void secTimer_Tick(object sender, EventArgs e)
        {
            tetrisControl.SecTimerTrigger();
        }
    }
}
