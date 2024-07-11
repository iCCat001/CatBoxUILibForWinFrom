using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CatBoxDesktopUILibrary.Modles
{
    /// <summary>
    /// 预置色彩
    /// </summary>
    public static class ColorTheme
    {
        /// <summary>
        /// 主题色
        /// </summary>
        public static Color ContentColor = Color.FromArgb(33, 112, 255);

        /// <summary>
        /// 安全色
        /// </summary>
        public static Color SafeColor = Color.FromArgb(50, 199, 65);

        /// <summary>
        /// 警示色
        /// </summary>
        public static Color UnSafeColor = Color.FromArgb(200, 40, 40);

        /// <summary>
        /// 不可用提示色
        /// </summary>
        public static Color BanColor = Color.FromArgb(125, 125, 125);

        /// <summary>
        /// 背景色L1
        /// </summary>
        public static Color BackgroundColorLv1 = Color.FromArgb(250, 250, 250);

        /// <summary>
        /// 背景色L2
        /// </summary>
        public static Color BackgroundColorLv2 = Color.FromArgb(225, 225, 225);

        /// <summary>
        /// 待选叠加层色
        /// </summary>
        public static Color SelectColor = Color.FromArgb(20, 0, 120, 215);

        /// <summary>
        /// 选中叠加层色
        /// </summary>
        public static Color SelectedColor = Color.FromArgb(100, 0, 120, 215);
    }
}
