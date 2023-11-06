<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="PolyglotHub.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto"> <!--Take 8 column and center it-->
                <br /> <br />
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/profpic.png" width="100" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3 class="h1-login-card-text">Polyglot Hub <br />
                                        User Sign Up
                                    </h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr class="custom-hr" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>First Name</label>
                                <div class="form-group">  
                                    <asp:TextBox  class="form-control" ID="TextBox3" 
                                        placeholder="First Name" runat="server" ValidationGroup="1">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ErrorMessage="Required Field*" Display="Dynamic" ControlToValidate="TextBox3" ForeColor="Red" ValidationGroup="1">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Last Name</label>
                                <div class="form-group">  
                                    <asp:TextBox  class="form-control" ID="TextBox4" 
                                        placeholder="Leave Empty if not Applicable." runat="server">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <label>Country</label>
                                <div class="form-group">  
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="select"></asp:ListItem>
                                        <asp:ListItem Text="Brunei Darussalam" Value="Brunei Darussalam"></asp:ListItem>
                                        <asp:ListItem Text="Burma(Myanmar)" Value="Burma(Myanmar)"></asp:ListItem>
                                        <asp:ListItem Text="Cambodia" Value="Cambodia"></asp:ListItem>
                                        <asp:ListItem Text="Indonesia" Value="Indonesia"></asp:ListItem>
                                        <asp:ListItem Text="Laos" Value="Laos"></asp:ListItem>
                                        <asp:ListItem Text="Malaysia" Value="Malaysia"></asp:ListItem>
                                        <asp:ListItem Text="Philippines" Value="Philippines"></asp:ListItem>
                                        <asp:ListItem Text="Singapore" Value="Singapore"></asp:ListItem>
                                        <asp:ListItem Text="Thailand" Value="Thailand"></asp:ListItem>
                                        <asp:ListItem Text="Vietnam" Value="Vietnam"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="errLabel3" runat="server" Text="errLabel3" ForeColor="Red" Visible="False"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Username</label>
                                <div class="form-group">  
                                    <asp:TextBox  class="form-control" ID="TextBox1" 
                                        placeholder="Username" runat="server" ValidationGroup="2">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ErrorMessage="Required Field*" Display="Dynamic" ControlToValidate="TextBox1" ForeColor="Red" ValidationGroup="2">
                                    </asp:RequiredFieldValidator>
                                    <asp:Label ID="errLabel1" runat="server" Text="errLabel1" Visible="False" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="TextBox2" 
                                        placeholder="Password is < 20 Alphanumerics Characters" runat="server" TextMode="Password" ValidationGroup="3">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ErrorMessage="Required Field*" Display="Dynamic" ControlToValidate="TextBox2" ForeColor="Red" ValidationGroup="3">
                                    </asp:RequiredFieldValidator>
                                </div>
                                
                                
                            </div>
                            <div class="col-md-6">
                                <label>Verify Password</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="TextBox6" 
                                        placeholder="Re-enter Your Password" runat="server" TextMode="Password" ValidationGroup="4">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ErrorMessage="Required Field*" Display="Dynamic" ControlToValidate="TextBox6" ForeColor="Red" ValidationGroup="4">
                                    </asp:RequiredFieldValidator>
                                    <asp:CompareValidator runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox6"
                ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                </div>   
                            </div>
                        </div>
                        <div class ="row">
                            <div class="col-md-4">
                                <asp:Label ID="errLabel2" runat="server" Text="errLabel2" ForeColor="Red" Visible="False"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group"> 
                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Submit" class="btn btn-success btn-block btn-lg" />
                        </div>
                    </div>
                </div>
                <center>
                    <br />
                    <a href="LoginPage.aspx">Already a Member?</a>
                    <br />
                </center>
            </div>
        </div>
    </div>

</asp:Content>
