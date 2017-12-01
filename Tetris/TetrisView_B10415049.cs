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
            ccMap.Add(TetrisModel.CUBE.NONE, Color.Black);
            ccMap.Add(TetrisModel.CUBE.T, Color.Blue);
            ccMap.Add(TetrisModel.CUBE.I, Color.Red);
            ccMap.Add(TetrisModel.CUBE.SQUARE, Color.Green);
            ccMap.Add(TetrisModel.CUBE.L, Color.Purple);
            ccMap.Add(TetrisModel.CUBE.L_RE, Color.Cyan);
            ccMap.Add(TetrisModel.CUBE.S, Color.Gold);
            ccMap.Add(TetrisModel.CUBE.S_RE, Color.Firebrick);

            InitializeComponent();
            return;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Coral;
            this.stopButton.UseVisualStyleBackColor = false;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pauseButton.UseVisualStyleBackColor = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // TetrisView_B10415049
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Name = "TetrisView_B10415049";
            this.ResumeLayout(false);
        }
    }
}
