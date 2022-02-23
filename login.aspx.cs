using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //deletecommand="DELETE FROM [login] WHERE [id] = @id" 
        //insertcommand="INSERT INTO [login] ([name], [email], [password]) VALUES (@name, @email, @password)"
        // providername="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>"
        // selectcommand="SELECT [id], [name], [email], [password] FROM [login]" 
        //updatecommand="UPDATE [login] SET [name] = @name, [email] = @email, [password] = @password WHERE [id] = @id">
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
             SqlCommand cmd = new SqlCommand("SELECT COUNT(*)  FROM [login]  WHERE [email] = @email AND [password] = @password", con);
        cmd.Parameters.AddWithValue("@email", TextBox1.Text.Trim());
        cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
        con.Open();
        int s = (int)cmd.ExecuteScalar();
        if (s >= 1)
        {
            Session["email"] = TextBox1.Text;
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Literal1.Text = "invalid Email Or Password";
        }
        con.Close();
        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('" + ex.ToString() + "')<script>");
        }
    }
}