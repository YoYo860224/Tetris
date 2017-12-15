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
            ccMap.Add(TetrisModel.CUBE.SQUARE, Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(18))))));
            ccMap.Add(TetrisModel.CUBE.L, Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(142)))), ((int)(((byte)(85))))));
            ccMap.Add(TetrisModel.CUBE.L_RE, Color.Orange);
            ccMap.Add(TetrisModel.CUBE.S, Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(105)))), ((int)(((byte)(30))))));
            ccMap.Add(TetrisModel.CUBE.S_RE, Color.RosyBrown);

            InitializeComponent();
            return;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.OrangeRed;
            this.stopButton.UseVisualStyleBackColor = false;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.DarkOrange;
            this.pauseButton.UseVisualStyleBackColor = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Orange;
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // TetrisView_B10415030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Margin = new System.Windows.Forms.Padding(65, 4, 65, 4);
            this.Name = "TetrisView_B10415030";
            this.Text = "TetrisView_B10415030";
            this.ResumeLayout(false);

        }

    }
}
