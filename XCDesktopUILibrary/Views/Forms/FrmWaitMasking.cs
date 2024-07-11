using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Views.Forms
{
    public partial class FrmWaitMasking : Form
    {
        int MaxTimeOut = 20000;

        private Thread thdWoring;
        private ParameterizedThreadStart thdAction;
        private object thdActionArg;
        public Exception exAction;

        public bool IsCompleted = false;
        public FrmWaitMasking()
        {
            InitializeComponent();
            this.Opacity = 0.76D;
            //双缓冲且擦除背景
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint|
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        public FrmWaitMasking(string strMessage, int TimeOut = 20000):this()
        {
            labTips.Text = strMessage;
            MaxTimeOut = TimeOut;
        }

        private void FrmWaitMasking_Load(object sender, EventArgs e)
        {
            labTips.ForeColor = Color.White;
            if(this.Owner != null)
            {
                StartPosition = FormStartPosition.Manual;
                this.Location = Owner.Location;
                //this.Location = Owner.ClientRectangle.Location;
                this.Size = Owner.Size;
            }
            else
            {
                Rectangle ScreenRect = Screen.PrimaryScreen.WorkingArea;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Size = new Size(ScreenRect.Width, (int)(ScreenRect.Height * 0.3));
            }
            //开始动画
            StartAnima();
        }

        private void FrmWaitMasking_Shown(object sender, EventArgs e)
        {
            if(thdAction != null)
            {
                thdWoring = new Thread(StartAction);
                thdWoring.IsBackground = true;
                thdWoring.Start();
            }
        }

        public void StartAnima()
        {
            npbIcon.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._1);
            npbIcon.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._2);
            npbIcon.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._3);
            npbIcon.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._4);
            npbIcon.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._5);
            npbIcon.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._6); 
            npbIcon.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._7);
            npbIcon.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._8);

            npbIcon.ChangeSwicth(true);
        }

        public void StartAction()
        {
            try
            {
                Task workTask = new Task(arg =>
                {
                    thdAction(arg);
                }, thdActionArg);
                workTask.Start();
                Task.WaitAll(workTask);
            }
            catch (Exception exception)
            {
                exAction = exception;
            }
            finally
            {
                IsCompleted = true;
                this.Invalidate();
            }
        }

        public void SetAction(ParameterizedThreadStart workAction, object arg)
        {
            thdAction = workAction;
            thdActionArg = arg;
        }

        private void FrmWaitMasking_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                npbIcon.Location = new Point((int)((Width - npbIcon.Width) / 2), (int)((Height - npbIcon.Height) / 2));
                labTips.Top = npbIcon.Bottom + 10;
            }
            catch
            {

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(IsCompleted)
            {
                Close();
            }
        }
    }
}
