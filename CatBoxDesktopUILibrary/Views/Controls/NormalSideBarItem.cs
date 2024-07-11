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
    public partial class NormalSideBarItem : UserControl
    {
        #region 预置枚举

        public enum ItemTypes
        {
            /// <summary>
            /// 分割线
            /// </summary>
            SplitLine,

            /// <summary>
            /// 文字标题
            /// </summary>
            Title,

            /// <summary>
            /// 可选项
            /// </summary>
            Item
        }

        #endregion

        #region 属性

        private ItemTypes itemType = ItemTypes.Item;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("列表项类型")]
        public ItemTypes ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                SwitchItemType(value);
            }
        }

        /// <summary>
        /// 项目显示的文本
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("显示文本")]
        public string ItemText
        {
            get
            {
                return labText.Text;
            }
            set
            {
                labText.Text = value;
            }
        }

        private Color barColor = Color.White;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("选中时的侧边条颜色")]
        public Color BarColor
        {
            get
            {
                return barColor;
            }
            set
            {
                barColor = value;
            }
        }

        private bool itemSelected = false;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("选中状态，跟随父控件自动管理")]
        public bool Selected
        {
            get
            {
                return itemSelected;
            }
            set
            {
                if(itemSelected != value && value)
                {
                    NormalSideBarItem_MouseEnter(null, null);
                }
                itemSelected = value;
                if (!value)
                {
                    NormalSideBarItem_MouseLeave(this, null);
                }
            }
        }

        private string bindPageFlag = "";
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("选中状态，跟随父控件自动管理")]
        public string BindPageFlag
        {
            set
            {
                bindPageFlag = value;
            }
            get
            {
                return bindPageFlag;
            }
        }

        private int deepthPaddingCell = 10;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("每一层深度递进的距离")]
        public int DeepthPaddingCell
        {
            get
            {
                return deepthPaddingCell;
            }
            set
            {
                deepthPaddingCell = value;
                AutoDeepthPadding();
            }
        }

        private int leftPaddingOffset = 0;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("文字左侧预留的递进距离")]
        public int LeftPaddingOffset
        {
            get
            {
                return leftPaddingOffset;
            }
            set
            {
                leftPaddingOffset = value;
                AutoDeepthPadding();
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("文字左侧的图标")]
        public Image ItemIcon
        {
            get
            {
                return pbLogo.BackgroundImage;
            }
            set
            {
                pbLogo.BackgroundImage = value;
                pbLogo.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("文字字体（已重定向）")]
        public new Font Font
        {
            get
            {
                return labText.Font;
            }
            set
            {
                labText.Font = value;
                labText.Invalidate();
            }
        }

        public int IconDisplayWidth
        {
            set
            {
                pbLogo.Width = value;
                this.Refresh();
            }
            get
            {
                return pbLogo.Width;
            }
        }



        /// <summary>
        /// 列表项的深度
        /// </summary>
        public int ItemDeepth
        {
            get
            {
                return CatBoxDesktopUILibrary.Controls.ControlsHelper.GetItemControlsDeepth(this, this.GetType(), true, true);
            }
        }
        #endregion

        #region 事件

        private event EventHandler itemClick;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("项目被选中事件")]
        public event EventHandler ItemSelected
        {
            add
            {
                itemClick += value;
            }
            remove
            {
                itemClick -= value;
            }
        }

        #endregion
        public NormalSideBarItem()
        {
            InitializeComponent();
            pbLogo.Height = pbLogo.Width;
        }

        private void NormalSideBarItem_MouseEnter(object sender, EventArgs e)
        {
            if (!Selected)
            {
                panSideColorBar.BackColor = BarColor;
                panSideColorBar.Invalidate();
                this.BackColor = Color.FromArgb(20, 0, 0, 0);
                foreach (Control ctl in this.Controls)
                {
                    try
                    {
                        ctl.BackColor = Color.FromArgb(0, 0, 0, 0);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void NormalSideBarItem_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                panSideColorBar.BackColor = Color.Transparent;
                panSideColorBar.Invalidate();
                this.BackColor = Color.Transparent;
                foreach (Control ctl in this.Controls)
                {
                    try
                    {
                        ctl.BackColor = Color.FromArgb(0, 0, 0, 0);
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
            e.Control.MouseEnter += NormalSideBarItem_MouseEnter;
            e.Control.MouseLeave += NormalSideBarItem_MouseLeave;
            e.Control.MouseDown += NormalSideBarItem_MouseDown;
            e.Control.MouseUp += NormalSideBarItem_MouseUp;
            e.Control.Click += NormalSideBarItem_Click;
        }

        /// <summary>
        /// 将所有子控件的一系列事件触发行为和列表项行为同步
        /// </summary>
        /// <param name="ctl">目标控件</param>
        /// <param name="Sync">是否同步，True为同步，反之解除同步</param>
        /// <param name="IncludeSelf">是否包含目标控件本身</param>
        private void SubControlsEventSync(Control ctl, bool Sync,bool IncludeSelf = false)
        {
            if(IncludeSelf)
            {
                try
                {
                    ctl.MouseEnter -= NormalSideBarItem_MouseEnter;
                    ctl.MouseLeave -= NormalSideBarItem_MouseLeave;
                    ctl.MouseDown -= NormalSideBarItem_MouseDown;
                    ctl.MouseUp -= NormalSideBarItem_MouseUp;
                    ctl.Click -= NormalSideBarItem_Click;
                }
                catch
                {

                }
            }
            foreach(Control subCtl in ctl.Controls)
            {
                if (Sync)
                {
                    try
                    {
                        subCtl.MouseEnter += NormalSideBarItem_MouseEnter;
                        subCtl.MouseLeave += NormalSideBarItem_MouseLeave;
                        subCtl.MouseDown += NormalSideBarItem_MouseDown;
                        subCtl.MouseUp += NormalSideBarItem_MouseUp;
                        subCtl.Click += NormalSideBarItem_Click;
                    }
                    catch
                    {

                    }
                    
                }
                else
                {
                    try
                    {
                        subCtl.MouseEnter -= NormalSideBarItem_MouseEnter;
                        subCtl.MouseLeave -= NormalSideBarItem_MouseLeave;
                        subCtl.MouseDown -= NormalSideBarItem_MouseDown;
                        subCtl.MouseUp -= NormalSideBarItem_MouseUp;
                        subCtl.Click -= NormalSideBarItem_Click;
                    }
                    catch
                    {

                    }
                    
                }

                //递归：下一层子控件
                try
                {
                    if (subCtl.Controls != null && subCtl.Controls.Count > 0)
                    {
                        SubControlsEventSync(subCtl, Sync);
                    }
                }
                catch
                {

                }
            }
        }

        private void NormalSideBarItem_Click(object sender, EventArgs e)
        {
            Selected = true;
            itemClick?.Invoke(this, e);
        }

        private void NormalSideBarItem_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void NormalSideBarItem_MouseUp(object sender, MouseEventArgs e)
        {

        }

        public void AutoDeepthPadding()
        {
            panTab.Width = LeftPaddingOffset + ItemDeepth * DeepthPaddingCell;
            this.Invalidate();
        }

        private void SwitchItemType(ItemTypes AimType)
        {
            switch(itemType)
            {
                case ItemTypes.Item:
                    this.Height = this.Height / 2;
                    SubControlsEventSync(this, false, true);
                    break;
                default:
                    if(AimType == ItemTypes.Item)
                        SubControlsEventSync(this, true, true);
                    break;
            }
            itemType = AimType;
        }

        private void NormalSideBarItem_BackColorChanged(object sender, EventArgs e)
        {
            
        }

        private void pbLogo_SizeChanged(object sender, EventArgs e)
        {
            PanBitmap.Width = pbLogo.Width;
            pbLogo.SizeChanged -= pbLogo_SizeChanged;
            pbLogo.Height = pbLogo.Width;
            pbLogo.SizeChanged += pbLogo_SizeChanged;
            pbLogo.Location = new Point(0, (this.Height - pbLogo.Height) / 2);
        }

        private void PanBitmap_SizeChanged(object sender, EventArgs e)
        {
            pbLogo_SizeChanged(null,null);
        }

        private void NormalSideBarItem_DockChanged(object sender, EventArgs e)
        {

        }
    }
}
