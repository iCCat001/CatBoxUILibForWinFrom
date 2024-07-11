using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CatBoxDesktopUILibrary.Modles;
using CatBoxDesktopUILibrary.Controls;
using System.Drawing.Drawing2D;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public partial class NormalButton : Button
    {
        public enum ButtonTypes { TransportBW, Light, Normal, Safe, SafeLight, Warnning, WarnningLight, Baned, BanedLight }
        private ButtonTypes buttonType = ButtonTypes.Normal;
        private Color SavedColor;
        bool isStyleChanged = true;
        bool swAutoForeColor = true;
        int SavedBoarderWidth = 0;
        public NormalButton()
        {
            InitializeComponent();
        }

        private void NormalButton_Paint(object sender, PaintEventArgs e)
        {
            if (isStyleChanged)
            {
                ButtonType = ButtonType;
                isStyleChanged = false;
            }
        }

        private void NormalButton_MouseEnter(object sender, EventArgs e)
        {
            switch(ButtonType)
            {
                case ButtonTypes.Light:
                    this.BackColor = ColorTheme.ContentColor;
                    this.ForeColor = ThemeHelper.GetForeColor(this.BackColor);
                    if(FlatAppearance.BorderSize != 0)
                    {
                        SavedBoarderWidth = FlatAppearance.BorderSize;
                        FlatAppearance.BorderSize = 0;
                    }
                    break;
                case ButtonTypes.WarnningLight:
                    this.BackColor = ColorTheme.UnSafeColor;
                    this.ForeColor = ThemeHelper.GetForeColor(this.BackColor);
                    if (FlatAppearance.BorderSize != 0)
                    {
                        SavedBoarderWidth = FlatAppearance.BorderSize;
                        FlatAppearance.BorderSize = 0;
                    }
                    break;
                case ButtonTypes.SafeLight:
                    this.BackColor = ColorTheme.SafeColor;
                    this.ForeColor = ThemeHelper.GetForeColor(this.BackColor);
                    if (FlatAppearance.BorderSize != 0)
                    {
                        SavedBoarderWidth = FlatAppearance.BorderSize;
                        FlatAppearance.BorderSize = 0;
                    }
                    break;
            }
            this.Refresh();
        }

        private void NormalButton_MouseLeave(object sender, EventArgs e)
        {
            switch (ButtonType)
            {
                case ButtonTypes.Light:
                    this.BackColor = Color.Transparent;
                    this.ForeColor = ColorTheme.ContentColor;
                    if(SavedBoarderWidth != 0)
                    {
                        FlatAppearance.BorderSize = SavedBoarderWidth;
                    }
                    break;
                case ButtonTypes.WarnningLight:
                    this.BackColor = Color.Transparent;
                    this.ForeColor = ColorTheme.UnSafeColor;
                    if (SavedBoarderWidth != 0)
                    {
                        FlatAppearance.BorderSize = SavedBoarderWidth;
                    }
                    break;
                case ButtonTypes.SafeLight:
                    this.BackColor = Color.Transparent;
                    this.ForeColor = ColorTheme.SafeColor;
                    if (SavedBoarderWidth != 0)
                    {
                        FlatAppearance.BorderSize = SavedBoarderWidth;
                    }
                    break;
            }
            this.Refresh();
        }

        private void NormalButton_Click(object sender, EventArgs e)
        {

        }

        protected override void OnClick(EventArgs e)
        {
            if (this.ButtonType != ButtonTypes.Baned && this.ButtonType != ButtonTypes.BanedLight)
                base.OnClick(e);
        }

        private void NormalButton_EnabledChanged(object sender, EventArgs e)
        {
            if(Enabled)
            {
                this.ButtonType = ButtonTypes.Normal;
            }
            else
            {
                this.ButtonType = ButtonTypes.Baned;
            }
        }

        [Category("外观")]
        [Description("按钮外观样式")]
        [DefaultValue(typeof(ButtonTypes), "Normal")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ButtonTypes ButtonType
        {
            get 
            { 
                return buttonType; 
            }
            set 
            { 
                buttonType = value;
                swAutoForeColor = true;
                this.FlatAppearance.BorderSize = 0;
                switch (ButtonType)
                {
                    case ButtonTypes.TransportBW:
                        swAutoForeColor = true;
                        this.BackColor = Color.Transparent;
                        this.ForeColor = Color.Black;
                        break;
                    case ButtonTypes.Light:
                        swAutoForeColor = false;
                        this.BackColor = Color.Transparent;
                        this.ForeColor = ColorTheme.ContentColor;
                        break;
                    case ButtonTypes.Normal:
                        swAutoForeColor = true;
                        this.BackColor = ColorTheme.ContentColor;
                        this.ForeColor = ThemeHelper.GetForeColor(this.BackColor);
                        break;
                    case ButtonTypes.Warnning:
                        swAutoForeColor = true;
                        this.BackColor = ColorTheme.UnSafeColor;
                        this.ForeColor = ThemeHelper.GetForeColor(this.BackColor);
                        break;
                    case ButtonTypes.WarnningLight:
                        swAutoForeColor = false;
                        this.BackColor = Color.Transparent;
                        this.ForeColor = ColorTheme.UnSafeColor;
                        break;
                    case ButtonTypes.Safe:
                        swAutoForeColor = true;
                        this.BackColor = ColorTheme.SafeColor;
                        this.ForeColor = ThemeHelper.GetForeColor(this.BackColor);
                        break;
                    case ButtonTypes.SafeLight:
                        swAutoForeColor = false;
                        this.BackColor = Color.Transparent;
                        this.ForeColor = ColorTheme.SafeColor;
                        break;
                    case ButtonTypes.Baned:
                        swAutoForeColor = true;
                        this.BackColor = ColorTheme.BanColor;
                        this.ForeColor = ThemeHelper.GetForeColor(this.BackColor);
                        break;
                    case ButtonTypes.BanedLight:
                        swAutoForeColor = false;
                        this.BackColor = Color.Transparent;
                        this.ForeColor = ColorTheme.BanColor;
                        break;
                }
                isStyleChanged = false;
                this.Refresh();
                NormalButton_BackColorChanged(null,null);
            }
        }

        private int radian = 0;
        [Category("外观")]
        [Description("按钮边缘弧度")]
        [DefaultValue(typeof(int), "0")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Radian
        {
            get
            {
                return radian;
            }
            set
            {
                if(value >= 0)
                {
                    //if (value > (Width < Height ? Width : Height) && !DesignMode)
                    //{
                    //    throw new Exception("弧度超过最短边");
                    //}
                    radian = value;
                }
                else
                {
                    throw new Exception("弧度非法范围！");
                }
            }
        }
        private void NormalButton_BackColorChanged(object sender, EventArgs e)
        {
            try
            {
                if(swAutoForeColor)
                    this.ForeColor = ThemeHelper.GetForeColor(ThemeHelper.GetControlDisplayColor(this));
            }
            catch
            {

            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //弧度小于等于1直接跳过
            if (radian <= 1 || radian > (Width < Height ? Width : Height))
            {
                base.OnPaint(pevent);
                return;
            }

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle rect = this.ClientRectangle;
            Pen penBorder = new Pen(FlatAppearance.BorderColor);
            Brush brhRect = new SolidBrush(BackColor);
            Brush b0 = new SolidBrush(this.Parent.BackColor);
            Brush bfont = new SolidBrush(ForeColor);
            try
            {
                g.Clear(this.Parent.BackColor);
                int borderSize = FlatAppearance.BorderSize;
                try
                {
                    GraphicsPath path = new GraphicsPath();

                    //边框宽度大于0时绘制边框
                    if(borderSize > 0)
                    {
                        penBorder.Width = borderSize;
                        path = CatBoxDesktopUILibrary.Controls.Shape2D.GetRoundRect
                            (rect.Left + borderSize / 2, rect.Top + borderSize / 2,
                            rect.Width - borderSize - 1, rect.Height - borderSize - 1,
                            radian);
                        //g.FillPath(brhBorder, path);
                        g.DrawPath(penBorder, path);
                        path.Dispose();
                    }

                    //绘制背景
                    path = CatBoxDesktopUILibrary.Controls.Shape2D.GetRoundRect
                        (rect.Left + borderSize, rect.Top + borderSize,
                        rect.Width - borderSize * 2 - 1, rect.Height - borderSize * 2 - 1,
                        radian);
                    g.FillPath(brhRect, path);
                    path.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine("FillPath:" + e.Message);
                }
                if (this.Text != string.Empty)
                {
                    StringFormat sf = StringFormat.GenericTypographic;
                    sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                    SizeF sizeoftext = g.MeasureString(this.Text, Font);
                    float tx = (float)((this.Width - sizeoftext.Width) / 2.0);
                    float ty = (float)((this.Height - sizeoftext.Height) / 2.0);
                    g.DrawString(this.Text, Font, bfont, tx, ty);
                }
            }
            finally
            {
                b0.Dispose();
                penBorder.Dispose();
                brhRect.Dispose();
                bfont.Dispose();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (Radian >= 2)
            {
                SavedColor = BackColor;
                this.BackColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.ChangeBrightness(this.BackColor, 20);
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (Radian >= 2)
            {
                if (SavedColor != null)
                    this.BackColor = SavedColor;
            }
            base.OnMouseLeave(e);
            
        }
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
}
