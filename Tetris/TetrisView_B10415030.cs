using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class TetrisView_B10415030 : TetrisView
    {
        override public void SkinChange()
        {
            ccMap = new Dictionary<TetrisModel.CUBE, Color>();
            ccMap.Add(TetrisModel.CUBE.NONE, Color.Black);
            ccMap.Add(TetrisModel.CUBE.T, Color.Yellow);
            ccMap.Add(TetrisModel.CUBE.I, Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(207)))), ((int)(((byte)(87))))));
            ccMap.Add(TetrisModel.CUBE.SQUARE, Color.OrangeRed);
            ccMap.Add(TetrisModel.CUBE.L, Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(142)))), ((int)(((byte)(85))))));
            ccMap.Add(TetrisModel.CUBE.L_RE, Color.Orange);
            ccMap.Add(TetrisModel.CUBE.S, Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(105)))), ((int)(((byte)(30))))));
            ccMap.Add(TetrisModel.CUBE.S_RE, Color.Brown);

            InitializeComponent();
            return;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // levelLabel
            // 
            this.levelLabel.Font = new System.Drawing.Font("Segoe Marker", 19.8F);
            this.levelLabel.Location = new System.Drawing.Point(339, 186);
            this.levelLabel.Size = new System.Drawing.Size(131, 50);
            this.levelLabel.Text = "Level : 1";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Segoe Marker", 19.8F);
            this.scoreLabel.Location = new System.Drawing.Point(211, 186);
            this.scoreLabel.Size = new System.Drawing.Size(134, 52);
            this.scoreLabel.Text = "Score : 0";
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Segoe Marker", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(233, 43);
            this.timeLabel.Size = new System.Drawing.Size(300, 49);
            this.timeLabel.Text = "Time : 0";
            // 
            // nextPanel
            // 
            this.nextPanel.Location = new System.Drawing.Point(373, 22);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Orange;
            this.startButton.Location = new System.Drawing.Point(217, 335);
            this.startButton.Size = new System.Drawing.Size(71, 46);
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.DarkOrange;
            this.pauseButton.Location = new System.Drawing.Point(296, 335);
            this.pauseButton.Size = new System.Drawing.Size(71, 46);
            this.pauseButton.UseVisualStyleBackColor = false;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.OrangeRed;
            this.stopButton.Location = new System.Drawing.Point(373, 335);
            this.stopButton.Size = new System.Drawing.Size(71, 46);
            this.stopButton.UseVisualStyleBackColor = false;
            // 
            // TetrisView_B10415030
            // 
            this.ClientSize = new System.Drawing.Size(473, 419);
            this.Margin = new System.Windows.Forms.Padding(65, 4, 65, 4);
            this.Name = "TetrisView_B10415030";
            this.Text = "TetrisView_B10415030";
            this.ResumeLayout(false);

        }

    }
}
