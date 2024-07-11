﻿using System.Drawing;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class NormalButton
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
            // NormalButton
            // 
            this.AutoSize = true;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("黑体", 9F);
            this.Size = new System.Drawing.Size(73, 34);
            this.Text = "按钮";
            this.BackColorChanged += new System.EventHandler(this.NormalButton_BackColorChanged);
            this.EnabledChanged += new System.EventHandler(this.NormalButton_EnabledChanged);
            this.Click += new System.EventHandler(this.NormalButton_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NormalButton_Paint);
            this.MouseEnter += new System.EventHandler(this.NormalButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.NormalButton_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
