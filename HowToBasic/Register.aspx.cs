using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;

namespace HowToBasic
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if(txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
                {
                    string email = txtEmail.Text.Trim();
                    string password = txtPassword.Text.Trim();

                    if (!IsEmailRegistered(email))
                    {
                        RegisterUser(email, password);
                    }
                    else
                    {
                        lblRegisterFailed.Visible = true;
                        lblRegisterFailed.Text = "Registration failed. Try again.";
                    }
                } else
                {
                    lblRegisterFailed.Visible = true;
                    lblRegisterFailed.Text = "Registration failed. Try again.";
                }
                
            }
        }

        private void RegisterUser(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;

#pragma warning disable CS0618 // Type or member is obsolete
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
#pragma warning restore CS0618 // Type or member is obsolete
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_AddNewUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                cmd.Parameters.AddWithValue("@AdministrativeID", 0);
                cmd.Connection = conn;
                conn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    Response.Redirect("SignIn.aspx");
                }
                else
                {
                    lblRegisterFailed.Visible = true;
                    lblRegisterFailed.Text = "Registration failed. Try again.";
                }
            }
        }

        private bool IsEmailRegistered(string email)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;

                // 2. Create a SqlCommand object
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE Email = '" + email + "'";
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}