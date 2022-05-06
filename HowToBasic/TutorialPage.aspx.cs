using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HowToBasic
{
    public partial class TutorialPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tutorialContents.Text = Request.Unvalidated.QueryString["q"];
        }
    }
}