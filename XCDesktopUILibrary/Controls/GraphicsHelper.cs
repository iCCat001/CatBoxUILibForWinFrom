using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CatBoxDesktopUILibrary.Controls
{
    public class GraphicsHelper
    {
        /// <summary>
        /// 测算以指定字体显示某段文字时，需要的区域大小（通过Graphics相关函数）
        /// </summary>
        /// <param name="AimGraphics">用于测算的Grahics对象</param>
        /// <param name="DisplayText">显示文字</param>
        /// <param name="DisplayFont">显示字体</param>
        /// <param name="LimitWidth">[可选]限制宽度，若需设置则必须大于0，若设置了限制宽度，则会自动换行</param>
        /// <returns></returns>
        public static Size GetTextDisplayArea(Graphics AimGraphics, string DisplayText, Font DisplayFont, int LimitWidth = 0)
        {
            try
            {
                Size sizeDisplay = new Size(0, 0);
                if (AimGraphics != null)
                {
                    AimGraphics.PageUnit = GraphicsUnit.Pixel;
                    //限宽与非限宽区别计算
                    if(LimitWidth > 0)
                    {
                        //宽度限制应当高于最少一个字符的宽度
                        float fMaxSingleWidth = 0;
                        foreach (char chrSingle in DisplayText)
                        {
                            float fSingleWidth = AimGraphics.MeasureString(chrSingle + "", DisplayFont).Width;
                            fMaxSingleWidth = fMaxSingleWidth > fSingleWidth ? fMaxSingleWidth : fSingleWidth;
                        }
                        if (LimitWidth < fMaxSingleWidth)
                        {
                            throw new Exception("宽度限制低于单个字符的宽度");
                        }

                        //首先测算宽度是否高于宽度限制（需要换行）
                        SizeF sizeLongest = AimGraphics.MeasureString(DisplayText, DisplayFont);
                        if (sizeLongest.Width > LimitWidth)
                        {
                            string strTemp = "";
                            List<string> strDisplayGroup = new List<string>();
                            int LengthRecord = 0;
                            //向前分割字符串至每行均处于限宽以内
                            for (int i=0 ; i < DisplayText.Length ; i++)
                            {
                                strTemp = DisplayText.Substring(LengthRecord, i - LengthRecord);
                                if(AimGraphics.MeasureString(strTemp, DisplayFont).Width > LimitWidth)
                                {
                                    strDisplayGroup.Add(strTemp.Substring(0, strTemp.Length - 1));
                                    LengthRecord += strTemp.Length - 1;
                                }
                            }
                            if(LengthRecord != DisplayText.Length)
                            {
                                strDisplayGroup.Add(strTemp);
                            }
                            
                            //将字符串列表添加换行符，再拼接回字符串
                            string strOutput = "";
                            foreach (string line in strDisplayGroup)
                            {
                                strOutput += line + '\n';
                            }
                            //返回换行完成的测算面积
                            SizeF sizeOutput = AimGraphics.MeasureString(strOutput, DisplayFont);
                            sizeDisplay = new Size((int)sizeOutput.Width + 1, (int)sizeOutput.Height + 1);
                            return sizeDisplay;
                        }
                        else
                        {
                            //不需要换行，直接输出
                            sizeDisplay = new Size((int)sizeLongest.Width + 1, (int)sizeLongest.Height + 1);
                            return sizeDisplay;
                        }
                    }
                    else
                    {
                        //不限制宽度，直接返回结果
                        SizeF sizeLongest = AimGraphics.MeasureString(DisplayText, DisplayFont);
                        sizeDisplay = new Size((int)sizeLongest.Width + 1, (int)sizeLongest.Height + 1);
                        return sizeDisplay;
                    }
                    
                }
                else
                {
                    throw new Exception("用于测绘的Graphics对象为null");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            //return sizeDisplay;
        }

        /// <summary>
        /// 测算以指定字体显示某段文字时，需要的区域大小（通过Graphics相关函数）
        /// </summary>
        /// <param name="AimGraphics">用于测算的Grahics对象</param>
        /// <param name="DisplayText">[可返回]显示文字</param>
        /// <param name="DisplayFont">显示字体</param>
        /// <param name="LimitWidth">[可选]限制宽度，若需设置则必须大于0，若设置了限制宽度，则会自动换行</param>
        /// <returns></returns>
        public static Size GetTextDisplayArea(Graphics AimGraphics,ref string DisplayText, Font DisplayFont, int LimitWidth = 0)
        {
            try
            {
                Size sizeDisplay = new Size(0, 0);
                if (AimGraphics != null)
                {
                    AimGraphics.PageUnit = GraphicsUnit.Pixel;
                    //限宽与非限宽区别计算
                    if (LimitWidth > 0)
                    {
                        //宽度限制应当高于最少一个字符的宽度
                        float fMaxSingleWidth = 0;
                        foreach (char chrSingle in DisplayText)
                        {
                            float fSingleWidth = AimGraphics.MeasureString(chrSingle + "", DisplayFont).Width;
                            fMaxSingleWidth = fMaxSingleWidth > fSingleWidth ? fMaxSingleWidth : fSingleWidth;
                        }
                        if (LimitWidth < fMaxSingleWidth)
                        {
                            throw new Exception("宽度限制低于单个字符的宽度");
                        }

                        //首先测算宽度是否高于宽度限制（需要换行）
                        SizeF sizeLongest = AimGraphics.MeasureString(DisplayText, DisplayFont);
                        if (sizeLongest.Width > LimitWidth)
                        {
                            string strTemp = "";
                            List<string> strDisplayGroup = new List<string>();
                            int LengthRecord = 0;
                            //向前分割字符串至每行均处于限宽以内
                            for (int i = 0; i <= DisplayText.Length; i++)
                            {
                                strTemp = DisplayText.Substring(LengthRecord, i - LengthRecord);
                                if (AimGraphics.MeasureString(strTemp, DisplayFont).Width > LimitWidth)
                                {
                                    strDisplayGroup.Add(strTemp.Substring(0, strTemp.Length - 1));
                                    LengthRecord += strTemp.Length - 1;
                                }
                                
                            }
                            if (LengthRecord != 0 && LengthRecord != DisplayText.Length)
                            {
                                strDisplayGroup.Add(strTemp);
                            }

                            //将字符串列表添加换行符，再拼接回字符串
                            string strOutput = "";
                            foreach (string line in strDisplayGroup)
                            {
                                strOutput += line + '\n';
                            }
                            //再次核对检查文字是否出现了意外的去尾情况
                            if(strOutput.Trim().Replace("\n","").Length < DisplayText.Trim().Replace("\n","").Length)
                            {
                                int reqLength = DisplayText.Trim().Replace("\n", "").Length - strOutput.Trim().Replace("\n", "").Length;
                                int StartIndex = strOutput.Trim().Replace("\n", "").Length - (reqLength) - 1;
                                strOutput = strOutput.Substring(0,strOutput.Length -1) + DisplayText.Trim().Replace("\n", "").Substring(StartIndex, reqLength);
                            }

                            //返回换行完成的测算面积
                            SizeF sizeOutput = AimGraphics.MeasureString(strOutput, DisplayFont);
                            sizeDisplay = new Size((int)sizeOutput.Width + 1, (int)sizeOutput.Height);
                            DisplayText = strOutput;
                            return sizeDisplay;
                        }
                        else
                        {
                            //不需要换行，直接输出
                            sizeDisplay = new Size((int)sizeLongest.Width + 1, (int)sizeLongest.Height);
                            return sizeDisplay;
                        }
                    }
                    else
                    {
                        //不限制宽度，直接返回结果
                        SizeF sizeLongest = AimGraphics.MeasureString(DisplayText, DisplayFont);
                        sizeDisplay = new Size((int)sizeLongest.Width + 1, (int)sizeLongest.Height);
                        return sizeDisplay;
                    }

                }
                else
                {
                    throw new Exception("用于测绘的Graphics对象为null");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return sizeDisplay;
        }
    }
}
