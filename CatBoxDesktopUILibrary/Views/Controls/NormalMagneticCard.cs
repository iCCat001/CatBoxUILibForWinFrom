using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public partial class NormalMagneticCard : UserControl
    {
        public enum CardWorkingModes
        {
            Board,
            Select
        }

        private CardWorkingModes workingMode = CardWorkingModes.Board;

        /// <summary>
        /// 
        /// </summary>
        [Category("自定义行为")]
        [Description("卡片的预定义工作模式")]
        [DefaultValue(typeof(CardWorkingModes), "Board")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public CardWorkingModes WorkingMode
        {
            get
            {
                return workingMode;
            }
            set
            {
                workingMode = value;
                if(workingMode == CardWorkingModes.Select)
                {
                    panButtons.Visible = false;
                }
                else
                {
                    panButtons.Visible = true;
                }
            }
        }
        /*
         * 2020.12.08,16:08,C-Cat:新建
         * 
         */
        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("（Beta）以随机色显示所有子控件")]
        [DefaultValue(typeof(Boolean), "False")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool BorderMode
        {
            get
            {
                return borderMode;
            }
            set
            {
                if(borderMode != value)
                {
                    borderMode = value;
                    hasBorderModeChanged = true;
                }
                    
            }
        }
        private bool borderMode = false;

        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("卡片标题")]
        [DefaultValue(typeof(String), "Title")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get
            {
                return labTitle.Text;
            }
            set
            {
                labTitle.Text = value;
                labSubTitle.Left = labTitle.Left + labTitle.Width + 1;
                if ((labTitle.Left + labTitle.Width) >= this.Width)
                {
                    labSubTitle.Visible = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("副标题")]
        [DefaultValue(typeof(String), "SubTitle")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string SubTitle
        {
            get
            {
                return labSubTitle.Text;
            }
            set
            {
                labSubTitle.Text = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("中央图案")]
        [DefaultValue(typeof(Image), null)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image
        {
            get
            {
                return npbLogo.BackgroundImage;
            }
            set
            {
                npbLogo.BackgroundImage = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("信息栏文字")]
        [DefaultValue(typeof(String), "message")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Message
        {
            get
            {
                return labMessage.Text;
            }
            set
            {
                labMessage.Text = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("信息栏文字颜色")]
        [DefaultValue(typeof(Color), "Black")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color MessageColor
        {
            get
            {
                return labMessage.ForeColor;
            }
            set
            {
                labMessage.ForeColor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("第一个按钮的文字")]
        [DefaultValue(typeof(String), "B1")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ButtonText1
        {
            get
            {
                return nbtSure.Text;
            }
            set
            {
                nbtSure.AutoSize = true;
                nbtSure.Text = "";
                nbtSure.Size = new Size(1, 1);
                nbtSure.Refresh();
                nbtSure.AutoSize = true;
                nbtSure.Text = value;
                nbtSure.Refresh();

                nbtSure.Left = nbtUnInstall.Left - nbtSure.Width - 1;
                nbtUnInstall.Top = nbtSure.Top;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("外观")]
        [Description("第二个按钮的文字")]
        [DefaultValue(typeof(String), "B2")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ButtonText2
        {
            get
            {
                return nbtUnInstall.Text;
            }
            set
            {
                nbtUnInstall.AutoSize = true;
                nbtUnInstall.Text = "";
                nbtUnInstall.Size = new Size(1, 1);
                nbtUnInstall.Refresh();
                nbtUnInstall.AutoSize = true;
                nbtUnInstall.Text = value;
                nbtUnInstall.Refresh();

                nbtUnInstall.Left = panButtons.Width - nbtUnInstall.Width;
                nbtSure.Left = nbtUnInstall.Left - nbtSure.Width - 1;
                nbtUnInstall.Top = nbtSure.Top;
            }
        }

        [Category("自定义事件")]
        [Description("当第一个按钮被点击时")]
        [Browsable(true)]
        public event EventHandler Button1Click
        {
            add
            {
                this.nbtSure.Click += value;
            }
            remove
            {
                this.nbtSure.Click -= value;
            }
        }

        [Category("自定义事件")]
        [Description("当第二个按钮被点击时")]
        [Browsable(true)]
        public event EventHandler Button2Click
        {
            add
            {
                this.nbtUnInstall.Click += value;
            }
            remove
            {
                this.nbtUnInstall.Click -= value;
            }
        }

        private bool hasBorderModeChanged = false;

        public NormalMagneticCard()
        {
            InitializeComponent();
            LayoutAdjust();
        }


        private void LayoutAdjust()
        {
            //Label和Button的Text要先填充,才会避免显示不全，也能让后续的AutoSize属性实际生效确定尺寸

            //百分比和绝对值基于UI设计图转换而来
            labTitle.Location = new Point((int)(this.Width * 0.04), (int)(this.Height * 0.1));
            labTitle.Font = new Font(this.Font.FontFamily, 14);
            labTitle.AutoSize = true;//AutoSize实际生效改变空间尺寸是在确定了Text和Font之后，下一次刷新（或Paint）生效并自动确定尺寸
            labTitle.Refresh();

            labSubTitle.Location = new Point(labTitle.Right + 1,labTitle.Top);//这里要求下边界对齐，先使用前者的Top，自动尺寸生效后再调整才能实际对齐
            labSubTitle.Font = new Font(this.Font.FontFamily, 10);
            labSubTitle.AutoSize = true;
            labSubTitle.Refresh();
            labSubTitle.Location = new Point(labSubTitle.Left, labTitle.Bottom - labSubTitle.Height);//下边界对齐

            npbLogo.Location = new Point((int)(this.Width * 0.04), (int)(this.Height * 0.27));
            npbLogo.BorderStyle = BorderStyle.None;
            npbLogo.Size = new Size((int)(this.Width * 0.92), (int)(this.Height * 0.46));
            npbLogo.BackColor = Color.Transparent;

            //panMessage.Location = new Point((int)(this.Width * 0.04), (int)(this.Height * 0.85));
            panMessage.Size = new Size((int)(this.Width * 0.60), (int)(this.Height * 0.24));//宽度没有指明

            //panButtons.Location = new Point(panMessage.Right + 1, panMessage.Top);
            //panButtons.Size = new Size((int)(this.Width * 0.50), panMessage.Height);
            panButtons.Size = new Size(this.Width - panButtons.Left, panMessage.Height);

            nbtUnInstall.Left = panButtons.Width - nbtUnInstall.Width;
            nbtUnInstall.Top = nbtSure.Top;
            nbtSure.Left = nbtUnInstall.Left - nbtSure.Width - 1;

            if (DesignMode)
            {
                //labSubTitle.Text = panButtons.Location.ToString();
                //this.Refresh();
            }
                
        }

        private void NormalMagneticCard_Load(object sender, EventArgs e)
        {

        }

        private void NormalMagneticCard_SizeChanged(object sender, EventArgs e)
        {
            LayoutAdjust();
        }
        private void TestDisplay()
        {
            labTitle.Text = "示例模块";
            labSubTitle.Text = "v3.0.004";
            labMessage.Text = "最新版本：v3.0.005";
            nbtSure.Text = "更新";
            nbtUnInstall.Text = "卸载";
            npbLogo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ShowControlBorder(Control ctl,Color AimBackColor)
        {
            try
            {
                if (ctl.BackColor == Color.Transparent || ctl.BackColor == AimBackColor)
                {
                    Random rad = new Random(DateTime.Now.Second);
                    ctl.BackColor = Color.FromArgb(rad.Next(0, 255), rad.Next(0, 255), rad.Next(0, 255));
                }
            }
            catch
            {

            }
            try
            {
                if(ctl.Controls.Count > 0)
                {
                    foreach(Control sctl in ctl.Controls)
                    {
                        ShowControlBorder(sctl,AimBackColor);
                    }
                }
            }
            catch
            {

            }
            
        }

        private void ReseShowControlBorder(Control ctl, Color AimBackColor)
        {
            try
            {
                ctl.BackColor = Color.Transparent;
            }
            catch
            {
                try
                {
                    ctl.BackColor = AimBackColor;
                }
                catch
                {

                }
            }
            try
            {
                if (ctl.Controls.Count > 0)
                {
                    foreach (Control sctl in ctl.Controls)
                    {
                        ReseShowControlBorder(sctl,AimBackColor);
                    }
                }
            }
            catch 
            {

            }
        }

        private void NormalMagneticCard_Paint(object sender, PaintEventArgs e)
        {
            if (borderMode)
            {
                foreach (Control ctl in this.Controls)
                {
                    try
                    {
                        if (BorderMode)
                        {
                            if (hasBorderModeChanged)
                            {
                                ShowControlBorder(ctl, this.BackColor);
                                hasBorderModeChanged = false;
                            }
                        }
                        else
                        {
                            if (hasBorderModeChanged)
                            {
                                ReseShowControlBorder(ctl, this.BackColor);
                                hasBorderModeChanged = false;
                            }

                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if(e.Control.GetType() != typeof(NormalButton))
                e.Control.Click += Control_Click;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            DisplaySelected(true);
            this.OnClick(e);
        }
        public void DisplaySelected(bool Selected)
        {
            if (WorkingMode == CardWorkingModes.Select)
            {
                if (Selected)
                {
                    this.BackColor = CatBoxDesktopUILibrary.Modles.ColorTheme.ContentColor;
                    this.labTitle.ForeColor =
                        this.labSubTitle.ForeColor =
                        this.labMessage.ForeColor =
                        CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(this.BackColor);
                }
                else
                {
                    this.BackColor = Color.LightGray;
                    this.labTitle.ForeColor =
                        this.labSubTitle.ForeColor =
                        this.labMessage.ForeColor =
                        CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(this.BackColor);
                }
                this.Invalidate();
            }
                
        }

        private void NormalMagneticCard_Click(object sender, EventArgs e)
        {
            DisplaySelected(true);
        }
    }
}
