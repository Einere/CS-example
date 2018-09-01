using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch07
{
    public partial class Ex01 : Form
    {
        private Random rand;
        private int x;
        private int y;
        private Pen whitePen = new Pen(Color.White);
        public Ex01()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
        }

        private void Ex01_Load(object sender, EventArgs e)
        {
            x = (int)this.Width / 2;
            y = (int)this.Height - 140;

            DateTime currentTime = DateTime.Now;
            rand = new Random(currentTime.Millisecond);

            timer1.Interval = 2000;
            timer1.Enabled = true;
        }

        private void Ex01_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen redPen = new Pen(Color.Red);
            SolidBrush redBr = new SolidBrush(Color.IndianRed);
            SolidBrush whiteBr = new SolidBrush(Color.White);

            g.FillEllipse(whiteBr, x, y, 100, 100);
            y -= 80;
            x += 10;
            g.FillEllipse(whiteBr, x, y, 80, 80);
            y -= 60;
            x += 10;
            g.FillEllipse(whiteBr, x, y, 60, 60);

            g.DrawLine(redPen, x - 10, y, x + 70, y);
            g.FillRectangle(redBr, x + 10, y - 40, 40, 40);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            for(int i = 0; i < 400; i++)
            {
                x = rand.Next(1, this.Width);
                y = rand.Next(1, this.Height);
                g.DrawLine(whitePen, x, y, x + 1, y + 1);
            }
        }
    }
}
