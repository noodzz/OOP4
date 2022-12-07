using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows;



namespace OOP4
{
    public partial class Form1 : Form
    {
        private MyStorage<CCircle> circles;
        public Form1()
        {
            InitializeComponent();
            circles = new MyStorage<CCircle>();
        }

        private void SelectCircle(PointF selected_point)
        {
            for (int i = 0; i < circles.Count; i++)
                circles[i].IsSelected = circles[i].Contains(selected_point);    
        }
        private bool AllowCircle(PointF p)
        {
            bool flag = true;
            for (int i = 0; i < circles.Count; i++)
            {
                flag = circles[i].circleIsAllowed(p);
                if (flag == false) break;
            }
            return flag;
        }
        private void PaintBox_MouseClick(object sender, MouseEventArgs e)
        {
   
            if (!AllowCircle(e.Location))
            {
                if (ModifierKeys == Keys.Control)
                    for (int i = 0; i < circles.Count; i++)
                    {
                        if (circles[i].Contains(e.Location))
                            circles[i].IsSelected = true;
                    }
                else SelectCircle(e.Location);
            }
            else
            {
                CCircle c = new CCircle(e.X, e.Y);
                circles.Add(c);
                SelectCircle(e.Location);
            }
            PaintBox.Invalidate();

        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < circles.Count; i++)
                circles[i].Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = circles.Count - 1; i >= 0; i--)
                    if (circles[i].IsSelected)
                    {
                        circles.RemoveAt(i);
                    }
            }
            PaintBox.Invalidate();
        }
    }
}
