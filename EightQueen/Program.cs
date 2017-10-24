using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EightQueen
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        
        static public EnumQueens Board;
        static public MainForm mForm;

        [STAThread]
        static void Main()
        {
            Board = new EnumQueens();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mForm = new MainForm());
        }
    }
}
