namespace CatBoxDesktopUILibrary.Views.Controls
{
    partial class NormalComboTextBox
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
            this.nButton = new CatBoxDesktopUILibrary.Views.Controls.NormalButton();
            this.nTextBox = new CatBoxDesktopUILibrary.Views.Controls.NormalTextBox();
            this.SuspendLayout();
            // 
            // nButton
            // 
            this.nButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nButton.AutoSize = true;
            this.nButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.nButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nButton.FlatAppearance.BorderSize = 0;
            this.nButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nButton.Font = new System.Drawing.Font("黑体", 9F);
            this.nButton.ForeColor = System.Drawing.Color.White;
            this.nButton.Location = new System.Drawing.Point(249, 3);
            this.nButton.Name = "nButton";
            this.nButton.Size = new System.Drawing.Size(71, 24);
            this.nButton.TabIndex = 1;
            this.nButton.Text = "button";
            this.nButton.UseVisualStyleBackColor = false;
            // 
            // nTextBox
            // 
            this.nTextBox.BorderColor = System.Drawing.Color.Black;
            this.nTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nTextBox.Location = new System.Drawing.Point(0, 3);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(253, 23);
            this.nTextBox.TabIndex = 0;
            this.nTextBox.Enter += new System.EventHandler(this.nTextBox_Enter);
            this.nTextBox.Leave += new System.EventHandler(this.nTextBox_Leave);
            // 
            // NormalComboTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.nButton);
            this.Controls.Add(this.nTextBox);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "NormalComboTextBox";
            this.Size = new System.Drawing.Size(320, 29);
            this.BackColorChanged += new System.EventHandler(this.NormalComboTextBox_BackColorChanged);
            this.SizeChanged += new System.EventHandler(this.NormalComboTextBox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CatBoxDesktopUILibrary.Views.Controls.NormalButton nButton;
        private CatBoxDesktopUILibrary.Views.Controls.NormalTextBox nTextBox;
    }
}
