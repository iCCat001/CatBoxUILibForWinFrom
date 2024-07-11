using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace CatBoxDesktopUILibrary.Controls
{
    /// <summary>
    /// 提供部分常用的2D图形相关函数，主要涉及数学运算
    /// </summary>
    public class Shape2D
    {
        /// <summary>
        /// 输出圆角矩形
        /// </summary>
        /// <param name="x">绘制起始坐标X</param>
        /// <param name="y">绘制起始坐标Y</param>
        /// <param name="Width">绘制区域宽度</param>
        /// <param name="Height">绘制区域高度</param>
        /// <param name="Radian">弧度半径</param>
        /// <returns></returns>
        public static GraphicsPath GetRoundRect(int x , int y , int Width , int Height , int Radian)
        {
            try
            {
                
                //参数合理性自检
                if (Width <= 2)
                {
                    throw new Exception("非法参数：宽度参数小于或等于2");
                }
                if (Height <= 2)
                {
                    throw new Exception("非法参数：高度参数小于或等于2");
                }
                if (Radian <= 2)
                {
                    throw new Exception("非法参数：弧度半径参数小于或等于2");
                }
                if (Radian > (Height < Width ? Height : Width))
                {
                    //throw new Exception("非法参数：弧度半径参数超过最小边");
                    //当弧度半径超过最短边时，返回最大值，即为胶囊体
                    Radian = Height < Width ? Height : Width;
                }

                GraphicsPath gp = new GraphicsPath();
                gp.FillMode = FillMode.Winding;
                //手动闭合模式
                //从左上弧线左起点开始依次绘制边界线条
                gp.AddArc(x, y, Radian, Radian, 180, 90);

                //手动上边界直线
                //gp.AddLine(x + Radian / 2, y, x + Width - Radian / 2, y);

                //右上弧线
                gp.AddArc(x + Width - Radian, y, Radian, Radian, 270, 90);

                //手动右边界直线
                //gp.AddLine(x + Width, y + Radian / 2, x + Width, y + Height - Radian / 2);

                //右下
                gp.AddArc(x + Width - Radian, y + Height - Radian, Radian, Radian, 0, 90);

                //手动下边界直线
                //gp.AddLine(x + Width - Radian / 2, y + Height, x + Radian / 2, y + Height);

                //左下
                gp.AddArc(x, y + Height - Radian, Radian, Radian, 90, 90);

                //手动左边界直线
                //gp.AddLine(x, y + Height - Radian / 2, x, y + Radian / 2);

                gp.CloseAllFigures();
                return gp;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
