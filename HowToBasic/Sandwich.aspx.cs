using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HowToBasic
{
    public partial class Sandwich : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCategoryDDL();
            }
        }

        private void BindCategoryDDL()
        {
            //using (SqlConnection conn = new SqlConnection())
            //{
            //    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "SELECT * From Tutorials WHERE TutorialTitle LIKE '%Sandwich%'";

            //    cmd.Connection = conn;
            //    conn.Open();

            //    SqlDataReader sdr = cmd.ExecuteReader();

            //    if (sdr.Read())
            //    {
            //        sandwichImg.ImageUrl = sdr["TutorialThumbnail"].ToString();
            //        //display the actual tutorial here from the data base
            //        //sdr["TutorialSteps"].ToString();
            //    }
                
            //}
        }
    }
}