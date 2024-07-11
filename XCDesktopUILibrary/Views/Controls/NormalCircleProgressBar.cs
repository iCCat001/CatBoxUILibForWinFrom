using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CatBoxDesktopUILibrary.Views.Controls
{
    public partial class NormalCircleProgressBar : UserControl
    {
        private int StepFrame = 10;//单次动作最高帧
        private int SelayTime = 500;//单次动作时间延迟，设计帧率 = 1000 /（延迟 / 设计帧）
        Queue<int> queueDraw = new Queue<int>();
        private int progress;
        public int Progress
        {
            get
            {
                return progress;
            }
            set
            {
                if(value > progress)
                {
                    //Thread thdDraw = new Thread(new ParameterizedThreadStart(DrawProcess));
                    //thdDraw.Start(new int[] { progress, value });
                    PushFrame(Progress, value);
                    progress = value;
                }
            }
        }

        public NormalCircleProgressBar()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public void PushFrame(int StartValue, int EndValue)
        {
            if(EndValue - StartValue < StepFrame)
            {
                //实际步数小于设计帧,则按1每帧平展，至尽量多帧数于绘制线程队列
                
            }
            else
            {
                //实际绘制帧数要求（1/帧）高于设计帧，则以适当整数平展至绘制线程队列
            }
        }

        /// <summary>
        /// 循环绘制线程，对循环队列进行统计，以尽量平滑变化率进行固定帧数固定时间间隔进行绘制
        /// </summary>
        public void DrawCricle()
        {
            //固定帧数
            for(int i = 0; i < StepFrame;i++)
            {

            }
        }
    }
}
