using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HowToBasic
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                LinkButton1.Text = "SIGN OUT";
                LinkButton1.PostBackUrl = "~/SignOut.aspx";
            }
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SearchPage.aspx?keywords=" + txtSearch.Text);
        }
    }
}