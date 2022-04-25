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
    public partial class Tutorials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {https://localhost:44316/Tutorials.aspx.cs
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Categories";
                cmd.Connection = conn;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                conn.Open();
                sda.Fill(dt);
                ddlCategories.DataSource = dt;
                ddlCategories.DataTextField = dt.Columns["CategoryName"].ToString();
                ddlCategories.DataValueField = dt.Columns["CategoryID"].ToString();
                ddlCategories.DataBind();
            }
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Type";
                cmd.Connection = conn;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                conn.Open();
                sda.Fill(dt);
                ddlType.DataSource = dt;
                ddlType.DataTextField = dt.Columns["TypeName"].ToString();
                ddlType.DataValueField = dt.Columns["TypeID"].ToString();
                ddlType.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO Tutorials (CategoryID, DateCreated, TypeID, TutorialTitle, TutorialLink) VALUES ('" + ddlCategories.SelectedValue + "', '" + DateTime.Now + "','" + ddlType.SelectedValue + "', '" + txtTitle.Text + "','" + txtTutorialLink.Text +"');";
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                }
                lblFeedback.Visible = true;
                lblFeedback.Text = "The tutorial was added successfully.";
            }
            
        }
    }
}