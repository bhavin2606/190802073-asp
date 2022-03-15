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
        //DeleteCommand="DELETE FROM [services] WHERE [id] = @id" 
        //InsertCommand="INSERT INTO [services] ([title], [description], [image], [day], [price], [status]) VALUES (@title, @description, @image, @day, @price, @status)" 
        //ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
        //SelectCommand="SELECT [id], [title], [description], [image], [day], [price], [status] FROM [services]" 
        //UpdateCommand="UPDATE [services] SET [title] = @title, [description] = @description, [image] = @image, [day] = @day, [price] = @price, [status] = @status WHERE [id] = @id">
    }
    public void print()
    {
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [title], [description], [image], [day], [price], [status] FROM [services]", con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Submit")
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/uploads/" + FileUpload1.FileName));
                SqlCommand cmd = new SqlCommand("INSERT INTO [services] ([title], [description], [image], [day], [price], [status]) VALUES (@title, @description, @image, @day, @price, @status)", con);
                cmd.Parameters.AddWithValue("@title", TextBox1.Text);
                cmd.Parameters.AddWithValue("@description", TextBox2.Text);
                cmd.Parameters.AddWithValue("@image", FileUpload1.FileName);
                cmd.Parameters.AddWithValue("@day", TextBox3.Text);
                cmd.Parameters.AddWithValue("@price", TextBox4.Text);
                cmd.Parameters.AddWithValue("@status", RadioButtonList1.SelectedValue);
                con.Open();
                int s = cmd.ExecuteNonQuery();
                con.Close();
                if (s == 1)
                {
                    clear();
                    print();
                    Literal1.Text = "Service inserted successfully";
                }
                else
                {
                    clear();
                    print();
                    Literal1.Text = "Error!";
                }
            }
            else
            {
                Literal1.Text = "Please select Image...";
            }
        }
        else
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/uploads/" + FileUpload1.FileName));
                SqlCommand cmd = new SqlCommand("UPDATE [services] SET [title] = @title, [description] = @description, [image] = @image, [day] = @day, [price] = @price, [status] = @status WHERE [id] = @id", con);
                cmd.Parameters.AddWithValue("@id", ViewState["service_id"]);
                cmd.Parameters.AddWithValue("@title", TextBox1.Text);
                cmd.Parameters.AddWithValue("@description", TextBox2.Text);
                cmd.Parameters.AddWithValue("@image", FileUpload1.FileName);
                cmd.Parameters.AddWithValue("@day", TextBox3.Text);
                cmd.Parameters.AddWithValue("@price", TextBox4.Text);
                cmd.Parameters.AddWithValue("@status", RadioButtonList1.SelectedValue);
                con.Open();
                int s = cmd.ExecuteNonQuery();
                con.Close();
                if (s == 1)
                {
                    clear();
                    print();
                    Literal1.Text = "Service Updated successfully";
                }
                else
                {
                    clear();
                    print();
                    Literal1.Text = "Error!";
                }
            }
            else
            {
                Literal1.Text = "Please select Image...";
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button btn = (Button    )sender;
        SqlDataAdapter adpt = new SqlDataAdapter("SELECT [id], [title], [description], [image], [day], [price], [status] FROM [services] WHERE id =" + btn.CommandArgument, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        TextBox1.Text = dt.Rows[0][1].ToString();
        TextBox2.Text = dt.Rows[0][2].ToString();
        Image2.ImageUrl = "~/uploads/" + dt.Rows[0][3].ToString();
        TextBox3.Text = dt.Rows[0][4].ToString();
        TextBox4.Text = dt.Rows[0][5].ToString();
        RadioButtonList1.SelectedValue = dt.Rows[0][6].ToString();
        ViewState["service_id"] = btn.CommandArgument;
        Button1.Text = "Update";
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender; 
        SqlCommand cmd = new SqlCommand("DELETE FROM [services] WHERE [id] = @id", con);
        cmd.Parameters.AddWithValue("@id", btn.CommandArgument);
        con.Open();
        int s = cmd.ExecuteNonQuery();
        con.Close();
        if (s == 1)
        {
            clear();
            print();
            Literal1.Text = "Service Deleted successfully";
        }
        else
        {
            clear();
            print();
            Literal1.Text = "Error!";
        }
    }
    public void clear()
    {
        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox3.Text = string.Empty;
        TextBox4.Text = string.Empty;
        FileUpload1.Attributes.Clear();
        Image2.ImageUrl = string.Empty;
        RadioButtonList1.ClearSelection();
    }
}
    