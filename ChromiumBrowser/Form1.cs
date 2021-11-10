using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Example.Handlers;
using CefSharp.WinForms;
using ChromiumBrowser;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }

        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            var config = new IniFile("config.ini");
            if (!config.KeyExists("homepage"))
            {
                config.Write("homepage", "http://www.google.com");
            }
            var homepage = config.Read("homepage");
            chromeBrowser = new ChromiumWebBrowser(homepage);
            chromeBrowser.DownloadHandler = new DownloadHandler();
            this.panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chromeBrowser.Reload();
        }

        private void devToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.chromeBrowser.ShowDevTools();
        }

        private void globalWindowKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("globalWindowKeyDown");
        }

        private void globalWindowKeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("globalWindowKeyPress");
        }

        private void globalWindowKeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show("globalWindowKeyUp");
        }
    }
}
