using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace Ch07
{
    class MyRect
    {
        private Rectangle rect;
        private int thick;
        private bool isSolid;

        public MyRect()
        {
            rect = new Rectangle();
            thick = 1;
            isSolid = true;
        }

        public void setRect(Point start, Point finish, int thick, int isSolid)
        {
            rect.X = Math.Min(start.X, finish.Y);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(finish.Y - start.Y);
            rect.Width = Math.Abs(finish.X - start.X);
            this.thick = thick;
            this.isSolid = true;
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public int getThick()
        {
            return thick;
        }

        public bool getSolid()
        {
            return isSolid;
        }
    }
}
