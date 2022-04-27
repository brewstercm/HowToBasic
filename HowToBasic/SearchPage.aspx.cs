using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HowToBasic
{
    public partial class SearchPage : System.Web.UI.Page
    {
        static string redirect = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string keywords = Request.QueryString["keywords"];
                //sql statement: Select * From Tutorials Where name = keywords
                //display the thumbnails of these tutorials
                BindCategoryDDL(keywords);
            }
        }

        private void BindCategoryDDL(string keywords)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TutorialThumbnail, TutorialLink FROM Tutorials T INNER JOIN Categories C ON C.CategoryID = T.CategoryID  WHERE C.CategoryName = '" + keywords + "'";

                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                StringBuilder sb = new StringBuilder();

                if (sdr.Read()) {
                    sb.Append("<div class = col-lg-3>");
                    sb.Append("<img src='/Content/Catalog/");
                    sb.Append(sdr["TutorialThumbnail"].ToString()); //either
                    sb.Append("'>");
                    sb.Append("</div>");


                    searchedTutorial.ImageUrl = sdr["TutorialThumbnail"].ToString(); //or
                    redirect = sdr["TutorialLink"].ToString();
                }
                

                
            }
        }

        protected void searchedTutorial_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(redirect);
        }
    }
}