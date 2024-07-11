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
    public partial class NormalSideBar : UserControl
    {
        #region 属性

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("标题")]
        public string Title
        {
            get
            {
                return labTitle.Text;
            }
            set
            {
                labTitle.Text = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("标题图片")]
        public Image HeaderLogo
        {
            get
            {
                return pbLogo.BackgroundImage;
            }
            set
            {
                pbLogo.BackgroundImage = value;
                this.Invalidate();
            }
        }

        public List<NormalSideBarItem> items = new List<NormalSideBarItem>();

        private int itemHeight = 100;

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("项目高度")]
        public int ItemHeight
        {
            set
            {
                itemHeight = value;
                //ReplaceItems();
                this.Invalidate();
            }
            get
            {
                return itemHeight;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("顶部区域高度")]
        public int HeaderHeight
        {
            get
            {
                return panHeader.Height;
            }
            set
            {
                panHeader.Height = value;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("底部区域高度")]
        public int FootHeight
        {
            set
            {
                boardAboutBottom.Height = value;
            }
            get
            {
                return boardAboutBottom.Height;
            }
        }
        #endregion

        #region 事件

        private event EventHandler itemSelected;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("选择项目发生变化时")]
        public event EventHandler ItemSelected
        {
            add
            {
                itemSelected += value;
            }
            remove
            {
                itemSelected -= value;
            }
        }

        #endregion

        public NormalSideBar()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            InitializeComponent(); 
            boardAboutBottom.GetVersion(true);
        }

        public void ReplaceItems(NormalSideBarItem item)
        {
            panItem.Controls.Add(item);
            item.Dock = DockStyle.Top;
            item.ForeColor = CatBoxDesktopUILibrary.Controls.ThemeHelper.GetForeColor(this.BackColor);
            item.Height = ItemHeight;
            item.ItemSelected += Item_ItemSelected;
            item.AutoDeepthPadding();
        }

        public void AddItem(NormalSideBarItem item)
        {
            if(InvokeRequired)
            {
                this.Invoke(new MethodInvoker
                    (
                    delegate 
                    {
                        items.Add(item);
                        ReplaceItems(item);
                    }));
            }
            else
            {
                items.Add(item);
                ReplaceItems(item);
            }
            
            
        }
        public void RemoveItem(bool ClearAll)
        {

        }

        private void Item_ItemSelected(object sender, EventArgs e)
        {
            this.itemSelected?.Invoke(sender, e);
            //CatBoxDesktopUILibrary.Controls.Win32UIHelper.SendMessage(this.Handle, CatBoxDesktopUILibrary.Controls.Win32UIHelper.WM_SETREDRAW, false, 0);
            foreach (NormalSideBarItem item in items)
            {
                if(item.BindPageFlag != (sender as NormalSideBarItem).BindPageFlag)
                    item.Selected = false;
            }
            //CatBoxDesktopUILibrary.Controls.Win32UIHelper.SendMessage(this.Handle, CatBoxDesktopUILibrary.Controls.Win32UIHelper.WM_SETREDRAW, true, 0);
            //this.Refresh();
        }

        /// <summary>
        /// 翻转选项顺序
        /// </summary>
        public void ReverseItems()
        {
            items.Reverse();
            foreach(CatBoxDesktopUILibrary.Views.Controls.NormalSideBarItem item in items)
            {
                this.Controls.Remove(item);
                this.Controls.Add(item);
                item.Dock = DockStyle.Top;
            }
        }

        /// <summary>
        /// 清除所有选项
        /// </summary>
        public void ClearItems()
        {
            foreach(CatBoxDesktopUILibrary.Views.Controls.NormalSideBarItem item in items)
            {
                this.Controls.Remove(item);
            }
            items.Clear();
        }
    }
}
