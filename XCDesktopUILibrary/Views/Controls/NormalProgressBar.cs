using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CatBoxDesktopUILibrary.Modles;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public partial class NormalProgressBar : ProgressBar
    {
        public NormalProgressBar()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Style = ProgressBarStyle.Continuous;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush brush = null;
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);
            }
            Pen pen = new Pen(this.BackColor, 1);
            e.Graphics.DrawRectangle(pen, rec);
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, rec.Width, rec.Height);


            rec.Width = (int)(rec.Width * ((double)Value / Maximum));
            brush = new SolidBrush(this.ForeColor);
            e.Graphics.FillRectangle(brush, 0, 0, rec.Width, rec.Height);
        }
    }
}
