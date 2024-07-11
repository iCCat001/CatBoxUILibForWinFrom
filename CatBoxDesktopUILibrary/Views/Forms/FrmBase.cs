using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Views.Forms
{
    public partial class FrmBase : Form
    {
        #region 属性

        /// <summary>
        /// 是否显示最大化按钮（已重定向）
        /// </summary>
        [Browsable(true)]
        public new bool MaximizeBox
        {
            get
            {
                return panHeader.Controls.Contains(nbtMax);
            }
            set
            {
                if (!value)
                {
                    panHeader.Controls.Remove(nbtMax);
                }
                else if (!panHeader.Contains(nbtMax))
                {
                    panHeader.Controls.Add(nbtMax);
                }
            }
        }

        /// <summary>
        /// 是否显示最小化按钮（已重定向）
        /// </summary>
        [Browsable(true)]
        public new bool MinimizeBox
        {
            get
            {
                return panHeader.Contains(nbtMini);
            }
            set
            {
                if (!value)
                {
                    panHeader.Controls.Remove(nbtMini);
                }
                else if (!panHeader.Contains(nbtMini))
                {
                    panHeader.Controls.Add(nbtMini);
                }
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗体标题文字")]
        public string Title
        {
            get
            {
                return labTitle.Text;
            }
            set
            {
                labTitle.Text = value;
                //this.Text = value;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("标题栏背景色（前景色自动获取）")]
        public Color HeaderColor
        {
            get
            {
                return panHeader.BackColor;
            }
            set
            {
                panHeader.BackColor = value;
                
                //获取适合的前景色（透明则穿透控件获取）
                panHeader.ForeColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(
                    CatBoxDesktopUILibrary.Controls.ThemeHelper.GetControlDisplayColor(panHeader));
                if(panHeader.ForeColor == Color.Black)
                {
                    nbtClose.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.CloseD;
                    nbtMax.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.MaxD;
                    nbtMini.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.MiniD;
                }
                else
                {
                    nbtClose.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.CloseL;
                    nbtMax.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.MaxL;
                    nbtMini.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.MiniL;
                }

            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("标题栏高度")]
        public int HeaderHeight
        {
            set
            {
                panHeader.Height = value;
                panHeader.Dock = DockStyle.Top;
            }
            get
            {
                return panHeader.Height;
                
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("是否显示标题")]
        public bool ShowTitle
        {
            set
            {
                if(!value)
                {
                    panHeader.Controls.Remove(labTitle);
                }
                else if(!panHeader.Controls.Contains(labTitle))
                {
                    panHeader.Controls.Add(labTitle);
                }
            }
            get
            {
                return panHeader.Controls.Contains(labTitle);
            }
        }
        #endregion

        #region 私有属性

        Point mPoint = new Point(0, 0);

        #endregion

        public FrmBase()
        {
            InitializeComponent();
            ResetHeader();
        }

        #region 私有方法

        private void ResetHeader()
        {
            base.ControlBox = false;
            base.Text = "";//确保不会触发当前类的访问控制器
            ResizeHeader();
            new ToolTip().SetToolTip(nbtMini, "最小化");
            new ToolTip().SetToolTip(nbtMax, "切换窗口形态");
            new ToolTip().SetToolTip(nbtClose, "关闭窗体");
        }

        private void ResizeHeader()
        {
            
            //nbtClose.Size = new Size(panHeader.Height, panHeader.Height);
            nbtMax.Size = nbtClose.Size;
            nbtMini.Size = nbtClose.Size;
        }

        #endregion
        #region 事件响应
        private void nbtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nbtMax_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                panHeader.ForeColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(
                    CatBoxDesktopUILibrary.Controls.ThemeHelper.GetControlDisplayColor(panHeader));
                if (panHeader.ForeColor == Color.Black)
                {
                    nbtMax.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.WindowD;
                }
                else
                {
                    nbtMax.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.WindowL;
                }
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                panHeader.ForeColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(
                    CatBoxDesktopUILibrary.Controls.ThemeHelper.GetControlDisplayColor(panHeader));
                if (panHeader.ForeColor == Color.Black)
                {
                    nbtMax.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.MaxD;
                }
                else
                {
                    nbtMax.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.MaxL;
                }
            }
            
        }

        private void nbtMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void panHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }
        private void FrmBase_SizeChanged(object sender, EventArgs e)
        {
            ResizeHeader();
        }

        #endregion


    }
}
