using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisView_B10415022: TetrisView
    {
        override public void SkinChange()
        {
            ccMap = new Dictionary<TetrisModel.CUBE, Color>();
            ccMap.Add(TetrisModel.CUBE.NONE, Color.Black);
            ccMap.Add(TetrisModel.CUBE.I, Color.Purple);
            ccMap.Add(TetrisModel.CUBE.L, Color.Indigo);
            ccMap.Add(TetrisModel.CUBE.L_RE, Color.Blue);
            ccMap.Add(TetrisModel.CUBE.S, Color.Red);
            ccMap.Add(TetrisModel.CUBE.S_RE, Color.Orange);
            ccMap.Add(TetrisModel.CUBE.SQUARE, Color.Green);
            ccMap.Add(TetrisModel.CUBE.T, Color.Yellow);
            InitializeComponent();
            return;
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.levelLabel.Font = new System.Drawing.Font("Viner Hand ITC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.levelLabel.Location = new System.Drawing.Point(334, 36);
            this.levelLabel.Size = new System.Drawing.Size(200, 40);
            this.levelLabel.Text = "Level : 1";
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.scoreLabel.Font = new System.Drawing.Font("Viner Hand ITC", 20.25F, System.Drawing.FontStyle.Bold);
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.scoreLabel.Location = new System.Drawing.Point(261, 263);
            this.scoreLabel.Size = new System.Drawing.Size(224, 73);
            this.scoreLabel.Text = "Score : 0";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.timeLabel.Font = new System.Drawing.Font("Viner Hand ITC", 20.25F, System.Drawing.FontStyle.Bold);
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.timeLabel.Location = new System.Drawing.Point(261, 171);
            this.timeLabel.Size = new System.Drawing.Size(313, 82);
            this.timeLabel.Text = "Time : 0";
            // 
            // blockPanel
            // 
            this.blockPanel.Location = new System.Drawing.Point(12, 12);
            // 
            // nextPanel
            // 
            this.nextPanel.Location = new System.Drawing.Point(237, 13);
            // 
            // startButton
            // 
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.startButton.Font = new System.Drawing.Font("細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.startButton.Location = new System.Drawing.Point(267, 371);
            this.startButton.Size = new System.Drawing.Size(50, 41);
            // 
            // pauseButton
            // 
            this.pauseButton.Font = new System.Drawing.Font("細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pauseButton.Location = new System.Drawing.Point(362, 371);
            this.pauseButton.Size = new System.Drawing.Size(48, 41);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(484, 13);
            this.stopButton.Size = new System.Drawing.Size(50, 20);
            // 
            // TetrisView_B10415022
            // 
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(546, 449);
            this.Name = "TetrisView_B10415022";
            this.ResumeLayout(false);

        }
    }
}
