using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    /// <summary>
    /// 布局：网格式布局
    /// </summary>
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class NormalLayoutGrid : UserControl,CatBoxDesktopUILibrary.Controls.InterGridSize
    {
        /*
         * 2020.12.08 16:40,C-Cat:创建
         * 2020.12.09 16:43,C-Cat:替换同步缩放机制
         * */
        public NormalLayoutGrid()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            InitializeComponent();
        }

        #region 网格接口功能实现

        [Category("外观")]
        [Description("网格设置")]
        [DefaultValue(typeof(Size),"10,10")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        /// <summary>
        /// 控件布局网格
        /// </summary>
        public Size GridSize
        {
            get
            {
                if(gridSize == null ||
                    gridSize.Width  <= 0 ||
                    gridSize.Height <= 0)
                {
                    gridSize = new Size(10, 10); 
                }
                return gridSize;
            }
            set
            {
                gridSize = value;
                //LayoutAdjust();
                this.Refresh();
            }
        }
        private Size gridSize = new Size(10, 10);

        /// <summary>
        /// 设计模式下是否显示网格线条
        /// </summary>
        [Category("外观")]
        [Description("设计模式下是否显示网格线条")]
        [DefaultValue(typeof(Boolean),"True")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowGridInDesignMode
        {
            get
            {
                return showGridInDesignMode;
            }
            set
            {
                showGridInDesignMode = value;
                this.OnPaint(new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
            }
        }
        private bool showGridInDesignMode = true;

        private Dictionary<string, Rectangle> ControlSizes = new Dictionary<string, Rectangle>();
        private Size PresentSingleSize = Size.Empty;

        private Rectangle GetCurrentGridRect(Control ctl)
        {
            if (PresentSingleSize == Size.Empty)
            {
                ReflashSingleSize();
            }

            return new Rectangle((int)(ctl.Location.X / PresentSingleSize.Width),
                (int)(ctl.Location.Y / PresentSingleSize.Height),
                (int)(ctl.Size.Width / PresentSingleSize.Width <= 0 ? 1 : ctl.Size.Width / PresentSingleSize.Width),
                (int)(ctl.Size.Height / PresentSingleSize.Height <= 0 ? 1 : ctl.Size.Height / PresentSingleSize.Height));
        }

        private bool forcedAlignment = false;
        public bool ForcedAlignment
        {
            get
            {
                return forcedAlignment;
            }
            set
            {
                forcedAlignment = value;
                LayoutAdjust();
            }
        }

        /// <summary>
        /// SizeChanged所有业务完成之后调用
        /// </summary>
        private void ReflashSingleSize()
        {
            Size SingleSize = new Size(this.Size.Width / GridSize.Width,
                this.Size.Height / GridSize.Height); //重订单位网格尺寸
            PresentSingleSize = SingleSize;
        }

        public Size GetGridSize()
        {
            return GridSize;
        }

        public void LayoutAdjust()
        {
            Size SingleSize = new Size(this.Size.Width / GridSize.Width,
                this.Size.Height / GridSize.Height); //重订单位网格尺寸
            //遍历所有子控件
            foreach(Control ctl in this.Controls)
            {
                try
                {
                    ctl.LocationChanged -= Control_LocationChanged;
                    ctl.SizeChanged -= Control_SizeChanged;
                }
                catch (Exception e)
                {
                    throw e;
                }
                try
                {
                    Rectangle CurrentRect = GetCurrentGridRect(ctl);
                    //根据参数更新控件位置和尺寸
                    ctl.Location = new Point(SingleSize.Width * CurrentRect.X,
                        SingleSize.Height * CurrentRect.Y);
                    ctl.Size = new Size(SingleSize.Width * CurrentRect.Width,
                        SingleSize.Height * CurrentRect.Height);

                    //if (!DesignMode && ControlSizes.ContainsKey(GetIDofControls(ctl)))
                    //{
                    //    //获取记录中矩形参数
                        
                    //    Rectangle Rect;
                    //    //bool res = ControlSizes.TryGetValue(GetIDofControls(ctl), out Rect);
                    //    Rect = ControlSizes[GetIDofControls(ctl)];
                    //    if (Rect != null)
                    //    {
                    //        CurrentRect = Rect;
                    //    }

                        
                    //}
                    //else
                    //{
                    //    //自动对齐控件并添加记录
                    //    AddControls(ctl, Rectangle.Empty);
                    //}
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
                try
                {
                    if(ForcedAlignment)
                    {
                        ctl.LocationChanged += Control_LocationChanged;
                        ctl.SizeChanged += Control_SizeChanged;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public void SetGridSize(Size Grid)
        {
            GridSize = Grid;
        }

        public void AddControls(Control ctl,Rectangle Rect)
        {
            Size SingleSize = new Size(this.Size.Width / GridSize.Width,
                this.Size.Height / GridSize.Height); //重订单位网格尺寸
            Rectangle CurrentRect = Rect;


            try
            {
                ctl.LocationChanged -= Control_LocationChanged;
                ctl.SizeChanged -= Control_SizeChanged;
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                //自动对齐
                if (Rect == Rectangle.Empty)
                {
                    //根据现有位置和尺寸对齐到网格(整数去尾)
                    CurrentRect
                    = new Rectangle((int)(ctl.Location.X / SingleSize.Width),
                    (int)(ctl.Location.Y / SingleSize.Height),
                    (int)(ctl.Size.Width / SingleSize.Width <= 0 ? 1 : ctl.Size.Width / SingleSize.Width),
                    (int)(ctl.Size.Height / SingleSize.Height <= 0 ? 1 : ctl.Size.Height / SingleSize.Height));
                }

                //根据对齐的矩阵进行调整位置和尺寸
                ctl.Location = new Point(SingleSize.Width * CurrentRect.X,
                    SingleSize.Height * CurrentRect.Y);
                ctl.Size = new Size(SingleSize.Width * CurrentRect.Width,
                    SingleSize.Height * CurrentRect.Height);

                if(Rect != Rectangle.Empty)
                {
                    this.Controls.Add(ctl);
                }
                //记录对应数据
                //if (!ControlSizes.ContainsKey(GetIDofControls(ctl)))
                //    ControlSizes.Add(GetIDofControls(ctl), CurrentRect);
                //else
                //    ControlSizes[GetIDofControls(ctl)] = CurrentRect;
            }
            catch(Exception e)
            {
                Exception em = new Exception("SP：" + e.Message);
                throw em;
            }
            
            try
            {
                if (ForcedAlignment)
                {
                    ctl.LocationChanged += Control_LocationChanged;
                    ctl.SizeChanged += Control_SizeChanged;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 事件响应及其复写
        public override void Refresh()
        {
            //LayoutAdjust();
            base.Refresh();
        }

        private void NormalLayoutGrid_ControlAdded(object sender, ControlEventArgs e)
        {
            AddControls(e.Control, Rectangle.Empty);
        }

        private void Control_SizeChanged(object sender, EventArgs e)
        {
            //if (!DesignMode)
            //{
            //强制对齐，可以不开
            LayoutAdjust();
            //}
        }

        private void Control_LocationChanged(object sender, EventArgs e)
        {
            //if (!DesignMode)
            //{
            //    //强制对齐，可以不开
            //AddControls((Control)sender, Rectangle.Empty);
            LayoutAdjust();
            //}
        }

        private void NormalLayoutGrid_ControlRemoved(object sender, ControlEventArgs e)
        {
            e.Control.LocationChanged -= Control_LocationChanged;
            e.Control.SizeChanged -= Control_SizeChanged;

            //这里最好做个移除，其实不做也可以，不过为了持久运行最好是保持记录表的体积控制
            //ControlSizes.Remove(GetIDofControls(e.Control));
        }

        private void NormalLayoutGrid_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode && ShowGridInDesignMode)
            {
                //重订单位网格尺寸
                Size SingleSize = new Size(this.Size.Width / GridSize.Width,
                    this.Size.Height / GridSize.Height);
                //获取当前Grahics对象
                //Graphics g = this.CreateGraphics();
                Graphics g = e.Graphics;
                //设计器模式下显示绘制网格
                for (int i = 0; i < GridSize.Width + 1; i++)
                {
                    //竖
                    g.DrawLine(Pens.Black, new Point(i * SingleSize.Width, 0), new Point(i * SingleSize.Width, this.Height));
                }
                for (int i = 0; i < GridSize.Height + 1; i++)
                {
                    //横
                    g.DrawLine(Pens.Black, new Point(0, i * SingleSize.Height), new Point(this.Width, i * SingleSize.Height));
                }
            }
        }
        private void NormalLayoutGrid_SizeChanged(object sender, EventArgs e)
        {
            LayoutAdjust();
            ReflashSingleSize();
            base.Refresh();
        }
        #endregion

        public string GetIDofControls(Control ctl)
        {
            if (ctl.Tag == null)
            {
                ctl.Tag = Guid.NewGuid();
            }
            return ctl.Tag.ToString();
        }

        private void NormalLayoutGrid_Load(object sender, EventArgs e)
        {

        }

        private void NormalLayoutGrid_Click(object sender, EventArgs e)
        {
            
        }
    }
}
