using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Views.Forms
{
    public partial class FrmTest : FrmBase
    {
        public FrmTest()
        {
            InitializeComponent();
            System.Timers.Timer timP = new System.Timers.Timer();
            timP.Elapsed += TimP_Elapsed;
            timP.Interval = 400;
            timP.Start();

            normalPictureBoxFade1.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._1);
            normalPictureBoxFade1.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._2);
            normalPictureBoxFade1.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._3);
            normalPictureBoxFade1.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._4);
            normalPictureBoxFade1.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._5);
            normalPictureBoxFade1.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._6);
            normalPictureBoxFade1.pics.Add(CatBoxDesktopUILibrary.Properties.Resources._7);
            normalPictureBoxFade1.ChangeSwicth(true);
        }

        private void TimP_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (normalProgressBar1.Value <= 95)
                normalProgressBar1.Value += 5;
            else
                normalProgressBar1.Value = 0;
        }

        private void FrmTest_MouseMove(object sender, MouseEventArgs e)
        {
            labVersion.Text = "M-F(" + e.X + ":" + e.Y + ")";
            
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.MouseMove += Control_MouseMove;
            base.OnControlAdded(e);
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            //if(Title.Contains("M-C"))
            //{
            //    Title = Title.Substring(Title.IndexOf("M-C"), Title.Length - Title.IndexOf("M-C"));
            //}
            //Title += "M-C(" + (e.X - (sender as Control).Location.X) 
            //    + ":" + (e.Y - (sender as Control).Location.Y) + ")";
        }

        private void normalTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            Title = "控件测试窗体，UI库：CatBoxDesktopUILibrary, Version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void nbtMasking_Click(object sender, EventArgs e)
        {
            CatBoxDesktopUILibrary.Controls.LoadingControl.ShowLoading("测试遮罩层：此遮罩大约存在30s\n\n" +
                    "遮罩层通常用于执行高耗时任务时（如文件处理，联网与服务器交互操作等）对窗体进行覆盖遮蔽\n" +
                    "此时用户无法操作被遮蔽的窗体，直到任务返回结果，或者超出预设的超时限制", this, (obj) =>
                    {
                        //C-Cat：此处放置需要后台执行的代码（注：请不要包含跨线程的对UI操作）
                        Thread.Sleep(30000);
                    });
        }

        private void normalTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
            {

            }
        }
    }
}
