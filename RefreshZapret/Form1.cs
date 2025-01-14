using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ServiceProcess;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace RefreshZapret
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            InitTrayIconP();
            InitializeComponent();

        }

        private void InitTrayIconP()
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.lovedsgn;
            notifyIcon.Visible = true;

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            ToolStripMenuItem toolStripMenuItemStop = new ToolStripMenuItem("stop Zapret");
            ToolStripMenuItem toolStripMenuItemStart = new ToolStripMenuItem("start Zapret");
            toolStripMenuItemStop.Click += new EventHandler(RestartOtherApp_ClickStop);
            toolStripMenuItemStart.Click += new EventHandler(RestartOtherApp_ClickStart);

            contextMenuStrip.Items.Add(toolStripMenuItemStop);
            contextMenuStrip.Items.Add(toolStripMenuItemStart);


        }

        private void RestartOtherApp_ClickStop(object sender, EventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("winws"))
                {
                    proc.Kill();
                    proc.WaitForExit();
                    

                }
                MessageBox.Show("process stop");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void RestartOtherApp_ClickStart(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Users\User\Downloads\zapret-discord-youtube-main\bin\winws.exe");
                MessageBox.Show("process start");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
