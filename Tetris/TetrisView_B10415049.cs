using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisView_B10415049 : TetrisView
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.levelLabel.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.levelLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.levelLabel.Location = new System.Drawing.Point(238, 52);
            this.levelLabel.Size = new System.Drawing.Size(200, 40);
            this.levelLabel.Text = "Level : 1";
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.scoreLabel.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreLabel.Location = new System.Drawing.Point(307, 354);
            this.scoreLabel.Size = new System.Drawing.Size(224, 73);
            this.scoreLabel.Text = "Score : 0";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.timeLabel.Font = new System.Drawing.Font("微軟正黑體", 40F, System.Drawing.FontStyle.Bold);
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeLabel.Location = new System.Drawing.Point(218, 172);
            this.timeLabel.Size = new System.Drawing.Size(313, 82);
            this.timeLabel.Text = "Time : 0";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(162, 418);
            this.stopButton.Size = new System.Drawing.Size(50, 20);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(86, 418);
            this.pauseButton.Size = new System.Drawing.Size(50, 20);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 418);
            this.startButton.Size = new System.Drawing.Size(50, 20);
            // 
            // blockPanel
            // 
            this.blockPanel.Location = new System.Drawing.Point(12, 12);
            // 
            // nextPanel
            // 
            this.nextPanel.Location = new System.Drawing.Point(450, 12);
            // 
            // TetrisView_B10415049
            // 
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(546, 449);
            this.Name = "TetrisView_B10415049";
            this.ResumeLayout(false);

        }
    }
}
