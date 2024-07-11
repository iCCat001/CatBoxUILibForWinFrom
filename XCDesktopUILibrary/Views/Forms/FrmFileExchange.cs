using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CatBoxDesktopUILibrary.Modles;

namespace CatBoxDesktopUILibrary.Views.Forms
{
    public partial class FrmFileExchange : Views.Forms.FrmBase
    {
        public int ErrorCode = 1;
        string Source;
        string Aim;
        ExchangeType exchangeType;
        public WebClient wc = new WebClient();

        Point mPoint = new Point(0, 0);
        bool hideForm = false;
        public enum ExchangeType
        {
            Download,
            Upload
        }
        public FrmFileExchange()
        {
            InitializeComponent();
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            labTip.Text = "";
            labProcess.ForeColor = ColorTheme.ContentColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Title">显示标题</param>
        /// <param name="Source"></param>
        /// <param name="Aim"></param>
        /// <param name="exchangeType"></param>
        public FrmFileExchange(string Title, string Source, string Aim, ExchangeType exchangeType, bool hideForm = false) : this()
        {
            labTitle.Text = Title;
            this.Source = Source;
            this.Aim = Aim;
            this.exchangeType = exchangeType;
            this.hideForm = hideForm;
        }

        public void StartClient()
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true; // **** Always accept
                    };
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Credentials = CredentialCache.DefaultNetworkCredentials;
                switch (exchangeType)
                {
                    case ExchangeType.Download:
                        if (File.Exists(Aim))
                        {
                            File.Delete(Aim);
                            Thread.Sleep(1000);
                        }
                        wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                        wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                        wc.DownloadFileAsync(new Uri(Source), Aim);
                        //wc.DownloadFile(Source, Aim);
                        //labTip.Text = wc.Headers["Content-Length"];
                        break;
                    case ExchangeType.Upload:
                        if (!File.Exists(Source))
                        {
                            ErrorCode = -12;
                            this.DialogResult = DialogResult.No;
                            return;
                        }
                        wc.UploadProgressChanged += Wc_UploadProgressChanged;
                        wc.UploadFileCompleted += Wc_UploadFileCompleted;
                        wc.UploadFileAsync(new Uri(Aim), Source);

                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorCode = -11;
                this.DialogResult = DialogResult.No;
            }
        }

        private void Wc_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            if (e.Error != null && e.Error.Message != "")
            {
                labMsg.Text = e.Error.Message;
                labMsg.Visible = true;
                ErrorCode = -14;
                labMsg.Text = "保存过程中出现错误，请检查您的网络情况" + e.Error.Message;
                Delay(8000);
                this.DialogResult = DialogResult.No;
                return;
            }
            CheckForIllegalCrossThreadCalls = false;
            labMsg.Text = "保存完成，窗体即将自动关闭";
            labMsg.ForeColor = Color.DarkGreen;
            labMsg.Visible = true;
            Delay(4000);
            this.DialogResult = DialogResult.OK;
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null && e.Error.Message != "")
            {
                labProcess.Text = "ERR";
                labProcess.ForeColor = ColorTheme.UnSafeColor;
                labProcess.Refresh();
                labMsg.Text = e.Error.Message;
                labMsg.Visible = true;
                ErrorCode = -13;
                Delay(8000);
                this.DialogResult = DialogResult.No;
                return;
            }
            CheckForIllegalCrossThreadCalls = false;
            labMsg.Text = "加载完成，即将开始下一步";
            labMsg.ForeColor = Color.DarkGreen;
            labMsg.Visible = true;
            Delay(4000);
            this.DialogResult = DialogResult.OK;
        }

        private void Wc_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (e.ProgressPercentage < 0 && e.BytesSent >= e.TotalBytesToSend)
            {
                return;
            }
            double pv = (double)e.BytesSent / (double)e.TotalBytesToSend;
            int ProgressValue = (int)((pv) * 100.0);
            if (ProgressValue < 0)
            {
                ProgressValue = 0;
            }
            if (ProgressValue > 100)
            {
                ProgressValue = 100;
            }

            labProcess.Text = ProgressValue + "%";
            npbProgress.Value = ProgressValue;
            if (e.TotalBytesToSend / 1024 < 1024)
                labTip.Text = (e.BytesSent / 1024) + @"KB/" + (e.TotalBytesToSend / 1024) + @"KB";
            else
                labTip.Text = (e.BytesSent / 1024 / 1024) + @"MB/" + (e.TotalBytesToSend / 1024 / 1024) + @"MB";

        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (e.ProgressPercentage < 0 && e.BytesReceived >= e.TotalBytesToReceive)
            {
                return;
            }
            labProcess.Text = e.ProgressPercentage + "%";
            npbProgress.Value = e.ProgressPercentage;
            if (e.TotalBytesToReceive / 1024 < 1024)
                labTip.Text = (e.BytesReceived / 1024) + @"KB/" + (e.TotalBytesToReceive / 1024) + @"KB";
            else
                labTip.Text = (e.BytesReceived / 1024 / 1024) + @"MB/" + (e.TotalBytesToReceive / 1024 / 1024) + @"MB";
        }

        private void FrmFileExchange_Shown(object sender, EventArgs e)
        {
            if(hideForm)
            {
                this.Hide();
            }
            StartClient();
        }

        private void FrmFileExchange_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void FrmFileExchange_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }
        public static void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }
    }
}
