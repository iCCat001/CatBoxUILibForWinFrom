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
    public partial class AboutBorad : UserControl
    {
        public AboutBorad()
        {
            InitializeComponent();
            GetVersion();
            this.SizeChanged += AboutBorad_SizeChanged;
            AboutBorad_SizeChanged(null, null);
        }

        private void AboutBorad_SizeChanged(object sender, EventArgs e)
        {
            labVersion.AutoSize = true;
            labVersion.Location = new Point((int)((this.Width - labVersion.Width) / 2),
                (int)((this.Height - labVersion.Height) / 2));
        }

        public void GetVersion(bool SimpleMode = false)
        {
            if(!SimpleMode)
            {
                labVersion.Text = " 版本：" + Application.ProductVersion;
                labVersion.Text += "\n©2021 xxxx软件有限公司\n版权所有";
                labVersion.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                labVersion.Text = "©2021 xxxx软件有限公司\n版权所有";
                labVersion.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}
