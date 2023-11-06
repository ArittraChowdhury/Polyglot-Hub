<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="UserProfilePage.aspx.cs" Inherits="PolyglotHub.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto"> <!--Take 8 column-->
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
                                    <h4 class="h1-login-card-text">
                                        Your Profile
                                    </h4>
                                    <span>Account Status - </span>
                                    <asp:Label ID="Label1" class="badge badge-pill badge-info" runat="server" Text="[Your Status]"></asp:Label>
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
                                        placeholder="First Name" runat="server">
                                    </asp:TextBox>
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
                                <label>Email</label>
                                <div class="form-group">  
                                    <asp:TextBox  class="form-control" ID="TextBox5" 
                                        placeholder="Email Here" runat="server" TextMode="Email">
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
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Date Joined</label>
                                <div class="form-group">  
                                    <asp:TextBox  class="form-control" ID="TextBox1" 
                                        placeholder="dd-mm-yyyy" runat="server">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Username</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="TextBox2" 
                                        placeholder="Current Username" runat="server" TextMode="Password" ReadOnly="True">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Password</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="TextBox6" 
                                        placeholder="Current Password" runat="server" TextMode="Password" ReadOnly="True">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group"> 
                                    <asp:TextBox  class="form-control" ID="TextBox7" 
                                        placeholder="Change Your Password." runat="server" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                            </div>
                            
                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <div class="form-group"> 
                                    <center>
                                        <asp:Button ID="Button1" runat="server" Text="Update" class="btn btn-primary btn-block btn-md" />
                                    </center>
                                </div>
                            </div>
                        </div>

                        <div class="login-text-footer">
                            <br />
                            <a style="flex:1" href="LoginPage.aspx"><< Start Learning!</a>
                            <a href="#">Vocabulary List >></a>
                            <br />
                        </div>

                    </div>
                </div>
                <br /> <br />
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/UserProfileLessonHistoryIconnobg.png" width="240" height="210"/>
                                </center>  
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="h1-login-card-text">
                                        Last Attempt on Test
                                    </h4>
                                    <asp:Label ID="Label2" class="badge badge-pill badge-info" runat="server" Text="Your Activity Info"></asp:Label>
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
                                <asp:GridView class="table table-striped table-bordered" 
                                    ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                       
            </div>   
        </div>
    </div>

</asp:Content>
