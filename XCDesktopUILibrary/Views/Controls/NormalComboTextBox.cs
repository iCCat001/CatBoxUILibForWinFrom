using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public partial class NormalComboTextBox : UserControl
    {
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("主按钮点击事件")]
        public event EventHandler ButtonClick
        {
            add
            {
                nButton.Click += value;
            }
            remove
            {
                nButton.Click -= value;
            }
        }
        

        private string placeHold = "PlaceHold";
        
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("置空时默认文本")]
        public string PlaceHold
        {
            set
            {
                placeHold = value;
                if(string.IsNullOrEmpty(nTextBox.Text) || nTextBox.Text == placeHold)
                {
                    nTextBox.Text = placeHold;
                    nTextBox.ForeColor = Color.DarkGray;
                    this.Invalidate();
                }
            }
            get
            {
                return placeHold;
            }
        }

        [Browsable(true)]
        [EditorBrowsable( EditorBrowsableState.Always)]
        [Description("按钮文字")]
        public string ButtonText
        {
            set
            {
                nButton.Text = value;
                if(nButton.AutoSize)
                {
                    nButton.Text = "";
                    nButton.Size = new Size(1, 1);
                    nButton.AutoSize = true;
                    nButton.Text = value;
                    nButton.Invalidate();
                    NormalComboTextBox_SizeChanged(null, null);
                    
                }
            }
            get
            {
                return nButton.Text;
            }
        }

        [Browsable(true)]
        public new Font Font
        {
            get
            {
                return nTextBox.Font;
            }
            set
            {
                nTextBox.Font = value;
                nButton.Font = value;
                NormalComboTextBox_SizeChanged(null, null);
                
            }
        }

        public NormalComboTextBox()
        {
            InitializeComponent();
            NormalComboTextBox_SizeChanged(null, null);
            NormalComboTextBox_BackColorChanged(null, null);
        }
        private void NormalComboTextBox_SizeChanged(object sender, EventArgs e)
        {
            nButton.Size = new Size(nButton.Width, this.Height);
            nButton.Top = 0;
            nButton.Left = this.Width - nButton.Width;
            nTextBox.Location = new Point(0, (int)((this.Height - nTextBox.Height) / 2));
            nTextBox.Size = new Size(nButton.Left, nTextBox.Height);

            //固定最小尺寸为子控件最小尺寸
            this.MinimumSize = nButton.MinimumSize;
        }

        private void NormalComboTextBox_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Transparent && this.BackColor.A == 255)
                nTextBox.BackColor = this.BackColor;
            else
                nTextBox.BackColor = Color.White;
            nTextBox.BorderColor = nTextBox.BackColor;
            nTextBox.Invalidate();
            this.Invalidate();
        }

        private void nTextBox_Enter(object sender, EventArgs e)
        {
            if(nTextBox.Text == PlaceHold)
            {
                nTextBox.Text = "";
                nTextBox.ForeColor = Color.Black;
            }
        }

        private void nTextBox_Leave(object sender, EventArgs e)
        {
            if(nTextBox.Text == null || nTextBox.Text == "")
            {
                nTextBox.Text = PlaceHold;
                nTextBox.ForeColor = Color.DarkGray;
            }
        }
    }
}
