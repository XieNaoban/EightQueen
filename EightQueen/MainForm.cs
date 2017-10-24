using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EightQueen
{
    public partial class MainForm : Form
    {
        private int FrameLength = 30;
        private int Fwidth, Fheight, Fleft, Fright, Ftop, Fbottom, Flength, Fdiameter;

        private float Dif;

        [DllImport("user32 ")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32 ")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        public MainForm()
        {
            InitializeComponent();
            Dif = 0.8f;
            Width = 400;
            Height = 600;

            PannelForm pForm = new PannelForm();
            pForm.Show();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (Program.Board.Get(0) == 0 && Program.Board.Get(1) == 1) PaintQueens(Color.Orange);
            else PaintQueens(Color.LightGreen);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (Program.Board.Get(0) == 0 && Program.Board.Get(1) == 1) PaintQueens(Color.Orange);
            else PaintQueens(Color.LightGreen);
        }

        public void PaintQueens(Color c)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics grp = Graphics.FromImage(bmp);
            grp.Clear(Color.Azure);
            Pen pen;

            CalFrame();

            pen = new Pen(Brushes.DeepSkyBlue, Flength / 160);
            for (int i = 1; i < 8; ++i)
            {
                grp.DrawLine(pen, new Point(Fleft + i * Fdiameter, Ftop), new Point(Fleft + i * Fdiameter, Fbottom));
                grp.DrawLine(pen, new Point(Fleft, Ftop + i * Fdiameter), new Point(Fright, Ftop + i * Fdiameter));
            }

            pen = new Pen(Brushes.DodgerBlue, Flength / 100);
            grp.DrawLine(pen, new Point(Fleft, Ftop), new Point(Fright, Ftop));
            grp.DrawLine(pen, new Point(Fright, Ftop), new Point(Fright, Fbottom));
            grp.DrawLine(pen, new Point(Fleft, Fbottom), new Point(Fright, Fbottom));
            grp.DrawLine(pen, new Point(Fleft, Ftop), new Point(Fleft, Fbottom));

            SolidBrush brush = new SolidBrush(c);
            Rectangle rect;
            int dif = (int)((1.0f - Dif) * Fdiameter/2);

            for (int i = 0; i < 8; ++i)
            {
                rect = new Rectangle(Fleft + Program.Board.Get(i) * Fdiameter + dif, Ftop + i * Fdiameter + dif, Fdiameter - 2 * dif, Fdiameter - 2 * dif);
                grp.FillEllipse(brush, rect);
            }

            this.CreateGraphics().DrawImage(bmp, 0, 0);
        }

        private void CalFrame()
        {
            int width = this.Width - 17;
            int height = this.Height - 40;
            Fwidth = width - FrameLength * 2;
            Fheight = height - FrameLength * 2;
            Flength = (Math.Min(Fwidth, Fheight) / 8) * 8;
            Fleft = (width - Flength) / 2;
            Fright = Fleft + Flength;
            Ftop = (height - Flength) / 2;
            Fbottom = Ftop + Flength;

            Fdiameter = Flength / 8;
        }
    }
}
