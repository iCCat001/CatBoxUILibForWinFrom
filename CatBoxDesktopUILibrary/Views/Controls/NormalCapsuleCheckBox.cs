using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    /// <summary>
    /// 胶囊体开关
    /// </summary>
    public partial class NormalCapsuleCheckBox : CheckBox, Interface.iSupportUnifyTheme
    {
        #region 开关提示文字
        /// <summary>
        /// 私有：提示文字，0为关闭，1为开启
        /// </summary>
        string[] StateString = new string[2] { "关", "开" };
        /// <summary>
        /// 状态为[选中]时胶囊体右侧的提示文字（仅在默认布局下生效，水平分布等不显示）
        /// </summary>
        public string PromptWhenChecked
        {
            get
            {
                return StateString[0];
            }
            set
            {
                StateString[0] = value;
            }
        }
        /// <summary>
        /// 状态为[未选中]时胶囊体右侧的提示文字（仅在默认布局下生效，水平分布等不显示）
        /// </summary>
        public string PromptWhenUnchecked
        {
            get
            {
                return StateString[1];
            }
            set
            {
                StateString[1] = value;
            }
        }

        /// <summary>
        /// 私有：状态为[选中]时，提示文字的颜色
        /// </summary>
        Color promptColorWhenChecked;
        /// <summary>
        /// 私有：状态为[未选中]时，提示文字的颜色
        /// </summary>
        Color promptColorWhenUnchecked;
        /// <summary>
        /// 状态为[选中]时，提示文字的颜色
        /// </summary>
        public Color PromptColorWhenChecked
        {
            get
            {
                return promptColorWhenChecked;
            }
            set
            {
                promptColorWhenChecked = value;
            }
        }
        /// <summary>
        /// 状态为[未选中]时，提示文字的颜色
        /// </summary>
        public Color PromptColorWhenUnchecked
        {
            get
            {
                return promptColorWhenUnchecked;
            }
            set
            {
                promptColorWhenUnchecked = value;
            }
        }
        #endregion

        #region 自动布局
        /// <summary>
        /// 枚举：预制自动布局
        /// </summary>
        public enum DefaultLayouts
        {
            /// <summary>
            /// 文字在胶囊体上方，胶囊体位于左下，其右侧包含用于指示开关的文字
            /// </summary>
            Default,
            /// <summary>
            /// 胶囊体开关位于左侧，文字位于右侧，不显示开关指示文字
            /// </summary>
            Left,
            /// <summary>
            /// 胶囊体开关位于右侧，文字位于左侧，不显示开关指示文字
            /// </summary>
            Right,

            /// <summary>
            /// 自定义布局，用户需自行控制重绘，自动布局关闭
            /// </summary>
            UserControl
        }
        /// <summary>
        /// 私有：默认布局
        /// </summary>
        DefaultLayouts defaultLayout = DefaultLayouts.Default;
        /// <summary>
        /// 控件的可选默认布局
        /// </summary>
        public DefaultLayouts DefaultLayout
        {
            get
            {
                return defaultLayout;
            }
            set
            {
                defaultLayout = value;
            }
        }
        #endregion

        #region 本地动画配置
        
        /// <summary>
        /// 私有：动画开关
        /// </summary>
        private bool animationSwitch = true;
        /// <summary>
        /// 动画开关
        /// </summary>
        public bool AnimationSwitch
        {
            get
            {
                return animationSwitch;
            }
            set
            {
                animationSwitch = value;
            }
        }
        /// <summary>
        /// 动画FPS限制
        /// </summary>
        private int animationFPSLimit = 24;
        /// <summary>
        /// 动画总长度限制
        /// </summary>
        private int animationTotalFrameLimit = 10;
        #endregion

        #region 色彩主题
        private bool followUnionTheme = true;

        public bool FollowUnionTheme
        {
            get
            {
                return followUnionTheme;
            }
            set
            {
                if(followUnionTheme != value)
                {
                    OnThemeChanged();
                }
                followUnionTheme = value;
            }
        }

        private Color colorChecked = CatBoxDesktopUILibrary.Modles.ColorTheme.ContentColor;

        public Color ColorChecked
        {
            set
            {
                colorChecked = value;
            }
            get
            {
                return colorChecked;
            }
        }
        #endregion

        #region 响应区域
        private Rectangle CapsuleArea;
        #endregion

        #region 构造函数
        public NormalCapsuleCheckBox()
        {
            InitializeComponent();
            AutoSize = false;
            //测算所得Win10的胶囊体开关部分大小50*25
            MinimumSize = new Size(50, 30);
        }

        #endregion

        #region 复写事件响应
        protected override void OnPaint(PaintEventArgs pevent)
        {
            try
            {
                Graphics g = pevent.Graphics;
                //背景色覆盖（清空内容，支持透明色）
                if(this.BackColor == Color.Transparent)
                {
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    g.FillRectangle(new SolidBrush(BackColor), this.ClientRectangle);
                }
                else
                {
                    g.Clear(BackColor);
                }

                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;


                //根据自动布局模式进行依次绘制
                switch(defaultLayout)
                {
                    case DefaultLayouts.Default:
                        //计算分区，以分区进行判定绘制，减少除首次以外的单次绘制量
                        //测算所得Win10的胶囊体开关部分大小50*25
                        string txtDisplay = Text;
                        int BordarWidth = 6;

                        Size sizeText = CatBoxDesktopUILibrary.Controls.GraphicsHelper.GetTextDisplayArea(g, ref txtDisplay, Font, this.Width);
                        RectangleF rectText = new RectangleF(0, 0, sizeText.Width, sizeText.Height);
                        RectangleF rectCapsule = new RectangleF(0, rectText.Bottom + BordarWidth, 50, 26);
                        RectangleF rectTip = new RectangleF(rectCapsule.Right + BordarWidth, rectCapsule.Top + BordarWidth / 2, this.Width - rectCapsule.Right, rectCapsule.Height);

                        //更新响应点击的有效区域
                        CapsuleArea = new Rectangle((int)rectCapsule.X, (int)rectCapsule.Y, (int)rectCapsule.Width, (int)rectCapsule.Y);

                        //文字
                        SolidBrush brush = new SolidBrush(Color.Black);
                        g.DrawString(txtDisplay, Font, brush, rectText);

                        //胶囊体
                        
                        if (Checked)
                        {
                            //内填充
                            GraphicsPath path = new GraphicsPath();
                            path = CatBoxDesktopUILibrary.Controls.Shape2D.GetRoundRect((int)rectCapsule.X, (int)rectCapsule.Y, (int)rectCapsule.Width, (int)rectCapsule.Height, 25);
                            if(followUnionTheme)
                            {
                                colorChecked = CatBoxDesktopUILibrary.Modles.ColorTheme.ContentColor;
                            }
                            g.FillPath(new SolidBrush(colorChecked), path);

                            //内圆
                            path = CatBoxDesktopUILibrary.Controls.Shape2D.GetRoundRect((int)rectCapsule.Width - ((int)rectCapsule.Height - BordarWidth * 2) - BordarWidth
                                , (int)rectCapsule.Y + BordarWidth, (int)rectCapsule.Height - BordarWidth * 2, (int)rectCapsule.Height - BordarWidth * 2, 25);
                            g.FillPath(new SolidBrush(CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(colorChecked)), path);

                        }
                        else
                        {
                            //外边框
                            GraphicsPath path = new GraphicsPath();
                            
                            path = CatBoxDesktopUILibrary.Controls.Shape2D.GetRoundRect((int)rectCapsule.X, (int)rectCapsule.Y, (int)rectCapsule.Width, (int)rectCapsule.Height, 25);
                            g.FillPath(new SolidBrush(ForeColor), path);

                            //内填充
                            path = CatBoxDesktopUILibrary.Controls.Shape2D.GetRoundRect((int)rectCapsule.X + BordarWidth / 2, (int)rectCapsule.Y + BordarWidth / 2,
                                (int)rectCapsule.Width - BordarWidth, (int)rectCapsule.Height - BordarWidth , 25);
                            g.FillPath(new SolidBrush(CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(ForeColor)), path);

                            //内圆
                            path = CatBoxDesktopUILibrary.Controls.Shape2D.GetRoundRect((int)rectCapsule.X + BordarWidth, (int)rectCapsule.Y + BordarWidth,
                                (int)rectCapsule.Height - BordarWidth * 2, (int)rectCapsule.Height - BordarWidth * 2, 25);
                            g.FillPath(new SolidBrush(ForeColor), path);

                        }

                        //状态指示文字
                        string strTips = StateString[0];
                        if (Checked)
                        {
                            strTips = StateString[1];
                        }

                        Font fontTip = new Font("黑体", 9);
                        g.DrawString(strTips, fontTip, new SolidBrush(ForeColor),
                            rectTip,new StringFormat() { LineAlignment = StringAlignment.Center });
                        break;
                    case DefaultLayouts.Left:
                        //todo:胶囊体-文字
                        break;
                    case DefaultLayouts.Right:
                        //todo:文字-胶囊体
                        break;
                }

            }
            catch(Exception e)
            {

            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        public void OnThemeChanged()
        {
            //throw new NotImplementedException();
        }

        public void OnAnimationSwitchChanged(bool AnimaionSwitch)
        {
            //throw new NotImplementedException();
        }
        #endregion
    }
}
