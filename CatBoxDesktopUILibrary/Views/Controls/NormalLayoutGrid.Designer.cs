using System.ComponentModel;
using System.ComponentModel.Design;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    
    partial class NormalLayoutGrid
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
            this.SuspendLayout();
            // 
            // NormalLayoutGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "NormalLayoutGrid";
            this.Size = new System.Drawing.Size(540, 328);
            this.Load += new System.EventHandler(this.NormalLayoutGrid_Load);
            this.SizeChanged += new System.EventHandler(this.NormalLayoutGrid_SizeChanged);
            this.Click += new System.EventHandler(this.NormalLayoutGrid_Click);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.NormalLayoutGrid_ControlAdded);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.NormalLayoutGrid_ControlRemoved);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NormalLayoutGrid_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
