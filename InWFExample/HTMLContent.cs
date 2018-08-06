using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InWFExample
{
    public partial class HTMLContent : Form
    {
        public HTMLContent()
        {
            InitializeComponent();
        }

        private void ShowOfflineContent(string offlineUrl)
        {
            String sitePath = null;
            try
            {
                sitePath = Application.StartupPath + @"\OfflineDocs\" + offlineUrl;
                webBrowserHTMLContent.Navigate(sitePath);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString() + "\nSite Path: " + sitePath);
            }
        }

        public void Navigate(string url)
        {
            ShowOfflineContent("Navigating.htm");
            webBrowserHTMLContent.Navigate(url);
        }

        public string GetHTML()
        {
            return webBrowserHTMLContent.DocumentText;
        }
    }
}
