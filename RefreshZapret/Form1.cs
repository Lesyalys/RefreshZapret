using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ServiceProcess;
using System.Linq;
using System.Windows.Forms;

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

            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Refresh Zapret");
            toolStripMenuItem.Click += new EventHandler(RestartOtherApp_Click);

            contextMenuStrip.Items.Add(toolStripMenuItem);


        }

        private void RestartOtherApp_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("winws"))
                {
                    proc.Kill();
                    proc.WaitForExit();
                    

                }
                Process.Start(@"C:\Users\User\Downloads\zapret-discord-youtube-main\bin\winws.exe");
                MessageBox.Show("process restart");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
