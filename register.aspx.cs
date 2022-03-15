using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
                    //DeleteCommand="DELETE FROM [login] WHERE [id] = @id" 
                    //InsertCommand="INSERT INTO [login] ([name], [email], [password]) VALUES (@name, @email, @password)" 
                    //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
                    //SelectCommand="SELECT [id], [name], [email], [password] FROM [login]" 
                    //UpdateCommand="UPDATE [login] SET [name] = @name, [email] = @email, [password] = @password WHERE [id] = @id">
                        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO [login] ([name], [email], [password]) VALUES (@name, @email, @password)", con);
        cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
        cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
        cmd.Parameters.AddWithValue("@password", TextBox3.Text.Trim());
        con.Open();
        int s = cmd.ExecuteNonQuery();
        con.Close();
        if (s == 1)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            Literal1.Text = "Registration successfully completed!";
        }
        else
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            Literal1.Text = "Error!";
        }
    }
}