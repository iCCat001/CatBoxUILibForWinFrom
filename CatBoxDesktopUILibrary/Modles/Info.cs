using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CatBoxDesktopUILibrary.Modles
{
    public class Info
    {
        public static string UIVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}
