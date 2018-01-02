using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisView_B10415046 : TetrisView
    {
        override public void SkinChange()
        {
            ccMap = new Dictionary<TetrisModel.CUBE, Color>();
            ccMap.Add(TetrisModel.CUBE.NONE, Color.Black);
            ccMap.Add(TetrisModel.CUBE.I, Color.Green);
            ccMap.Add(TetrisModel.CUBE.L, Color.LightBlue);
            ccMap.Add(TetrisModel.CUBE.L_RE, Color.Purple);
            ccMap.Add(TetrisModel.CUBE.S, Color.Orange);
            ccMap.Add(TetrisModel.CUBE.S_RE, Color.Yellow);
            ccMap.Add(TetrisModel.CUBE.SQUARE, Color.Blue);
            ccMap.Add(TetrisModel.CUBE.T, Color.Red);
            InitializeComponent();
            return;
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.Orange;
            this.levelLabel.Font = new System.Drawing.Font("Neon Lights", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.levelLabel.Location = new System.Drawing.Point(226, 157);
            this.levelLabel.Size = new System.Drawing.Size(200, 56);
            this.levelLabel.Text = "Level : 1";
            this.levelLabel.Click += new System.EventHandler(this.levelLabel_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Orange;
            this.scoreLabel.Font = new System.Drawing.Font("Neon Lights", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreLabel.Location = new System.Drawing.Point(226, 106);
            this.scoreLabel.Size = new System.Drawing.Size(224, 70);
            this.scoreLabel.Text = "Score : 0";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Orange;
            this.timeLabel.Font = new System.Drawing.Font("Neon Lights", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeLabel.Location = new System.Drawing.Point(226, 213);
            this.timeLabel.Size = new System.Drawing.Size(230, 66);
            this.timeLabel.Text = "Time : 0";
            this.timeLabel.Click += new System.EventHandler(this.timeLabel_Click);
            // 
            // blockPanel
            // 
            this.blockPanel.BackColor = System.Drawing.Color.White;
            this.blockPanel.Location = new System.Drawing.Point(13, 22);
            // 
            // nextPanel
            // 
            this.nextPanel.BackColor = System.Drawing.Color.White;
            this.nextPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nextPanel.Location = new System.Drawing.Point(233, 22);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Peru;
            this.startButton.Location = new System.Drawing.Point(233, 266);
            this.startButton.Size = new System.Drawing.Size(79, 56);
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Peru;
            this.pauseButton.Location = new System.Drawing.Point(320, 316);
            this.pauseButton.Size = new System.Drawing.Size(79, 56);
            this.pauseButton.UseVisualStyleBackColor = false;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Peru;
            this.stopButton.Location = new System.Drawing.Point(417, 366);
            this.stopButton.Size = new System.Drawing.Size(79, 56);
            this.stopButton.UseVisualStyleBackColor = false;
            // 
            // TetrisView_B10415046
            // 
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(546, 449);
            this.Name = "TetrisView_B10415046";
            this.ResumeLayout(false);

        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void levelLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
