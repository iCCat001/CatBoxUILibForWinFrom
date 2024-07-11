namespace CatBoxDesktopUILibrary.Views.Forms
{
    partial class FrmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBase));
            this.panHeader = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.nbtMax = new CatBoxDesktopUILibrary.Views.Controls.NormalButton();
            this.nbtMini = new CatBoxDesktopUILibrary.Views.Controls.NormalButton();
            this.nbtClose = new CatBoxDesktopUILibrary.Views.Controls.NormalButton();
            this.panHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panHeader
            // 
            this.panHeader.BackColor = System.Drawing.Color.Transparent;
            this.panHeader.Controls.Add(this.labTitle);
            this.panHeader.Controls.Add(this.nbtMax);
            this.panHeader.Controls.Add(this.nbtMini);
            this.panHeader.Controls.Add(this.nbtClose);
            this.panHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(716, 36);
            this.panHeader.TabIndex = 0;
            this.panHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panHeader_MouseDown);
            this.panHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panHeader_MouseMove);
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(3, 11);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(48, 16);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "Title";
            // 
            // nbtMax
            // 
            this.nbtMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nbtMax.AutoSize = true;
            this.nbtMax.BackColor = System.Drawing.Color.Transparent;
            this.nbtMax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nbtMax.BackgroundImage")));
            this.nbtMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nbtMax.ButtonType = CatBoxDesktopUILibrary.Views.Controls.NormalButton.ButtonTypes.TransportBW;
            this.nbtMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nbtMax.FlatAppearance.BorderSize = 0;
            this.nbtMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nbtMax.Font = new System.Drawing.Font("黑体", 9F);
            this.nbtMax.ForeColor = System.Drawing.Color.Black;
            this.nbtMax.Location = new System.Drawing.Point(646, 6);
            this.nbtMax.Name = "nbtMax";
            this.nbtMax.Size = new System.Drawing.Size(25, 25);
            this.nbtMax.TabIndex = 0;
            this.nbtMax.Text = " ";
            this.nbtMax.UseVisualStyleBackColor = false;
            this.nbtMax.Click += new System.EventHandler(this.nbtMax_Click);
            // 
            // nbtMini
            // 
            this.nbtMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nbtMini.AutoSize = true;
            this.nbtMini.BackColor = System.Drawing.Color.Transparent;
            this.nbtMini.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nbtMini.BackgroundImage")));
            this.nbtMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nbtMini.ButtonType = CatBoxDesktopUILibrary.Views.Controls.NormalButton.ButtonTypes.TransportBW;
            this.nbtMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nbtMini.FlatAppearance.BorderSize = 0;
            this.nbtMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nbtMini.Font = new System.Drawing.Font("黑体", 9F);
            this.nbtMini.ForeColor = System.Drawing.Color.Black;
            this.nbtMini.Location = new System.Drawing.Point(604, 6);
            this.nbtMini.Name = "nbtMini";
            this.nbtMini.Size = new System.Drawing.Size(25, 25);
            this.nbtMini.TabIndex = 0;
            this.nbtMini.Text = " ";
            this.nbtMini.UseVisualStyleBackColor = false;
            this.nbtMini.Click += new System.EventHandler(this.nbtMini_Click);
            // 
            // nbtClose
            // 
            this.nbtClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nbtClose.AutoSize = true;
            this.nbtClose.BackColor = System.Drawing.Color.Transparent;
            this.nbtClose.BackgroundImage = global::CatBoxDesktopUILibrary.Properties.Resources.CloseD;
            this.nbtClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nbtClose.ButtonType = CatBoxDesktopUILibrary.Views.Controls.NormalButton.ButtonTypes.WarnningLight;
            this.nbtClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nbtClose.FlatAppearance.BorderSize = 0;
            this.nbtClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nbtClose.Font = new System.Drawing.Font("黑体", 9F);
            this.nbtClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.nbtClose.Location = new System.Drawing.Point(688, 6);
            this.nbtClose.Name = "nbtClose";
            this.nbtClose.Size = new System.Drawing.Size(25, 25);
            this.nbtClose.TabIndex = 0;
            this.nbtClose.Text = " ";
            this.nbtClose.UseVisualStyleBackColor = false;
            this.nbtClose.Click += new System.EventHandler(this.nbtClose_Click);
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(716, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panHeader);
            this.Font = new System.Drawing.Font("黑体", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBase";
            this.SizeChanged += new System.EventHandler(this.FrmBase_SizeChanged);
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.Label labTitle;
        private CatBoxDesktopUILibrary.Views.Controls.NormalButton nbtMax;
        private CatBoxDesktopUILibrary.Views.Controls.NormalButton nbtClose;
        private CatBoxDesktopUILibrary.Views.Controls.NormalButton nbtMini;
    }
}