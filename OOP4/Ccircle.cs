using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP4
{
    class CCircle
    {
        private PointF center;
        private readonly float radius = 35;
        private readonly RectangleF rect;
        public bool IsSelected = false;
        public CCircle()
        {
            center = new PointF(0, 0);
        }
        public CCircle(float _x, float _y)
        {
            center = new PointF(_x, _y);
            rect = new RectangleF(_x - radius, _y - radius, radius*2, radius*2); ;
        }
        public bool Contains(PointF p)
        {
            return (center.X - p.X) * (center.X - p.X)
                + (center.Y - p.Y) * (center.Y - p.Y) <= radius * radius;
        }
        public void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Black, rect);
            if (IsSelected)
                g.DrawEllipse(Pens.Red, rect);
        }
        public bool circleIsAllowed(PointF newCircle)
        {
            double sumR = radius*2; 
            double dx = center.X - newCircle.X;
            double dy = center.Y - newCircle.Y;
            double squaredDist = dx * dx + dy * dy;
            if (squaredDist < sumR * sumR) return false;
            else return true;
        }
    }
}
