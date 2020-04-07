using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAHHnetStore
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
            //Application.Run(new Form1());

            //禁止窗口多开
            System.Threading.Mutex instance = new System.Threading.Mutex(true, "MutexName", out bool createNew);
            if (createNew)
            {
                Application.Run(new Form1());
                instance.ReleaseMutex();
            }
            else
            {
                Application.Exit();
                MessageBox.Show("发料程序已运行！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
