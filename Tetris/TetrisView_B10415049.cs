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
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 20; j++)
                {
                    allBolck[i, j].BackColor = Color.Red;
                }
        }
    }
}
