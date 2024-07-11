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
    public partial class NormalComboButton : UserControl
    {
        #region 属性
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("标题文字")]
        public string Title
        {
            set
            {
                labTitle.Text = value;
                //AutoReMiddle();
                this.Invalidate();
            }
            get
            {
                return labTitle.Text;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("标题字体")]
        public Font TitleFont
        {
            set
            {
                labTitle.Font = value;
                //AutoReMiddle();
                this.Invalidate();
            }
            get
            {
                return labTitle.Font;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("显示文字（已重定向至标题文字）")]
        public new string Text
        {
            get
            {
                return labTitle.Text;
            }
            set
            {
                labTitle.Text = value;
                //AutoReMiddle();
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("显示字体（已重定向至标题字体）")]
        public new Font Font
        {
            set
            {
                labTitle.Font = value;
                //AutoReMiddle();
                this.Invalidate();
            }
            get
            {
                return labTitle.Font;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("按钮图标")]
        public Image Icon
        {
            set
            {
                pbIcon.BackgroundImage = value;
            }
            get
            {
                return pbIcon.BackgroundImage;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("图标背景色")]
        public Color IconBackgroundColor
        {
            set
            {
                pbIcon.BackColor = value;
            }
            get
            {
                return pbIcon.BackColor;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("图标布局方式")]
        public ImageLayout IconImageLayout
        {
            set
            {
                pbIcon.BackgroundImageLayout = value;
            }
            get
            {
                return pbIcon.BackgroundImageLayout;
            }
        }

        public Color ColorHover;

        private Color BGColor;
        #endregion

        public NormalComboButton()
        {
            InitializeComponent();
            labTitle.BackColorChanged += LabTitle_BackColorChanged;
        }

        private void LabTitle_BackColorChanged(object sender, EventArgs e)
        {
            labTitle.ForeColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(labTitle.BackColor);
        }

        private void AutoReMiddle()
        {
            labTitle.Top = pbIcon.Bottom + 10;
            labTitle.Invalidate();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            try
            {
                e.Control.MouseEnter += NormalComboButton_MouseEnter;
                e.Control.MouseLeave += NormalComboButton_MouseLeave;
                e.Control.MouseDown += NormalComboButton_MouseDown;
                e.Control.MouseUp += NormalComboButton_MouseUp;
            }
            catch
            {

            }
        }
        private void NormalComboButton_Click(object sender, EventArgs e)
        {

        }

        private void NormalComboButton_SizeChanged(object sender, EventArgs e)
        {
            AutoReMiddle();
        }

        private void NormalComboButton_MouseEnter(object sender, EventArgs e)
        {
            BGColor = this.BackColor;//备份背景色
            this.BackColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.ChangeBrightness(BGColor, +20);
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    
                    //色彩亮度提升
                    ctl.BackColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.ChangeBrightness(BGColor, +20);
                }
                catch
                {

                }
            }
            this.Invalidate();
        }

        private void NormalComboButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = BGColor;//还原背景色
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    //还原
                    ctl.BackColor = BGColor;
                }
                catch
                {

                }
            }
        }

        private void NormalComboButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.ChangeBrightness(BGColor, -20);
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    //色彩亮度降低
                    ctl.BackColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.ChangeBrightness(BGColor, -20);
                }
                catch
                {

                }
            }
            this.Invalidate();
        }

        private void NormalComboButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.ChangeBrightness(BGColor, +20);
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    //色彩亮度降低
                    ctl.BackColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.ChangeBrightness(BGColor, +20);
                }
                catch
                {

                }
            }
            this.Invalidate();
        }

        private void pbIcon_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void labTitle_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
