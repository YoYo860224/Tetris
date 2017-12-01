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
        protected System.Windows.Forms.PictureBox[,] allBolck;
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
            allBolck = new System.Windows.Forms.PictureBox[10,20];

            
            this.blockPanel.SuspendLayout();

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 20; j++)
                {
                    allBolck[i, j] = new System.Windows.Forms.PictureBox();
                    allBolck[i, j].Location = new System.Drawing.Point((10 + 16 * i), (25 + 16 * j));
                    allBolck[i, j].Name = "pictureBox" + i.ToString() + j.ToString();
                    allBolck[i, j].Size = new System.Drawing.Size(15, 15);
                    allBolck[i, j].TabIndex = 0;
                    allBolck[i, j].TabStop = false;
                    allBolck[i, j].BackColor = Color.Black;

                    blockPanel.Controls.Add(this.allBolck[i, j]);
                }

            
            this.blockPanel.ResumeLayout(false);

            //////////////////////   Unknown but maybe use.   ////////////////////////////////
            //   ((System.ComponentModel.ISupportInitialize)(this.allBolck)).BeginInit();   //
            //   ((System.ComponentModel.ISupportInitialize)(this.allBolck)).EndInit();     //
            //////////////////////////////////////////////////////////////////////////////////
        }

        // for initial make nextBlock
        private void MakeNextBlock()
        {

        }

        // Update bolck,score,time,levels' pic or txt or color
        public void ViewUpdate()
        {

        }

        public void BlockPanelUpdate()
        {

        }

        public void NextPanelUpdate()
        {

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

        }

        private void pauseButton_Click(object sender, EventArgs e)
        {

        }

        private void stopButton_Click(object sender, EventArgs e)
        {

        }

        private void TetrisView_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }

        private void secTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
