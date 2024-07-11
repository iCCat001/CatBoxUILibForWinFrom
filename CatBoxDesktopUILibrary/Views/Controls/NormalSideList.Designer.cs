namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class NormalSideBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NormalSideBar));
            this.panHeader = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.pbLogo = new CatBoxDesktopUILibrary.Views.Controls.PictureBoxFadeIn();
            this.panItem = new System.Windows.Forms.Panel();
            this.boardAboutBottom = new CatBoxDesktopUILibrary.Views.Controls.AboutBorad();
            this.panHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panHeader
            // 
            this.panHeader.Controls.Add(this.labTitle);
            this.panHeader.Controls.Add(this.pbLogo);
            this.panHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(422, 128);
            this.panHeader.TabIndex = 2;
            // 
            // labTitle
            // 
            this.labTitle.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labTitle.Location = new System.Drawing.Point(20, 69);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(394, 46);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "[SideBar Title]";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.Location = new System.Drawing.Point(12, 38);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.pics = ((System.Collections.Generic.List<System.Drawing.Bitmap>)(resources.GetObject("pbLogo.pics")));
            this.pbLogo.Size = new System.Drawing.Size(145, 28);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // panItem
            // 
            this.panItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panItem.Location = new System.Drawing.Point(0, 128);
            this.panItem.Name = "panItem";
            this.panItem.Size = new System.Drawing.Size(422, 879);
            this.panItem.TabIndex = 3;
            // 
            // boardAboutBottom
            // 
            this.boardAboutBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.boardAboutBottom.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.boardAboutBottom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.boardAboutBottom.Location = new System.Drawing.Point(0, 1007);
            this.boardAboutBottom.Name = "boardAboutBottom";
            this.boardAboutBottom.Size = new System.Drawing.Size(422, 52);
            this.boardAboutBottom.TabIndex = 1;
            // 
            // NormalSideBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(134)))), ((int)(((byte)(218)))));
            this.Controls.Add(this.panItem);
            this.Controls.Add(this.panHeader);
            this.Controls.Add(this.boardAboutBottom);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "NormalSideBar";
            this.Size = new System.Drawing.Size(422, 1059);
            this.panHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AboutBorad boardAboutBottom;
        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.Label labTitle;
        private PictureBoxFadeIn pbLogo;
        private System.Windows.Forms.Panel panItem;
    }
}
