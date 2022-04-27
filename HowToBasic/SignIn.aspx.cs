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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();

#pragma warning disable CS0618 // Type or member is obsolete
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
#pragma warning restore CS0618 // Type or member is obsolete

                if (VerifyLogin(email, hashedPassword))
                {
                    Session["email"] = email;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblSigninFailed.Visible = true;
                    lblSigninFailed.Text = "Sign in failed. Try again";
                }


            }
        }

        private bool VerifyLogin(string email, string hashedPassword)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["HTBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE Email=@email AND HashedPassword=@hashedPassword";
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
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