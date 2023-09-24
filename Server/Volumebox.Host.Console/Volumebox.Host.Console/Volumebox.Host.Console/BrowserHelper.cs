using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Volumebox.Host.Console
{
    internal class BrowserHelper
    {
        [DllImport("user32.dll")]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public void PrintBrowserTabName()
        {
            var browsersList = new List<string>
            {
                "chrome",
                "firefox",
                "iexplore",
                "safari",
                "opera",
                "edge"
            };

            foreach (var singleBrowser in browsersList)
            {
                var process = Process.GetProcessesByName(singleBrowser);
                if (process.Length > 0)
                {
                    foreach (Process singleProcess in process)
                    {
                        IntPtr hWnd = singleProcess.MainWindowHandle;
                        int length = GetWindowTextLength(hWnd);

                        StringBuilder text = new StringBuilder(length + 1);
                        GetWindowText(hWnd, text, text.Capacity);
                        var title = text.ToString();
                        if (!String.IsNullOrEmpty(title))
                            System.Console.WriteLine(text.ToString());
                    }
                }
            }
        }
    }
}
