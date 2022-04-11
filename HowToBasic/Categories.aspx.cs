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
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCategoryList();
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //1. Create a SqlConnection object
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;

                //2. Create a SqlCommand object
                SqlCommand cmd = new SqlCommand();

                /// TODO:
                /// We need to change the dynamic SQL statement later to avoid sql-injection attacks
                cmd.CommandText = "INSERT INTO Categories VALUES ('" + txtCategoryName.Text + "')";
                cmd.Connection = conn; //link the command to the connection object

                //3. Open the connection
                conn.Open();

                //4. Execute the command
                cmd.ExecuteNonQuery(); //this will insert data into the database

                //5. Close the connection
                conn.Close();

                lblFeedback.Visible = true;
                lblFeedback.Text = "The category <strong>" + txtCategoryName.Text + "</strong> was added successfully.";

                BindCategoryList();
            }
        }

        protected void BindCategoryList()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Categories";
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            conn.Open();

            sda.Fill(dt);

            gvCategoryList.DataSource = dt;
            gvCategoryList.DataBind();
            conn.Close();
        }

        protected void gvCategoryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Button editButton = e.Row.FindControl("btnEdit") as Button;
                Button deleteButton = e.Row.FindControl("btnDelete") as Button;

                editButton.CommandArgument = e.Row.Cells[0].Text;
                deleteButton.CommandArgument = e.Row.Cells[0].Text;
            }
        }

        protected void gvCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "EditCategory")//The edit button was clicked
            {
                int categoryId = int.Parse(e.CommandArgument.ToString());

                EditCategoryById(categoryId);
                lblCategoryId.Text = e.CommandArgument.ToString();

            }
            else if (e.CommandName == "DeleteCategory")//The delete button was clicked
            {
                int categoryId = int.Parse(e.CommandArgument.ToString());

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "DELETE FROM Categories WHERE CategoryID = " + categoryId;
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    BindCategoryList();
                }
                    
            }
        }

        private void EditCategoryById(int categoryId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Categories WHERE CategoryID = " + categoryId;
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    txtCategoryName.Text = sdr["CategoryName"].ToString();
                }

                btnAddCategory.Visible = false;
                btnSaveCategory.Visible = true;
                btnCancel.Visible = true;
                pnlCategoryList.Visible = false;
                lblFeedback.Visible = false;
            }
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddCategory.Visible = true;
            btnSaveCategory.Visible = false;
            btnCancel.Visible=false;
            pnlCategoryList.Visible = true;
            txtCategoryName.Text = "";
        }

        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(lblCategoryId.Text);

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                ///TODO 
                ///we need to change the following statement to avoid
                ///sql injection attacks
                cmd.CommandText = "UPDATE Categories SET CategoryName='" + txtCategoryName.Text + "' WHERE CategoryID = " + categoryId;
                cmd.Connection = conn;
                conn.Open();

                cmd.ExecuteNonQuery();

                BindCategoryList();

                btnAddCategory.Visible = true;
                btnSaveCategory.Visible = false;
                btnCancel.Visible = false;
                pnlCategoryList.Visible = true;
                txtCategoryName.Text = "";
            }
                
        }
    }
}