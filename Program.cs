using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace owplan
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //获取所有的进程
            Process[] processes = Process.GetProcessesByName("MicrosoftNetWork");
            if (processes.Length > 1)
            {
                foreach (Process process in Process.GetProcesses())
                {
                    int handle = FindWindow(null, "dasfrf2reeqwwqewqewqvxxcvcsvdsas");
                    SendMessage(handle, 0x0401, 0, 0);
                }
                return;
            }
            Application.Run(new MainForm());
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(String lpClassName, String lpWindowName);
    }
}