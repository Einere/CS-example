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
    public partial class Ex02 : Form
    {
        public Ex02()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = pictureBox1.Left;
            int y = pictureBox1.Top;
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            x -= 5;

            if (x <= -pictureBox1.Width) x = this.Width;
            pictureBox1.SetBounds(x, y, w, h);


        }
    }
}
