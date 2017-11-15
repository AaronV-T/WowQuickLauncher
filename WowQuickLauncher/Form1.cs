using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowQuickLauncher
{
    public partial class Form1 : Form
    {
        // Version
        string versionNum = "1.0a";

        // Windows API Stuff
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SetForegroundWindow(IntPtr hwnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        public struct RECT
        {
            public int left;        // x position of upper-left corner
            public int top;         // y position of upper-left corner
            public int right;       // x position of lower-right corner
            public int bottom;      // y position of lower-right corner
        }
        // End Windows API Stuff

        List<System.Diagnostics.Process> processes;

        public Form1()
        {
            InitializeComponent();
            Text = $"WoW Quick Launcher v{versionNum}";
            chbxCloseProgramOnLaunch.Checked = true;
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                processes = new List<System.Diagnostics.Process>();
                string launchPath;
                int loginWait;
                bool enterWorld;
                int enterWorldWait;
                List<AccountInfo> accounts = FileIO.GetAccountInfo(out launchPath, out enterWorld, out loginWait, out enterWorldWait);

                if (launchPath == string.Empty)
                    throw new System.IO.IOException("Path was not defined in \"accounts.txt\".");

                // Launch a process for each account.
                for (int i = 0; i < accounts.Count; i++)
                {
                    processes.Add(System.Diagnostics.Process.Start(launchPath));
                    System.Threading.Thread.Sleep(250);
                }

                System.Threading.Thread.Sleep(loginWait);

                // Log in to each account.
                for (int i = 0; i < accounts.Count; i++)
                {
                    // Move/resize window.
                    if (accounts[i].width > 0 && accounts[i].height > 0)
                        MoveWindow(processes[i].MainWindowHandle, accounts[i].x, accounts[i].y, accounts[i].width, accounts[i].height, true);

                    SetForegroundWindow(processes[i].MainWindowHandle);
                    System.Threading.Thread.Sleep(50);

                    // Enter username and password and login.
                    SendKeys.Send(accounts[i].username);
                    SendKeys.Send("{TAB}");
                    SendKeys.Send(accounts[i].password);
                    SendKeys.Send("{ENTER}");

                    System.Threading.Thread.Sleep(250);
                }

                // Enter World
                if (enterWorld)
                {
                    System.Threading.Thread.Sleep(enterWorldWait);

                    for (int i = 0; i < accounts.Count; i++)
                    {
                        SetForegroundWindow(processes[i].MainWindowHandle);

                        SendKeys.Send("{ENTER}");
                    }

                    SetForegroundWindow(processes[0].MainWindowHandle);
                }

                if (chbxCloseProgramOnLaunch.Checked)
                    Application.Exit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnGetWindowPositions_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < processes.Count; i++)
            {
                RECT r;
                GetWindowRect(processes[i].MainWindowHandle, out r);
                Console.WriteLine($"{r.left}, {r.top}, {r.right - r.left}, {r.bottom - r.top}");
            }
        }
    }
}
