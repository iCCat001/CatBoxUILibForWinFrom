using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public partial class NormalCircleButton : Button
    {
        public NormalCircleButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(pevent);
            base.OnPaint(e);//递归  每次重新都发生此方法,保证其形状为自定义形状
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(2, 2, this.Width - 6, this.Height - 6);
            Graphics g = e.Graphics;
            g.DrawEllipse(new Pen(Color.Transparent, 2), 2, 2, Width - 6, Height - 6);
            Region = new Region(path);
        }
    }
}
