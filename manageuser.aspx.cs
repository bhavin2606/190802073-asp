using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        print();
    }
    public void print()
    {
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [name], [email], [password] FROM [login]", con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Submit")
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
                print();
                Literal1.Text = "Registration successfully completed!";
            }
            else
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                print();
                Literal1.Text = "Error!";
            }
        }
        else
        {
            SqlCommand cmd = new SqlCommand("UPDATE [login] SET [name] = @name, [email] = @email, [password] = @password WHERE [id] = @id", con);
            cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@email", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@password", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@id", ViewState["user_id"]);
            con.Open();
            int s = cmd.ExecuteNonQuery();
            con.Close();
            if (s == 1)
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                print();
                Literal1.Text = "Record Update Successfull..!";
            }
            else
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                print();
                Literal1.Text = "Error!";
            }
        }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [name], [email], [password] FROM [login] WHERE [id] =" + btn.CommandArgument, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            TextBox1.Text = dt.Rows[0][1].ToString();
            TextBox2.Text = dt.Rows[0][2].ToString();
            TextBox3.Text = dt.Rows[0][3].ToString();
            ViewState["user_id"] = btn.CommandArgument;
            Button1.Text = "Update";
        }
    protected void Button3_Click(object sender, EventArgs e)
    {   
        Button btn = (Button)sender;
        SqlCommand cmd = new SqlCommand("DELETE FROM [login] WHERE [id] = @id", con);
        cmd.Parameters.AddWithValue("@id", btn.CommandArgument);
        con.Open();
        int s = cmd.ExecuteNonQuery();
        con.Close();
        if (s == 1)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            print();
            Literal1.Text = "Data Deleted Successfull....";
        }
        else
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            print();
            Literal1.Text = "Error!";
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}