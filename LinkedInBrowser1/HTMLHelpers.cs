using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// http://codecaster.nl/blog/2015/11/webclient-httpwebrequest-httpclient-perform-web-requests-net/

// Reference: http://www.c-sharpcorner.com/UploadFile/9b86d4/getting-started-with-html-agility-pack/

namespace HTMLHelpers
{
    public class LinkedInTopic 
    {
        public int ID;
        public string UrlParentPage;
        public string UrlDetailPage;
        public string Title;
        public bool Visited;

        public LinkedInTopic(int id, string urlParentPage, string urlDetailPage, string title)
        {
            this.ID = id;
            this.UrlParentPage = urlParentPage;
            this.UrlDetailPage = urlDetailPage;
            this.Title = title;
            this.Visited = false;
        }
    }

    public static class LinkedInHTMLHelpers
    {
        static int ID = 0;

        public static void GetHTMLPage(string urlHTMLPage, Dictionary<string, LinkedInTopic> topics, Dictionary<string, LinkedInTopic> indextopics)
        {
            string webPageHTML = string.Empty;

            //string html = "";
            //Console.WriteLine(url);

            //using (WebClient client = new WebClient())
            //{
            //    webPageHTML = client.DownloadString(url);
            //}

            //using (var client = new HttpClient())
            //{
            //    client.Timeout = new TimeSpan(0, 2, 0); // 2 minutes.  Default is 100 seconds

            //    bool success = false;
            //    int iTimes = 0;
            //    while (!success)
            //    {
            //        try
            //        {
            //            var result = client.GetAsync(urlHTMLPage).Result;
            //            if (result.StatusCode != HttpStatusCode.OK) Console.WriteLine(result.StatusCode.ToString());
            //            result.EnsureSuccessStatusCode();
            //            webPageHTML = result.Content.ReadAsStringAsync().Result;
            //            success = true;
            //        }
            //        catch(Exception ex)
            //        {
            //            success = false;
            //            Console.WriteLine(ex.ToString());
            //            iTimes++;
            //            Console.WriteLine("Sleeping.exception... " + iTimes.ToString());
            //            Thread.Sleep(10 * 1000);
            //        }
            //    }
            //}

            webPageHTML = File.ReadAllText(urlHTMLPage);

            if (!String.IsNullOrEmpty(webPageHTML))
            {
                ParseHTMLPage(urlHTMLPage, webPageHTML, topics, indextopics);
            }
            else
            {
                Debug.WriteLine("GetHTMLPage: no HTML was returned");
            }
        }

        public static void DeleteCSV(string csvFilename)
        {
            File.Delete(csvFilename);
        }

        public static void OutputCSV(string csvFilename, Dictionary<string, LinkedInTopic> topics)
        {
            using (System.IO.StreamWriter csvFile = new System.IO.StreamWriter(csvFilename, false))
            {
                string row = "";
                foreach (var topic in topics)
                {
                    row = "\"" + topic.Value.ID.ToString() + "\"" + ",\"" + topic.Value.UrlParentPage + "\"" + ",\"" + topic.Value.UrlDetailPage + "\"" + ",\"" + topic.Value.Title + "\"";
                    csvFile.WriteLine(row);
                }
            }
        }

        public static void ParseHTMLPage(string urlHTMLPage, string webPageHTML, Dictionary<string, LinkedInTopic> topics, Dictionary<string, LinkedInTopic> indextopics)
        {
            if (webPageHTML.Length < 1000) Debug.WriteLine(webPageHTML.Length.ToString() + "\t'" + webPageHTML + "'");

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(webPageHTML);
            var elementsTopic =
                from element in htmlDoc.DocumentNode.Descendants("a")
                where (
                       (element.Attributes["href"] != null && element.Attributes["href"].Value != null) &&
                       (element.Attributes["href"].Value.Contains("topics-") || element.Attributes["href"].Value.Contains("/topic/"))
                      ) &&
                      (
                        (element.Attributes["title"] != null && element.Attributes["title"].Value != null && !element.Attributes["title"].Value.Contains("starting"))
                      )
                select element;
            Debug.WriteLine("elementsTopic.Count: " + elementsTopic.Count());
            foreach (var attendeeTopic in elementsTopic)
            {
                string urlDetailPage = attendeeTopic.Attributes["href"].Value;
                string title = attendeeTopic.Attributes["title"].Value;
                if (title.Contains(" - "))
                {
                    Debug.WriteLine(ID.ToString() + " " + title + " is an indextopic");
                    LinkedInTopic indextopic = new LinkedInTopic(ID, urlHTMLPage, urlDetailPage, title);
                    if (!indextopics.Keys.Contains(urlDetailPage))
                    {
                        indextopics.Add(urlDetailPage, indextopic);
                    }
                }
                else
                {
                    Debug.WriteLine(ID.ToString() + " " + title + " is a topic");
                    LinkedInTopic topic = new LinkedInTopic(ID, urlHTMLPage, urlDetailPage, title);
                    if (!topics.Keys.Contains(urlDetailPage))
                    {
                        topics.Add(urlDetailPage, topic);
                    }
                }
                ID++;
            }
        }
    }
}
