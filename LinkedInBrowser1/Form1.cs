using HTMLHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedInBrowser1
{
    public partial class MainForm : Form
    {
        enum DownloadOperation
        {
            DownloadOne,
            DownloadAll,
            NoOp
        }

        const string TopicsFilename = "topics.csv";
        const string IndextopicsFilename = "indextopics.csv";

        static string LastUrl = "";
        static DownloadOperation LastDownloadOperation = DownloadOperation.NoOp;
        Dictionary<string, LinkedInTopic> Topics = null;
        Dictionary<string, LinkedInTopic> Indextopics = null;

        public MainForm()
        {
            InitializeComponent();
            txtCurrentUrl.Size = txtAddress.Size;
        }

        private void ShowOfflineContent(string offlineUrl)
        {
            String sitePath = null;
            try
            {
                sitePath = Application.StartupPath + @"\OfflineDocs\" + offlineUrl;
                webB.Navigate(sitePath);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString() + "\nSite Path: " + sitePath);
            }
        }

        public void NavigateToPage(string url)
        {
            ShowOfflineContent("Loading.htm");
            txtAddress.Text = url;
            webB.Navigate(url);
        }

        private void webB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("webB_DocumentCompleted:\t" + e.Url + " '" + webB.Url + "'");
            if (e.Url.Scheme.StartsWith("http") && e.Url == webB.Url)
            {
                txtCurrentUrl.Text = e.Url.ToString();
                switch (LastDownloadOperation)
                {
                    case DownloadOperation.NoOp:
                        {
                            break;
                        }
                    case DownloadOperation.DownloadAll:
                    case DownloadOperation.DownloadOne:
                        {
                            string html = webB.DocumentText;
                            System.Diagnostics.Debug.WriteLine("webB_DocumentCompleted: parse 1 page:\t" + e.Url + " '" + webB.Url + "'");
                            //MessageBox.Show(html.Substring(0, 1000), "HTML");

                            HTMLHelpers.LinkedInHTMLHelpers.ParseHTMLPage(txtAddress.Text, html, Topics, Indextopics);

                            int indextopicsVisited = 0;
                            bool foundNotVisited = false;
                            foreach( var indextopic in Indextopics)
                            {
                                if (indextopic.Value.Visited)
                                {
                                    indextopicsVisited++;
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("webB_DocumentCompleted: indextopic:\t" + indextopic.Value.Title + " " + indextopic.Value.UrlDetailPage);

                                    foundNotVisited = true;
                                    indextopic.Value.Visited = true;
                                    NavigateToPage(indextopic.Value.UrlDetailPage);
                                    break;
                                }
                            }

                            txtStatus.Text = "Topics: " + Topics.Count() + "    Index Topics: " + Indextopics.Count() + "    Index Topics Visited: " + indextopicsVisited.ToString();

                            if (!foundNotVisited)
                            {
                                HTMLHelpers.LinkedInHTMLHelpers.OutputCSV(TopicsFilename, Topics);
                                HTMLHelpers.LinkedInHTMLHelpers.OutputCSV(IndextopicsFilename, Indextopics);
                            }

                            break;
                        }
                }
            }
        }

        private void webB_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("webB_Navigated:\t" + e.Url + " '" + webB.Url + "'");
        }

        private void webB_FileDownload(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("webB_FileDownload:\t" + e.ToString() + " '" + webB.Url + "'");
        }

        private void webB_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("webB_ProgressChanged:\t" + e.CurrentProgress.ToString() + " of " + e.MaximumProgress.ToString() + " '" + webB.Url + "'");
        }

        private void webB_LocationChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("webB_LocationChanged:\t" + e.ToString() + " '" + webB.Url + "'");
        }

        private void webB_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("webB_Navigating:\t" + e.Url + " '" + webB.Url + "'");
        }

        static int nextPageIndex = 0;
        public static string urlRootIndexTopicPage = "https://www.linkedin.com/directory/topics/";
        public static string[] urlIndexTopicPages = new string[]
        {
            "https://www.linkedin.com/directory/topics-more/",
            "https://www.linkedin.com/directory/topics-a/",
            "https://www.linkedin.com/directory/topics-b/",
            "https://www.linkedin.com/directory/topics-c/",
            "https://www.linkedin.com/directory/topics-d/",
            "https://www.linkedin.com/directory/topics-e/",
            "https://www.linkedin.com/directory/topics-f/",
            "https://www.linkedin.com/directory/topics-g/",
            "https://www.linkedin.com/directory/topics-h/",
            "https://www.linkedin.com/directory/topics-i/",
            "https://www.linkedin.com/directory/topics-j/",
            "https://www.linkedin.com/directory/topics-k/",
            "https://www.linkedin.com/directory/topics-l/",
            "https://www.linkedin.com/directory/topics-m/",
            "https://www.linkedin.com/directory/topics-n/",
            "https://www.linkedin.com/directory/topics-o/",
            "https://www.linkedin.com/directory/topics-p/",
            "https://www.linkedin.com/directory/topics-q/",
            "https://www.linkedin.com/directory/topics-r/",
            "https://www.linkedin.com/directory/topics-s/",
            "https://www.linkedin.com/directory/topics-t/",
            "https://www.linkedin.com/directory/topics-u/",
            "https://www.linkedin.com/directory/topics-v/",
            "https://www.linkedin.com/directory/topics-w/",
            "https://www.linkedin.com/directory/topics-x/",
            "https://www.linkedin.com/directory/topics-y/",
            "https://www.linkedin.com/directory/topics-z/"
        };

        private void btnDownloadAll_Click(object sender, EventArgs e)
        {
            LastDownloadOperation = DownloadOperation.DownloadAll;
            HTMLHelpers.LinkedInHTMLHelpers.DeleteCSV(TopicsFilename);
            HTMLHelpers.LinkedInHTMLHelpers.DeleteCSV(IndextopicsFilename);
            Topics = new Dictionary<string, LinkedInTopic>();
            Indextopics = new Dictionary<string, LinkedInTopic>();

            foreach (var urlIndexTopicPage in urlIndexTopicPages)
            {
                string title = urlIndexTopicPage.Substring(urlIndexTopicPage.LastIndexOf("/topic"));

                LinkedInTopic indextopic = new LinkedInTopic(-1, urlRootIndexTopicPage, urlIndexTopicPage, title);
                if (!Indextopics.Keys.Contains(urlIndexTopicPage))
                {
                    Indextopics.Add(urlIndexTopicPage, indextopic);
                }
                //break; // DEBUG
            }

            LinkedInTopic indextopicFirst = Indextopics.First().Value;
            indextopicFirst.Visited = true;
            NavigateToPage(indextopicFirst.UrlDetailPage);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            LastUrl = txtAddress.Lines[0];
            NavigateToPage(LastUrl);
        }

        private void btnDownloadOne_Click(object sender, EventArgs e)
        {
            LastDownloadOperation = DownloadOperation.DownloadOne;
            HTMLHelpers.LinkedInHTMLHelpers.DeleteCSV(TopicsFilename);
            HTMLHelpers.LinkedInHTMLHelpers.DeleteCSV(IndextopicsFilename);
            Topics = new Dictionary<string, LinkedInTopic>();
            Indextopics = new Dictionary<string, LinkedInTopic>();

            string urlIndexTopicPage = urlIndexTopicPages[1];
            string title = urlIndexTopicPage.Substring(urlIndexTopicPage.LastIndexOf("/topic"));

            LinkedInTopic indextopic = new LinkedInTopic(-1, urlRootIndexTopicPage, urlIndexTopicPage, title);
            if (!Indextopics.Keys.Contains(urlIndexTopicPage))
            {
                Indextopics.Add(urlIndexTopicPage, indextopic);
            }

            indextopic.Visited = true;
            NavigateToPage(urlIndexTopicPage);
        }

        private void btnLoading_Click(object sender, EventArgs e)
        {
            ShowOfflineContent("Loading.htm");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("btnSave_Click:\t" + e.ToString() + " '" + webB.Url + "'");
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            txtCurrentUrl.Size = txtAddress.Size;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            txtCurrentUrl.Size = txtAddress.Size;
        }
    }
}
