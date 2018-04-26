using System;
using System.Windows.Forms;
using Webscraper.Core.Workflow;

namespace UIWebscraper
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
                var document = Scraper.GetAllImages(txtUrl.Text);

            }
        }
    }
}
