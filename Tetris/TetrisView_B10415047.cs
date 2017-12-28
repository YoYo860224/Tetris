using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisView_B10415047 : TetrisView
    {
        override public void SkinChange()
        {
            ccMap = new Dictionary<TetrisModel.CUBE, Color>();
            ccMap.Add(TetrisModel.CUBE.NONE, Color.FromArgb(240, 240, 240));
            ccMap.Add(TetrisModel.CUBE.T, Color.FromArgb(30, 30, 30));
            ccMap.Add(TetrisModel.CUBE.I, Color.FromArgb(60, 60, 60));
            ccMap.Add(TetrisModel.CUBE.SQUARE, Color.FromArgb(80, 80, 80));
            ccMap.Add(TetrisModel.CUBE.L, Color.FromArgb(100, 100, 100));
            ccMap.Add(TetrisModel.CUBE.L_RE, Color.FromArgb(120, 120, 120));
            ccMap.Add(TetrisModel.CUBE.S, Color.FromArgb(140, 140, 140));
            ccMap.Add(TetrisModel.CUBE.S_RE, Color.FromArgb(160, 160, 160));
            InitializeComponent();
            return;
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.levelLabel.Font = new System.Drawing.Font("SentyCHALK", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.levelLabel.Location = new System.Drawing.Point(28, 35);
            this.levelLabel.Size = new System.Drawing.Size(200, 40);
            this.levelLabel.Text = "Level : 1";
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.scoreLabel.Font = new System.Drawing.Font("SentyCHALK", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreLabel.Location = new System.Drawing.Point(28, 108);
            this.scoreLabel.Size = new System.Drawing.Size(224, 73);
            this.scoreLabel.Text = "Score : 0";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.timeLabel.Font = new System.Drawing.Font("SentyCHALK", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeLabel.Location = new System.Drawing.Point(23, 181);
            this.timeLabel.Size = new System.Drawing.Size(313, 82);
            this.timeLabel.Text = "Time : 0";
            // 
            // blockPanel
            // 
            this.blockPanel.BackColor = System.Drawing.Color.White;
            this.blockPanel.Location = new System.Drawing.Point(333, 22);
            // 
            // nextPanel
            // 
            this.nextPanel.BackColor = System.Drawing.Color.White;
            this.nextPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nextPanel.Location = new System.Drawing.Point(245, 22);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(113, 292);
            this.startButton.Size = new System.Drawing.Size(79, 56);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(13, 292);
            this.pauseButton.Size = new System.Drawing.Size(79, 56);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(215, 292);
            this.stopButton.Size = new System.Drawing.Size(79, 56);
            // 
            // TetrisView_B10415047
            // 
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(546, 449);
            this.Name = "TetrisView_B10415047";
            this.ResumeLayout(false);

        }
    }
}
