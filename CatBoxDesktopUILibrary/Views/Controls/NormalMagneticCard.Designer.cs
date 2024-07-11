namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class NormalMagneticCard
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NormalMagneticCard));
            this.labMessage = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.Label();
            this.labSubTitle = new System.Windows.Forms.Label();
            this.panButtons = new System.Windows.Forms.Panel();
            this.nbtSure = new CatBoxDesktopUILibrary.Views.Controls.NormalButton();
            this.nbtUnInstall = new CatBoxDesktopUILibrary.Views.Controls.NormalButton();
            this.panMessage = new System.Windows.Forms.Panel();
            this.npbLogo = new CatBoxDesktopUILibrary.Views.Controls.NormalPictureBoxFade();
            this.panButtons.SuspendLayout();
            this.panMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Location = new System.Drawing.Point(9, 9);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(70, 13);
            this.labMessage.TabIndex = 1;
            this.labMessage.Text = "[Message]";
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("黑体", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(0, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(79, 19);
            this.labTitle.TabIndex = 3;
            this.labTitle.Text = "[Title]";
            // 
            // labSubTitle
            // 
            this.labSubTitle.AutoSize = true;
            this.labSubTitle.Font = new System.Drawing.Font("黑体", 10.47273F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSubTitle.Location = new System.Drawing.Point(78, 4);
            this.labSubTitle.Name = "labSubTitle";
            this.labSubTitle.Size = new System.Drawing.Size(77, 14);
            this.labSubTitle.TabIndex = 3;
            this.labSubTitle.Text = "[SubTitle]";
            // 
            // panButtons
            // 
            this.panButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panButtons.BackColor = System.Drawing.Color.Transparent;
            this.panButtons.Controls.Add(this.nbtSure);
            this.panButtons.Controls.Add(this.nbtUnInstall);
            this.panButtons.Location = new System.Drawing.Point(224, 188);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(140, 31);
            this.panButtons.TabIndex = 4;
            // 
            // nbtSure
            // 
            this.nbtSure.AutoSize = true;
            this.nbtSure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.nbtSure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nbtSure.FlatAppearance.BorderSize = 0;
            this.nbtSure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nbtSure.Font = new System.Drawing.Font("黑体", 9F);
            this.nbtSure.ForeColor = System.Drawing.Color.White;
            this.nbtSure.Location = new System.Drawing.Point(10, 3);
            this.nbtSure.Name = "nbtSure";
            this.nbtSure.Size = new System.Drawing.Size(45, 26);
            this.nbtSure.TabIndex = 2;
            this.nbtSure.Text = "B1";
            this.nbtSure.UseVisualStyleBackColor = false;
            // 
            // nbtUnInstall
            // 
            this.nbtUnInstall.AutoSize = true;
            this.nbtUnInstall.BackColor = System.Drawing.Color.Transparent;
            this.nbtUnInstall.ButtonType = CatBoxDesktopUILibrary.Views.Controls.NormalButton.ButtonTypes.TransportBW;
            this.nbtUnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nbtUnInstall.FlatAppearance.BorderSize = 0;
            this.nbtUnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nbtUnInstall.Font = new System.Drawing.Font("黑体", 9F);
            this.nbtUnInstall.ForeColor = System.Drawing.Color.Black;
            this.nbtUnInstall.Location = new System.Drawing.Point(61, 2);
            this.nbtUnInstall.Name = "nbtUnInstall";
            this.nbtUnInstall.Size = new System.Drawing.Size(42, 26);
            this.nbtUnInstall.TabIndex = 2;
            this.nbtUnInstall.Text = "B2";
            this.nbtUnInstall.UseVisualStyleBackColor = false;
            // 
            // panMessage
            // 
            this.panMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panMessage.Controls.Add(this.labMessage);
            this.panMessage.Location = new System.Drawing.Point(0, 188);
            this.panMessage.Name = "panMessage";
            this.panMessage.Size = new System.Drawing.Size(218, 31);
            this.panMessage.TabIndex = 6;
            // 
            // npbLogo
            // 
            this.npbLogo.BackColor = System.Drawing.Color.Transparent;
            this.npbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.npbLogo.FlameInterval = 33;
            this.npbLogo.Location = new System.Drawing.Point(0, 31);
            this.npbLogo.Name = "npbLogo";
            this.npbLogo.pics = ((System.Collections.Generic.List<System.Drawing.Bitmap>)(resources.GetObject("npbLogo.pics")));
            this.npbLogo.Size = new System.Drawing.Size(368, 151);
            this.npbLogo.TabIndex = 0;
            this.npbLogo.TabStop = false;
            // 
            // NormalMagneticCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panMessage);
            this.Controls.Add(this.panButtons);
            this.Controls.Add(this.labSubTitle);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.npbLogo);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "NormalMagneticCard";
            this.Size = new System.Drawing.Size(368, 223);
            this.Load += new System.EventHandler(this.NormalMagneticCard_Load);
            this.SizeChanged += new System.EventHandler(this.NormalMagneticCard_SizeChanged);
            this.Click += new System.EventHandler(this.NormalMagneticCard_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NormalMagneticCard_Paint);
            this.panButtons.ResumeLayout(false);
            this.panButtons.PerformLayout();
            this.panMessage.ResumeLayout(false);
            this.panMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NormalPictureBoxFade npbLogo;
        private System.Windows.Forms.Label labMessage;
        private NormalButton nbtUnInstall;
        private NormalButton nbtSure;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label labSubTitle;
        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Panel panMessage;
    }
}
