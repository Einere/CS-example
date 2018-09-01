using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace Ch07
{
    class MyLines
    {
        private Point[] point = new Point[2];
        private int thick;
        private bool isSolid;

        public MyLines()
        {
            point[0] = new Point();
            point[1] = new Point();
            thick = 1;
            isSolid = true;
        }

        public void setPoint(Point start, Point finish, int thick, bool isSolid)
        {
            point[0] = start;
            point[1] = finish;
            this.thick = thick;
            this.isSolid = isSolid;
        }

        public Point getPoint()
        {
            return point[0];
        }

        public Point getPoint2()
        {
            return point[1];
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
