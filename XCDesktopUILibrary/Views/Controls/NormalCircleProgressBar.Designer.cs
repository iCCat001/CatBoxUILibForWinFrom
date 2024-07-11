namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class NormalCircleProgressBar
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
            this.normalCircleButton1 = new CatBoxDesktopUILibrary.Views.Controls.NormalCircleButton();
            this.SuspendLayout();
            // 
            // normalCircleButton1
            // 
            this.normalCircleButton1.Location = new System.Drawing.Point(3, 3);
            this.normalCircleButton1.Name = "normalCircleButton1";
            this.normalCircleButton1.Size = new System.Drawing.Size(183, 182);
            this.normalCircleButton1.TabIndex = 0;
            this.normalCircleButton1.Text = "normalCircleButton1";
            this.normalCircleButton1.UseVisualStyleBackColor = true;
            // 
            // NormalCircleProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.normalCircleButton1);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "NormalCircleProgressBar";
            this.Size = new System.Drawing.Size(189, 188);
            this.ResumeLayout(false);

        }

        #endregion

        private NormalCircleButton normalCircleButton1;
    }
}
