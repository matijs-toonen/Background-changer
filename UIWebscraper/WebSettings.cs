using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Webscraper.Workflow;

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
