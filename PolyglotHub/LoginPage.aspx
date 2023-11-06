<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PolyglotHub.WebForm2" %>
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
                                    <img src="img/profpic.png" width="150" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h1 class="h1-login-card-text">Polyglot Hub <br />
                                        Login
                                    </h1>
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
                                <label>User Username</label>
                                <div class="form-group">  
                                    <asp:TextBox  class="form-control" ID="TextBox1" 
                                        placeholder="Username" runat="server">
                                    </asp:TextBox>
                                </div>

                                <label>Password</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="TextBox2" 
                                        placeholder="Your Password Here" runat="server" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                                
                                <asp:Label ID="errLabel1" runat="server" Text="errLabel" Visible="False" ForeColor="Red"></asp:Label>
          

                                <div class="form-group"> 
                                    <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-success btn-block btn-lg" OnClick="Button1_Click" />
                                </div>

                                <div class="form-group"> 
                                    <a href="SignUpPage.aspx"><input id="Button2" type="button" value="Register" class="btn btn-info btn-block btn-lg" /></a>
                                </div>

                            </div>
                        </div>
                        <div class="container">
                            <div class="login-text-footer">
                                <div style="flex:1">
                                    <a href="forgetPassword.aspx">Forgot your password?</a>
                                </div>
                                <div>
                                    <a href="AdminLoginPage.aspx">Admin Login Here >></a>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>    
            </div>
        </div>
    </div>
</asp:Content>
