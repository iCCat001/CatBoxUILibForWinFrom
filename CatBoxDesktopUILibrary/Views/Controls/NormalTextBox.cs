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
    [ToolboxItem(true)]
    public partial class NormalTextBox : TextBox
    {
        #region Win32 API
        /// <summary>
        /// Win32API 获取系统消息
        /// </summary>
        /// <param name="hWnd">句柄</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>
        /// 释放系统绘制资源（允许绘制）
        /// </summary>
        /// <param name="hWnd">句柄</param>
        /// <param name="hDC">绘制对象句柄</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        #endregion

        #region 属性
        private Color borderColor = Color.Black;

        [Category("外观")]
        [Description("边框颜色，需要设置BorderStyle为FixedSingle才会生效")]
        [DefaultValue(typeof(Color), "#FFFFFF")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();//强制重绘
            }
        }

        #endregion

        public NormalTextBox()
        {
            InitializeComponent();
            //this.SetAutoSizeMode(AutoSizeMode.GrowOnly);
            //this.AutoSize = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //MSDN:TextBox属性不建议使用OnPaint事件进行绘制重写
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if(m.Msg == 0xF || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);

                if(m.HWnd.ToInt32() != 0)
                {
                    Pen penBorder = new Pen(this.BorderColor,1.0f);
                    System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//抗锯齿
                    g.DrawRectangle(penBorder, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                    //g.DrawRectangle(new Pen(this.BackColor), new Rectangle(1, 1, this.Width - 2, this.Height - 2));//防止绘制成实心
                    penBorder.Dispose();
                }

                m.Result = IntPtr.Zero;
                ReleaseDC(m.HWnd, hDC);
            }
        }
    }
}
