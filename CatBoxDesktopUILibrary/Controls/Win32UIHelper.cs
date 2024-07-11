using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CatBoxDesktopUILibrary.Controls
{
    public class Win32UIHelper
    {
        /// <summary>
        /// WIN32 API：对指定句柄控件拦截消息
        /// </summary>
        /// <param name="hWnd">句柄</param>
        /// <param name="wMsg">消息</param>
        /// <param name="wParam">是否拦截</param>
        /// <param name="lParam">忘了是啥了，填0就好</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        public const int WM_SETREDRAW = 11;

        public const int CS_DropSHADOW = 0x20000;
        public const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
    }
}
