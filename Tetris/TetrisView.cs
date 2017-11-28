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

        private TetrisModel tetrisModel;
        private TetrisControl tetrisControl;

        public TetrisView()
        {
            // init component
            InitializeComponent();
            MakeMainBlock();
            SkinChange();

            // create "M" V "C"
            tetrisModel = new TetrisModel(this);
            tetrisControl = new TetrisControl(tetrisModel);
        }

        // for child class to change the form style
        virtual public void SkinChange()
        {
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

        // some event by UI
        // TODO: here
    }
}
