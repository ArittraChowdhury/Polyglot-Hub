<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="forgetPassword.aspx.cs" Inherits="PolyglotHub.WebForm33" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto"> <!--Take 6 column and center it-->
                <br /> <br />
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h1 class="h1-login-card-text">Polyglot Hub<br /></h1>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr class="custom-hr" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Username</label>
                                <div class="form-group">  
                                    <asp:TextBox  class="form-control" ID="user_TB" 
                                        placeholder="Username" runat="server">
                                    </asp:TextBox>
                                </div>

                                <label>First Name</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="FN_TB" 
                                         runat="server">
                                    </asp:TextBox>
                                </div>

                                <label>Last Name</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="LN_TB" 
                                         runat="server">
                                    </asp:TextBox>
                                </div>

                                <label>New Password</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="NP_TB" 
                                         runat="server" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                                
                                <asp:Label ID="errLabel1" runat="server" Text="errLabel" Visible="False" ForeColor="Red"></asp:Label>
          

                                <div class="form-group"> 
                                    <asp:Button ID="resetBtn" runat="server" Text="Reset Password" class="btn btn-success btn-block btn-lg" OnClick="resetBtn_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>    
            </div>
        </div>
    </div>
</asp:Content>
