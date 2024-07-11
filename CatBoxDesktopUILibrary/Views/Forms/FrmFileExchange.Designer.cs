namespace CatBoxDesktopUILibrary.Views.Forms
{
    partial class FrmFileExchange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileExchange));
            this.labTitle = new System.Windows.Forms.Label();
            this.labProcess = new System.Windows.Forms.Label();
            this.labTip = new System.Windows.Forms.Label();
            this.labMsg = new System.Windows.Forms.Label();
            this.npbProgress = new CatBoxDesktopUILibrary.Views.Controls.NormalProgressBar();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("黑体", 15.05455F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(14, 10);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(286, 24);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "正在传输文件，请稍候...";
            // 
            // labProcess
            // 
            this.labProcess.AutoSize = true;
            this.labProcess.Font = new System.Drawing.Font("黑体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labProcess.Location = new System.Drawing.Point(14, 61);
            this.labProcess.Name = "labProcess";
            this.labProcess.Size = new System.Drawing.Size(80, 55);
            this.labProcess.TabIndex = 1;
            this.labProcess.Text = "0%";
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.Location = new System.Drawing.Point(180, 101);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(35, 14);
            this.labTip.TabIndex = 3;
            this.labTip.Text = "Tips";
            // 
            // labMsg
            // 
            this.labMsg.AutoSize = true;
            this.labMsg.ForeColor = System.Drawing.Color.DarkRed;
            this.labMsg.Location = new System.Drawing.Point(180, 71);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(63, 14);
            this.labMsg.TabIndex = 3;
            this.labMsg.Text = "ErrorMsg";
            this.labMsg.Visible = false;
            // 
            // npbProgress
            // 
            this.npbProgress.ForeColor = System.Drawing.Color.DarkGray;
            this.npbProgress.Location = new System.Drawing.Point(-2, 128);
            this.npbProgress.Name = "npbProgress";
            this.npbProgress.Size = new System.Drawing.Size(937, 27);
            this.npbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.npbProgress.TabIndex = 2;
            // 
            // FrmFileExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(933, 136);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.labTip);
            this.Controls.Add(this.npbProgress);
            this.Controls.Add(this.labProcess);
            this.Controls.Add(this.labTitle);
            this.HeaderHeight = 0;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFileExchange";
            this.Shown += new System.EventHandler(this.FrmFileExchange_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmFileExchange_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmFileExchange_MouseMove);
            this.Controls.SetChildIndex(this.labTitle, 0);
            this.Controls.SetChildIndex(this.labProcess, 0);
            this.Controls.SetChildIndex(this.npbProgress, 0);
            this.Controls.SetChildIndex(this.labTip, 0);
            this.Controls.SetChildIndex(this.labMsg, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label labProcess;
        private Controls.NormalProgressBar npbProgress;
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.Label labMsg;
    }
}