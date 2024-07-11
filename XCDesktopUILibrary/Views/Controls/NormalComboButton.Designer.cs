namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class NormalComboButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NormalComboButton));
            this.labTitle = new System.Windows.Forms.Label();
            this.pbIcon = new CatBoxDesktopUILibrary.Views.Controls.PictureBoxFadeIn();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoEllipsis = true;
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labTitle.Location = new System.Drawing.Point(0, 110);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(150, 40);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "label1";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labTitle.Click += new System.EventHandler(this.labTitle_Click);
            // 
            // pbIcon
            // 
            this.pbIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbIcon.Location = new System.Drawing.Point(25, 3);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.pics = ((System.Collections.Generic.List<System.Drawing.Bitmap>)(resources.GetObject("pbIcon.pics")));
            this.pbIcon.Size = new System.Drawing.Size(100, 104);
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            this.pbIcon.Click += new System.EventHandler(this.pbIcon_Click);
            // 
            // NormalComboButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.pbIcon);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "NormalComboButton";
            this.SizeChanged += new System.EventHandler(this.NormalComboButton_SizeChanged);
            this.Click += new System.EventHandler(this.NormalComboButton_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NormalComboButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.NormalComboButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.NormalComboButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NormalComboButton_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CatBoxDesktopUILibrary.Views.Controls.PictureBoxFadeIn pbIcon;
        private System.Windows.Forms.Label labTitle;
    }
}
