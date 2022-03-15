<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="manageuser.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <section class="wrapper">
	<div class="form-w3layouts">
        <!-- page start-->
        <!-- page start-->
        <div class="row">
            <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Manage Users
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                                
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter FullName</label>
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control"  placeholder="Enter FullName"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Email</label>
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control"  placeholder="Enter email"></asp:TextBox>
                                </div>
                               
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Password</label>
                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control"  placeholder="Enter Password"></asp:TextBox>
                                </div>
                               
                                <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-info" 
                                    onclick="Button1_Click" ></asp:Button>
                               
                                <div class="checkbox">
                                  <asp:Literal ID="Literal1" runat="server"></asp:Literal> 
                                </div>
                                <div class="checkbox">
                                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        Width="464px" onselectedindexchanged="GridView1_SelectedIndexChanged">
                                      <Columns>
                                          <asp:TemplateField HeaderText="id">
                                              <ItemTemplate>
                                                  <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("id") %>'></asp:Literal>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Fullname">
                                              <ItemTemplate>
                                                  <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("name") %>'></asp:Literal>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Email">
                                              <ItemTemplate>
                                                  <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("email") %>'></asp:Literal>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Password">
                                              <ItemTemplate>
                                                  <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("password") %>'></asp:Literal>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Edit">
                                              <ItemTemplate>
                                                  <asp:Button ID="Button2" runat="server" Text="Edit" onclick="Button2_Click" 
                                                      CommandArgument='<%# Eval("id") %>' />
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="delete">
                                              <ItemTemplate>
                                                  <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("id") %>' 
                                                      Text="Delete" onclick="Button3_Click" />
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                      </Columns>
                                    </asp:GridView>
                                </div>
                               
                            </div>

                        </div>
                    </section>

            </div>
            
        </div>
        <!-- page end-->
        </div>
</section>
</asp:Content>

