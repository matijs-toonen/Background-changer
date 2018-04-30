using System;
using System.Windows.Forms;
using Webscraper.Core.Workflow;

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
                var document = Scraper.GetAllImages(txtUrl.Text);
                foreach (var node in document.DocumentNode.ChildNodes)
                {
                    treeView.Nodes.Add(node.Name);
                }
            }
        }
    }
}
