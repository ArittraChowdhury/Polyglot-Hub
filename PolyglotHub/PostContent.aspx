<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="PostContent.aspx.cs" Inherits="PolyglotHub.WebForm26" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .header-text {
            font-size: 21px;
        }
        .body-text {
            font-size: 17px;
        }
        .gridview-container {
        width: 100%;
        height: 100%;
        overflow: auto;
        }
        .gridview-item {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="flexbox" runat="server" class="row">
            <div class="col-md-10 mx-auto">
                <div class="card">
                    <div class="card-header">
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="TextLabel" runat="server" Text="[Label]" class="header-text"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="ContentLabel" runat="server" Text="[Label]" class="header-text"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <div class="gridview-container">                        
                                    <asp:Label ID="HiddenLabel" runat="server" Text="DiscID" Visible="False"></asp:Label>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [CommentTable] WHERE ([Discussion_Id] = @Discussion_Id)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="HiddenLabel" Name="Discussion_Id" PropertyName="Text" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:GridView ID="GridView1" CssClass="gridview-item" runat="server" AutoGenerateColumns="False" DataKeyNames="Comment_Id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-lg-10">
                                                                <div class="row">
                                                                    <div class="col-md-4">                              
                                                                        By -
                                                                        <asp:Label ID="NameOwner" runat="server" Text='<%# GetMemberName(Eval("Member_Id")) %>' Font-Bold="True"></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:Label ID="CommentLbl" runat="server" Font-Size="Larger" Text='<%# Eval("CommentText") %>'></asp:Label>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        Posted at :&nbsp;
                                                                        <asp:Label ID="dateLabel" runat="server" Text='<%# Eval("Date_Created") %>' Font-Bold="True"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                       
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div><br />
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Comment : </label>
                                    <div class="input-group">                 
                                        <asp:TextBox ID="CommentTB" class="form-control" runat="server" ></asp:TextBox>
                                        <asp:Button ID="SendBtn" runat="server" Text="Send" class="btn btn-info" OnClick="SendBtn_Click" />
                                    </div>                                  
                                </div>      
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="StatusLabel" runat="server" Text="Discussion has been Disabled" ForeColor="#CC3300" Visible="False"></asp:Label>
                </div>
            </div>
            <br />            
        </div>
        <br />
        
    </div>
</asp:Content>
