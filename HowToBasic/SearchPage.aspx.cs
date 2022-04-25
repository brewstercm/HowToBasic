using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HowToBasic
{
    public partial class SearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string keywords = Request.QueryString("keywords");
                //sql statement: Select * From Tutorials Where name = keywords
                //display the thumbnails of these tutorials
            }
        }
    }
}