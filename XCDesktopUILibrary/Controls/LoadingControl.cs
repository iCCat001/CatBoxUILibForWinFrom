using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Controls
{
    public class LoadingControl
    {
        /// <summary>
        /// 执行长时间的异步动作，并使用动画遮罩层覆盖窗体(注：操作应当是纯后台的操作代码，由于安全限制不要涉及包含UI部分的代码（尤其是控制Controls等父控件的操作）)
        /// </summary>
        /// <param name="WaitingMessage">用于显示的文字信息</param>
        /// <param name="frmOwner">将被遮罩覆盖的窗体</param>
        /// <param name="work">带参线程任务</param>
        /// <param name="workArg">参数，无参数则为null</param>
        /// <param name="TimeOut">超时设定</param>
        public static void ShowLoading(string WaitingMessage, Form frmOwner, ParameterizedThreadStart work, object workArg = null,int TimeOut = 20000)
        {
            CatBoxDesktopUILibrary.Views.Forms.FrmWaitMasking frmWaitMasking = new Views.Forms.FrmWaitMasking(WaitingMessage, TimeOut);
            dynamic eo = new System.Dynamic.ExpandoObject();
            eo.Form = frmWaitMasking;
            eo.WorkArg = workArg;
            frmWaitMasking.SetAction(work, eo);
            frmWaitMasking.ShowDialog(frmOwner);
            if (frmWaitMasking.exAction != null)
            {
                throw frmWaitMasking.exAction;
            }

        }
    }
}
