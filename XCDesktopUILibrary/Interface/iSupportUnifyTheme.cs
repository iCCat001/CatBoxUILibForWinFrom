using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatBoxDesktopUILibrary.Interface
{
    /// <summary>
    /// 接口：支持并响应Modles.ColorTheme色彩主题的变化
    /// </summary>
    public interface iSupportUnifyTheme
    {
        /// <summary>
        /// CatBoxDesktopUILibrary：响应主题色彩变化
        /// </summary>
        public void OnThemeChanged();

        /// <summary>
        /// CatBoxDesktopUILibrary：响应统一的动画配置开关指令
        /// </summary>
        /// <param name="AnimationSwitch">动画配置开关</param>
        public void OnAnimationSwitchChanged(bool AnimationSwitch);
    }
}
