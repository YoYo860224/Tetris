using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new TetrisView());
            // Application.Run(new TetrisView_B10415022());
            // Application.Run(new TetrisView_B10415030());
            // Application.Run(new TetrisView_B10415046());
            // Application.Run(new TetrisView_B10415047());
            Application.Run(new TetrisView_B10415049());
   
        }
    }
}
