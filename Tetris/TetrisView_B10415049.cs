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
            return;
        }
    }
}
