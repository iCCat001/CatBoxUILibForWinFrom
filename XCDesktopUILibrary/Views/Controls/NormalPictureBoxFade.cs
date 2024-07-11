using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public partial class NormalPictureBoxFade : PictureBox
    {
        System.Timers.Timer timChange = new System.Timers.Timer();

        List<Bitmap> p = new List<Bitmap>();

        private int flameInterval = 33;//30帧
        [Browsable(true)]
        [Description("动画每帧间隔时间")]
        public int FlameInterval
        {
            get
            {
                return flameInterval;
            }
            set
            {
                flameInterval = value;
            }
        }
        public List<Bitmap> pics
        {
            get
            {
                return p;
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackgroundImage = value[0];
                    p = value;
                }
            }
        }

        int indexNow = 0;

        public NormalPictureBoxFade()
        {
            InitializeComponent();
            timChange.Interval = 2000;
            timChange.Elapsed += TimChange_Tick;
            LayoutDraw();
        }

        private void LayoutDraw()
        {
            this.Size = new Size(100, 100);
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.Transparent;
        }

        private void TimChange_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pics.Count > 0)
                {
                    if (indexNow == pics.Count)
                        indexNow = 0;
                    FadeIn(pics[indexNow], this);
                    indexNow++;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ChangeSwicth(bool s)
        {
            if (s)
            {
                TimChange_Tick(null, null);
                timChange.Enabled = true;
                timChange.Start();
            }
            else
            {
                timChange.Enabled = false;
                timChange.Stop();
            }
        }

        public void FadeIn(Bitmap bmp, PictureBox picBox)
        {
            //淡入显示图像
            try
            {
                Graphics g = picBox.CreateGraphics();
                if(this.BackColor != Color.Transparent)
                {
                    g.Clear(this.BackColor);
                }
                else
                {
                    g.Clear(CatBoxDesktopUILibrary.Controls.ThemeHelper.GetControlDisplayColor(this));
                }
                
                ImageAttributes attributes = new ImageAttributes();
                ColorMatrix matrix = new ColorMatrix(new float[][]
                {
                    new float[]{ 1,0,0,0,0 },
                    new float[]{ 0,1,0,0,0 },
                    new float[]{ 0,0,1,0,0 },
                    new float[]{ 0,0,0,1,0 },
                    new float[]{ 0,0,0,0,1 },
                });
                //从0到1进行修改色彩变换矩阵主对角线上的数值
                //使三种基准色的透明度渐增
                Single count = (float)0.0;
                while (count < 1.0)
                {
                    matrix.Matrix33 = count;
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(bmp, new Rectangle(0, 0, picBox.Width, picBox.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attributes);
                    System.Threading.Thread.Sleep(FlameInterval);
                    //取决于机器性能
                    count = (float)(count + 0.05);//动画总共20帧
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "信息提示");
            }
        }
    }
}
