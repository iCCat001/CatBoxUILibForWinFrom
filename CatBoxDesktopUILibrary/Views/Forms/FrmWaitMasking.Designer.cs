namespace CatBoxDesktopUILibrary.Views.Forms
{
    partial class FrmWaitMasking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWaitMasking));
            this.labTips = new System.Windows.Forms.Label();
            this.npbIcon = new CatBoxDesktopUILibrary.Views.Controls.NormalPictureBoxFade();
            ((System.ComponentModel.ISupportInitialize)(this.npbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labTips
            // 
            this.labTips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTips.Font = new System.Drawing.Font("黑体", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTips.ForeColor = System.Drawing.Color.White;
            this.labTips.Location = new System.Drawing.Point(12, 290);
            this.labTips.Name = "labTips";
            this.labTips.Size = new System.Drawing.Size(776, 151);
            this.labTips.TabIndex = 1;
            this.labTips.Text = "正在执行操作...";
            this.labTips.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // npbIcon
            // 
            this.npbIcon.BackColor = System.Drawing.Color.Transparent;
            this.npbIcon.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources._9;
            this.npbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.npbIcon.FlameInterval = 33;
            this.npbIcon.Location = new System.Drawing.Point(345, 132);
            this.npbIcon.Name = "npbIcon";
            this.npbIcon.pics = ((System.Collections.Generic.List<System.Drawing.Bitmap>)(resources.GetObject("npbIcon.pics")));
            this.npbIcon.Size = new System.Drawing.Size(105, 98);
            this.npbIcon.TabIndex = 0;
            this.npbIcon.TabStop = false;
            // 
            // FrmWaitMasking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labTips);
            this.Controls.Add(this.npbIcon);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmWaitMasking";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmWaitMasking_Load);
            this.Shown += new System.EventHandler(this.FrmWaitMasking_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmWaitMasking_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.npbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NormalPictureBoxFade npbIcon;
        private System.Windows.Forms.Label labTips;
    }
}