namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class AboutBorad
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
            this.labVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labVersion
            // 
            this.labVersion.AutoSize = true;
            this.labVersion.Location = new System.Drawing.Point(168, 32);
            this.labVersion.Name = "labVersion";
            this.labVersion.Size = new System.Drawing.Size(357, 14);
            this.labVersion.TabIndex = 0;
            this.labVersion.Text = "xxxx软件公司 版权所有 | 软件版本： Ver.1.2.000";
            // 
            // AboutBorad
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.labVersion);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "AboutBorad";
            this.Size = new System.Drawing.Size(747, 89);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labVersion;
    }
}
