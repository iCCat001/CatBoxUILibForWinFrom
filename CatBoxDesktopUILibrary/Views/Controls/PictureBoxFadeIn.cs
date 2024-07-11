using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public class PictureBoxFadeIn : PictureBox
    {
        Timer timChange = new Timer();

        List<Bitmap> p = new List<Bitmap>();
        public List<Bitmap> pics
        {
            get
            {
                return p;
            }
            set
            {
                if(value != null && value.Count > 0)
                {
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackgroundImage = value[0];
                    p = value;
                }
            }
        }

        int indexNow = 0;
        public PictureBoxFadeIn()
        {
            timChange.Interval = 3500;
            timChange.Tick += TimChange_Tick;
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
            catch(Exception ex)
            {

            }
        }

        public void ChangeSwicth(bool s)
        {
            if(s)
            {
                TimChange_Tick(null, null);
                timChange.Enabled = true;
            }
            else
            {
                timChange.Enabled = false;
            }    
        }

        public void FadeIn(Bitmap bmp, PictureBox picBox)
        {
            //淡入显示图像
            try
            {
                Graphics g = picBox.CreateGraphics();
                g.Clear(Color.White);
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
                //使三种基准色的饱和度渐增
                Single count = (float)0.0;
                while (count < 1.0)
                {
                    matrix.Matrix33 = count;
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(bmp, new Rectangle(0, 0, picBox.Width, picBox.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attributes);
                    System.Threading.Thread.Sleep(33);//30帧理论MAX
                    //取决于机器性能
                    count = (float)(count + 0.04);//总共25帧
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "信息提示");
            }
        }
    }
}
