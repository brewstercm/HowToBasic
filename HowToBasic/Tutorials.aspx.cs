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
            if (!Page.IsPostBack)
            {
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
                bindTutorialList();
            }
        }

        protected void btnAddTutorial_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "addTutorial";
                    cmd.Parameters.AddWithValue("@categoryID", ddlCategories.SelectedValue);
                    cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@typeID", ddlType.SelectedValue);
                    cmd.Parameters.AddWithValue("@tutorialTitle", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@tutorialLink", txtTutorialLink.Text.Trim());
                    cmd.Parameters.AddWithValue("@tutorialThumbnail", txtTutorialThumbnail.Text.Trim());
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                lblFeedback.Visible = true;
                lblFeedback.Text = "The tutorial was added successfully.";
                bindTutorialList();
            }
            
        }

        protected void bindTutorialList()
        {
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Tutorials";
                cmd.Connection = conn;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                DataTable dt = new DataTable();
                sda.Fill(dt);

                gvTutorialList.DataSource = dt;
                gvTutorialList.DataBind();
            }
        }

        protected void gvTutorialList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Button editButton = e.Row.FindControl("btnEdit") as Button;
                Button deleteButton = e.Row.FindControl("btnDelete") as Button;

                editButton.CommandArgument = e.Row.Cells[0].Text;
                deleteButton.CommandArgument = e.Row.Cells[0].Text;
            }

        }

        protected void gvTutorialList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTutorial")//The edit button was clicked
            {
                int tutorialId = int.Parse(e.CommandArgument.ToString());

                EditTutorialById(tutorialId);
                lblTutorialId.Text = e.CommandArgument.ToString();

            }
            else if (e.CommandName == "DeleteTutorial")//The delete button was clicked
            {
                int tutorialId = int.Parse(e.CommandArgument.ToString());

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "DELETE FROM Tutorials WHERE TutorialID = " + tutorialId;
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    bindTutorialList();
                }

            }
        }
        private void EditTutorialById(int tutorialId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Tutorials WHERE TutorialID = " + tutorialId;
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    txtTitle.Text = sdr["TutorialTitle"].ToString();
                    txtTutorialLink.Text = sdr["TutorialLink"].ToString();
                    txtTutorialThumbnail.Text = sdr["TutorialThumbnail"].ToString();
                }

                btnAddTutorial.Visible = false;
                btnSaveTutorial.Visible = true;
                btnCancel.Visible = true;
                pnlEditTutorials.Visible = false;
                lblFeedback.Visible = false;
            }
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddTutorial.Visible = true;
            btnSaveTutorial.Visible = false;
            btnCancel.Visible = false;
            pnlEditTutorials.Visible = true;
            txtTitle.Text = "";
            txtTutorialLink.Text = "";
            txtTutorialThumbnail.Text = "";
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
            bindTutorialList();
        }
        protected void btnSaveTutorial_Click(object sender, EventArgs e)
        {
            int tutorialId = int.Parse(lblTutorialId.Text);

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateTutorial";
                cmd.Parameters.AddWithValue("@TutorialID", tutorialId);
                cmd.Parameters.AddWithValue("@CategoryID", ddlCategories.SelectedValue);
                cmd.Parameters.AddWithValue("@TypeID", ddlType.SelectedValue);
                cmd.Parameters.AddWithValue("@TutorialTitle", txtTitle.Text);
                cmd.Parameters.AddWithValue("@TutorialLink", txtTutorialLink.Text);
                cmd.Parameters.AddWithValue("@TutorialThumbnail", txtTutorialThumbnail.Text);
                cmd.Connection = conn;
                conn.Open();

                cmd.ExecuteNonQuery();

                bindTutorialList();

                btnAddTutorial.Visible = true;
                btnSaveTutorial.Visible = false;
                btnCancel.Visible = false;
                pnlEditTutorials.Visible = true;
                txtTutorialThumbnail.Text = "";
                txtTitle.Text = "";
                txtTutorialLink.Text = "";
            }

        }
    }
}