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
    public partial class Type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindTypeList();
            }
        }

        protected void btnAddType_Click(object sender, EventArgs e)
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
                cmd.CommandText = "INSERT INTO Type VALUES ('" + txtTypeName.Text + "')";
                cmd.Connection = conn; //link the command to the connection object

                //3. Open the connection
                conn.Open();

                //4. Execute the command
                cmd.ExecuteNonQuery(); //this will insert data into the database

                //5. Close the connection
                conn.Close();

                lblFeedback.Visible = true;
                lblFeedback.Text = "The type <strong>" + txtTypeName.Text + "</strong> was added successfully.";

                BindTypeList();
            }
        }

        protected void BindTypeList()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Type";
            cmd.Connection = conn;

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            conn.Open();

            sda.Fill(dt);

            gvTypeList.DataSource = dt;
            gvTypeList.DataBind();
            conn.Close();
        }

        protected void gvTypeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button editButton = e.Row.FindControl("btnEdit") as Button;
                Button deleteButton = e.Row.FindControl("btnDelete") as Button;

                editButton.CommandArgument = e.Row.Cells[0].Text;
                deleteButton.CommandArgument = e.Row.Cells[0].Text;
            }
        }

        protected void gvTypeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditType")//The edit button was clicked
            {
                int typeId = int.Parse(e.CommandArgument.ToString());

                EditTypeById(typeId);
                lblTypeId.Text = e.CommandArgument.ToString();

            }
            else if (e.CommandName == "DeleteType")//The delete button was clicked
            {
                int typeId = int.Parse(e.CommandArgument.ToString());

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "DELETE FROM Type WHERE TypeID = " + typeId;
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    BindTypeList();
                }

            }
        }

        private void EditTypeById(int typeId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Type WHERE TypeID = " + typeId;
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    txtTypeName.Text = sdr["TypeName"].ToString();
                }

                btnAddType.Visible = false;
                btnSaveType.Visible = true;
                btnCancel.Visible = true;
                pnlTypeList.Visible = false;
                lblFeedback.Visible = false;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddType.Visible = true;
            btnSaveType.Visible = false;
            btnCancel.Visible = false;
            pnlTypeList.Visible = true;
            txtTypeName.Text = "";
        }

        protected void btnSaveType_Click(object sender, EventArgs e)
        {
            int typeId = int.Parse(lblTypeId.Text);

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                ///TODO 
                ///we need to change the following statement to avoid
                ///sql injection attacks
                cmd.CommandText = "UPDATE Type SET TypeName='" + txtTypeName.Text + "' WHERE TypeID = " + typeId;
                cmd.Connection = conn;
                conn.Open();

                cmd.ExecuteNonQuery();

                BindTypeList();

                btnAddType.Visible = true;
                btnSaveType.Visible = false;
                btnCancel.Visible = false;
                pnlTypeList.Visible = true;
                txtTypeName.Text = "";
            }

        }
    }
}