namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class NormalMaterialBoard
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
            this.panColorBar = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.nLGridMain = new CatBoxDesktopUILibrary.Views.Controls.NormalLayoutGrid();
            this.SuspendLayout();
            // 
            // panColorBar
            // 
            this.panColorBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panColorBar.Location = new System.Drawing.Point(22, 17);
            this.panColorBar.Name = "panColorBar";
            this.panColorBar.Size = new System.Drawing.Size(10, 33);
            this.panColorBar.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("黑体", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(38, 23);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(65, 21);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "Title";
            // 
            // nLGridMain
            // 
            this.nLGridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nLGridMain.AutoScroll = true;
            this.nLGridMain.BackColor = System.Drawing.Color.Transparent;
            this.nLGridMain.GridSize = new System.Drawing.Size(34, 10);
            this.nLGridMain.Location = new System.Drawing.Point(0, 59);
            this.nLGridMain.Name = "nLGridMain";
            this.nLGridMain.Size = new System.Drawing.Size(1283, 313);
            this.nLGridMain.TabIndex = 2;
            // 
            // NormalMaterialBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.nLGridMain);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.panColorBar);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "NormalMaterialBoard";
            this.Size = new System.Drawing.Size(1280, 372);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panColorBar;
        private System.Windows.Forms.Label labTitle;
        private Controls.NormalLayoutGrid nLGridMain;
    }
}
