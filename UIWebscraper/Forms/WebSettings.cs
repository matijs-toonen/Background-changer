using System;
using System.Drawing;
using System.Windows.Forms;
using HtmlAgilityPack;
using Webscraper.Core.Workflow;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace UIWebscraper.Forms
{
    public partial class WebSettings : Form
    {
        public WebSettings()
        {
            InitializeComponent();
        }

        private void btnGetHtml_Click(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(txtUrl.Text, UriKind.RelativeOrAbsolute))
            {
                var document = Scraper.GetHtmlDocument(txtUrl.Text);
            }
        }
    }
}
