namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class NormalSideBarItem
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
            this.panSideColorBar = new System.Windows.Forms.Panel();
            this.panTab = new System.Windows.Forms.Panel();
            this.PanBitmap = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.labText = new System.Windows.Forms.Label();
            this.PanBitmap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panSideColorBar
            // 
            this.panSideColorBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panSideColorBar.Location = new System.Drawing.Point(0, 0);
            this.panSideColorBar.Name = "panSideColorBar";
            this.panSideColorBar.Size = new System.Drawing.Size(4, 106);
            this.panSideColorBar.TabIndex = 0;
            // 
            // panTab
            // 
            this.panTab.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTab.Location = new System.Drawing.Point(4, 0);
            this.panTab.Name = "panTab";
            this.panTab.Size = new System.Drawing.Size(37, 106);
            this.panTab.TabIndex = 2;
            // 
            // PanBitmap
            // 
            this.PanBitmap.Controls.Add(this.pbLogo);
            this.PanBitmap.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanBitmap.Location = new System.Drawing.Point(41, 0);
            this.PanBitmap.Name = "PanBitmap";
            this.PanBitmap.Size = new System.Drawing.Size(61, 106);
            this.PanBitmap.TabIndex = 5;
            this.PanBitmap.SizeChanged += new System.EventHandler(this.PanBitmap_SizeChanged);
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.Location = new System.Drawing.Point(0, 18);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(61, 61);
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            this.pbLogo.SizeChanged += new System.EventHandler(this.pbLogo_SizeChanged);
            // 
            // labText
            // 
            this.labText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labText.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labText.Location = new System.Drawing.Point(102, 0);
            this.labText.Name = "labText";
            this.labText.Size = new System.Drawing.Size(539, 106);
            this.labText.TabIndex = 7;
            this.labText.Text = "Item";
            this.labText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NormalSideBarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labText);
            this.Controls.Add(this.PanBitmap);
            this.Controls.Add(this.panTab);
            this.Controls.Add(this.panSideColorBar);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "NormalSideBarItem";
            this.Size = new System.Drawing.Size(641, 106);
            this.BackColorChanged += new System.EventHandler(this.NormalSideBarItem_BackColorChanged);
            this.DockChanged += new System.EventHandler(this.NormalSideBarItem_DockChanged);
            this.Click += new System.EventHandler(this.NormalSideBarItem_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NormalSideBarItem_MouseDown);
            this.MouseEnter += new System.EventHandler(this.NormalSideBarItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.NormalSideBarItem_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NormalSideBarItem_MouseUp);
            this.PanBitmap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panSideColorBar;
        private System.Windows.Forms.Panel panTab;
        private System.Windows.Forms.Panel PanBitmap;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label labText;
    }
}
