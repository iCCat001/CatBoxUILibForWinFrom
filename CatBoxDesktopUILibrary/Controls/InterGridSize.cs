using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Controls
{
    public interface InterGridSize
    {
        /// <summary>
        /// 自动调整所有子空间和元素的尺寸，推荐在reflash函数中调用
        /// </summary>
        void LayoutAdjust();

        /// <summary>
        /// 设置网格尺寸（列行数）
        /// </summary>
        /// <param name="Grid"></param>
        void SetGridSize(Size Grid);

        /// <summary>
        /// 获取当前的网格尺寸
        /// </summary>
        /// <returns></returns>
        Size GetGridSize();

        /// <summary>
        /// 添加控件（自动对齐）,推荐在Controls.Add()后调用
        /// </summary>
        /// <param name="ctl">Control控件对象</param>
        /// <param name="Rect">指定的位置和尺寸，自动模式无需指定时填入Rectangle.Empty即可</param>
        void AddControls(Control ctl, Rectangle Rect);
    }
}
