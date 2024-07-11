using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Controls
{
    /// <summary>
    /// 提供控件和窗体相关的一些静态公有方法
    /// </summary>
    public class ControlsHelper
    {
        /// <summary>
        /// 获取指定控件在其位置的深度/层数（其父控件的层级数量）
        /// </summary>
        /// <param name="ctl">控件</param>
        /// <param name="LimitType">限制指定父控件的类型，默认为null，则为不限制父控件类型，任何类型的父控件均可使得深度+1</param>
        /// <param name="AllowBaseType">对父控件的限制是否允许其为指定类型的派生类，默认为false，则为不计算其派生类的对象</param>
        /// <param name="Pierce">是否允许穿透计算，默认为false，则代表遇到任何一个父控件不是限制的类型时中止计算而返回，反之则继续往上递归(忽略的层不计数)</param>
        /// <returns>控件所在的深度</returns>
        public static int GetItemControlsDeepth(Control ctl, Type LimitType = null,bool AllowBaseType = false, bool Pierce = false)
        {
            int deepth = 0;

            if(ctl.Parent != null)
            {
                /*
                 * if匹配条件：
                 * 1.不限制父控件类型（LimitType == null）
                 * 2.限制父控件类型，且父控件类型匹配（ctl.Parent.GetType().FullName == LimitType.FullName）
                 * 3.不满足上述条件，但是允许匹配基类，且父控件继承关系（向上）中存在指定的类型
                 * 4.以上条件均不满足，但是允许穿透，则忽略当前父控件继续递归（此时Deepth不增加，忽略该父控件）
                 */
                if (LimitType == null ||
                    ctl.Parent.GetType().FullName == LimitType.FullName ||
                    (AllowBaseType && ctl.Parent.GetType().IsSubclassOf(LimitType)))
                {
                    deepth++;
                    return GetItemControlsDeepth(ctl.Parent, LimitType, AllowBaseType, Pierce);
                }
                else if(Pierce && LimitType != null)
                {
                    return GetItemControlsDeepth(ctl.Parent, LimitType, AllowBaseType, Pierce);
                }
            }
            return deepth;
        }
    }
}
