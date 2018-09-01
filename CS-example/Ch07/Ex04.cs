using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Data;

namespace Ch07
{
    public partial class Ex04 : Form
    {
        private bool line;
        private bool rect;
        private bool circle;
        private Point start;
        private Point finish;
        private Pen pen;
        private int nline;
        private int nrect;
        private int ncircle;
        private int i;
        private int thick;
        private bool isSolid;
        private MyLines[] mylines;
        private MyRect[] myrect;
        private MyCircle[] mycircle;

        public Ex04()
        {
            InitializeComponent();
            SetupVar();
        }

        private void SetupVar()
        {
            i = 0;
            thick = 1;
            isSolid = true;
            line = false;
            rect = false;
            circle = false;
            start = new Point(0, 0);
            finish = new Point(0, 0);
            pen = new Pen(Color.Black);
            mylines = new MyLines[100];
            myrect = new MyRect[100];
            mycircle = new MyCircle[100];
            nline = 0;
            nrect = 0;
            ncircle = 0;
            line0Button.Pushed = false;
            line1Button.Pushed = true;
            line2Button.Pushed = false;
            line3Button.Pushed = false;

        }
    }
}
