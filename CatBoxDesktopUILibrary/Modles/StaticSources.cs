using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CatBoxDesktopUILibrary.Modles
{
    public static class StaticSources
    {
        #region 公共变量声明
        //public static ColorTheme ThemeColor = new ColorTheme();
        #endregion
        public static void init()
        {
            try
            {
                /* 初始化公共变量，确保可读性和易维护性
                 * 1.需要初始化的变量需要进行类内公共静态声明，在尾部添加对应的声明和初始化函数
                 * 2.在此处进行初始化函数调用
                 * */
                ColorThemeInit();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(LogFile.Error, "公共变量初始化失败：" + ex.Message);
            }
        }

        #region 初始化函数
        public static void ColorThemeInit()
        {
            ColorTheme.ContentColor = Color.FromArgb(0, 120, 215);//Windows蓝
            ColorTheme.SafeColor = Color.FromArgb(50, 199, 65);//取自招标Logo绿色
            ColorTheme.UnSafeColor = Color.FromArgb(200, 40, 40);
            ColorTheme.BanColor = Color.FromArgb(125, 125, 125);
            ColorTheme.BackgroundColorLv1 = Color.FromArgb(250, 250, 250);
            ColorTheme.BackgroundColorLv2 = Color.FromArgb(225, 225, 225);
            ColorTheme.SelectColor = Color.FromArgb(20, 0, 120, 215);
            ColorTheme.SelectedColor = Color.FromArgb(100, 0, 120, 215);
        }
        #endregion
    }
}
