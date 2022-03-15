<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ManageService.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<section class="wrapper">
	<div class="form-w3layouts">
        <!-- page start-->
        <!-- page start-->
        <div class="row">
            <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Manage Tour Services
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                                
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Add Title</label>
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control"  placeholder="Enter email"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Description</label>
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control"  placeholder="Enter Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputFile">Add Photo</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                                    
                                    <asp:Image ID="Image2" runat="server" Height="92px" Width="96px" />
                                    
                                </div>
                                
                               
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Select Day</label>
                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control"  placeholder="Enter Password"></asp:TextBox>
                                </div>
                              
                               <div class="form-group">
                                    <label for="exampleInputPassword1">Price</label>
                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control"  placeholder="Enter Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Status</label>
                                    <br />
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">Deactive</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                                
                                <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-info" 
                                    onclick="Button1_Click" ></asp:Button>
                               
                                <div class="checkbox">
                                  <asp:Literal ID="Literal1" runat="server"></asp:Literal> 
                                </div>
                                <div class="checkbox">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" CellSpacing="2" Width="472px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="id">
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("id") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="title">
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("title") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="description">
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("description") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="image">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" Height="81px" 
                                                        ImageUrl='<%# Eval("image", "~/uploads/{0}") %>' Width="78px" />
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="day">
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("day") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="price">
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("price") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="status">
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("status") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="edit">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button2" runat="server" Text="Edit" 
                                                        CommandArgument='<%# Eval("id") %>' onclick="Button2_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("id") %>' 
                                                        onclick="Button3_Click" Text="Delete" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                        <SortedDescendingHeaderStyle BackColor="#93451F" />
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

