using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace HowToBasic
{
    public partial class _Default : Page
    {
        public String tutorialContent;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Tutorials WHERE TutorialThumbnail=@thumbnail";
                cmd.Parameters.AddWithValue("@thumbnail", "/Content/Catalog/prog.jpg");
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    tutorialContent = sdr["TutorialLink"].ToString();
                }
            }
            Response.Redirect("TutorialPage.aspx?q=" + tutorialContent);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Tutorials WHERE TutorialThumbnail=@thumbnail";
                cmd.Parameters.AddWithValue("@thumbnail", "/Content/Catalog/Sandwich.png");
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    tutorialContent = sdr["TutorialLink"].ToString();
                }
            }
            Response.Redirect("TutorialPage.aspx?q=" + tutorialContent);
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Tutorials WHERE TutorialThumbnail=@thumbnail";
                cmd.Parameters.AddWithValue("@thumbnail", "/Content/Catalog/Archery.png");
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    tutorialContent = sdr["TutorialLink"].ToString();
                }
            }
            Response.Redirect("TutorialPage.aspx?q=" + tutorialContent);
        }
    }
}