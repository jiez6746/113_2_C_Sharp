using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Structure_Argument
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// 此方法會初始化應用程式的視覺樣式，設定文字渲染方式，
        /// 並啟動主視窗（Form1）。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 啟用應用程式的視覺樣式，使表單和控制項呈現現代化外觀
            Application.EnableVisualStyles();
            // 設定應用程式使用預設的文字渲染方式，以確保文字顯示效果一致
            Application.SetCompatibleTextRenderingDefault(false);
            // 執行主表單（Form1），開始應用程式的事件迴圈
            Application.Run(new Form1());
        }
    }
}
