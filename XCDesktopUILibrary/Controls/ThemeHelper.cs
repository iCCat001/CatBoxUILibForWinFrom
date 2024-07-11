
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CatBoxDesktopUILibrary.Controls
{
    /// <summary>
    /// 包含UI所需的大部分色彩，UI相关运算函数和过程
    /// </summary>
    public class ThemeHelper
    {
        /// <summary>
        /// 根据背景色返回色调相反，从而不影响文字阅读的前景色
        /// 2020.07.15，C-Cat:新建
        /// </summary>
        /// <param name="BackColor">背景色</param>
        /// <returns>黑色或者白色</returns>
        public static Color GetForeColor(Color BackColor)
        {
            if ((BackColor.R * 0.299 +
                BackColor.G * 0.587 +
                BackColor.B * 0.114)
                > 186)
                return Color.Black;
            else
                return Color.White;
        }

        /// <summary>
        /// 获取控件的显示背景颜色（透明则递归其父控件背景色）,错误时默认黑色
        /// </summary>
        /// <param name="ctl">目标控件</param>
        /// <returns></returns>
        public static Color GetControlDisplayColor(Control ctl)
        {
            try
            {
                if (ctl.BackColor != Color.Transparent)
                {
                    return ctl.BackColor;
                }
                else if (ctl.Parent != null)
                {
                    try
                    {
                        return GetControlDisplayColor(ctl.Parent);
                    }
                    catch (Exception ex)
                    {
                        return Color.Black;
                    }
                }
                else
                {
                    return Color.Black;
                }
            }
            catch (Exception e)
            {
                return Color.Black;
            }

        }

        /// <summary>
        /// 将输入的颜色提高或者降低指定亮度
        /// </summary>
        /// <param name="OriginColor">输入颜色</param>
        /// <param name="Brightness">亮度变化值</param>
        /// <returns></returns>
        public static Color ChangeBrightness(Color OriginColor, int Brightness)
        {
            int[] ColorYUV = ConvertRGBToYUV(OriginColor);
            //修改Y值以达到修改亮度
            ColorYUV[0] += Brightness;
            if (ColorYUV[0] < 0) ColorYUV[0] = 0;
            if (ColorYUV[0] > 255) ColorYUV[0] = 255;

            Color aim = ConvertYUVToRGB(ColorYUV);
            
            return Color.FromArgb(OriginColor.A,aim.R,aim.G,aim.B);
        }

        /// <summary>
        /// 转换RGB颜色为YUV颜色
        /// </summary>
        /// <param name="OriginColor"></param>
        /// <returns></returns>
        public static int[] ConvertRGBToYUV(Color OriginColor)
        {
            int Y = ((66 * OriginColor.R +
                129 * OriginColor.G +
                25 * OriginColor.B + 128)
                >> 8)
                + 16;

            int U = ((-38 * OriginColor.R -
                74 * OriginColor.G +
                112 * OriginColor.B + 128)
                >> 8)
                + 128;
            int V = ((112 * OriginColor.R -
                94 * OriginColor.G -
                18 * OriginColor.B + 128)
                >> 8)
                + 128;
            return new int[] { Y, U, V };
        }
    
        public static Color ConvertYUVToRGB(int[] ColorYUV)
        {
            int R = ColorYUV[0] + ((360 * (ColorYUV[2] - 128)) >> 8);
            int G = ColorYUV[0] - (((88 * (ColorYUV[1] - 128) + 184 * (ColorYUV[2] - 128))) >> 8);
            int B = ColorYUV[0] + ((455 * (ColorYUV[1] - 128)) >> 8);
            if (R > 255) R = 255;
            if (R < 0) R = 0;
            if (G > 255) G = 255;
            if (G < 0) G = 0;
            if (B > 255) B = 255;
            if (B < 0) B = 0;
            return Color.FromArgb(R, G, B);
        }
    }


}
