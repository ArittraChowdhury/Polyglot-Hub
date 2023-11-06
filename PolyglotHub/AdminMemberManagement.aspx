<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagement.aspx.cs" Inherits="PolyglotHub.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type-="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <br /> <br />
                <!-- Member Add/Update/Delete -->
                <div class="row">
                    <div class="card">
                        <div class="card-body">
    
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4 class="h1-login-card-text">
                                            Members Details
                                        </h4>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="img/profpic.png" width="100" />
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
                                    <label>Member ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox  class="form-control" ID="MID_TB" 
                                            placeholder="ID here" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button ID="Button10" class="btn btn-dark" runat="server" Text="Search" CssClass="auto-style1" OnClick="Button10_Click" />
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>First Name</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="FN_TB" 
                                            placeholder="User First Name" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <label>Last Name</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="LN_TB" 
                                            placeholder="User Last Name" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
               
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Account Status</label>
                                    <div class="form-group">  
                                        <div class="input-group">
                                            <asp:TextBox  class="form-control" ID="AS_TB" 
                                                placeholder="Account Status" runat="server" ReadOnly="True"></asp:TextBox>
                                            <asp:Button  class="btn btn-success" ID="ActiveBtn" 
                                                Text="A" runat="server" OnClick="ActiveBtn_Click">
                                            </asp:Button>
                                            <asp:Button  class="btn btn-danger" ID="DisableBtn" 
                                                Text="D" runat="server" OnClick="DisableBtn_Click">
                                            </asp:Button>
                                        </div>
                                  </div>
                                </div>

                                <div class="col-md-6">
                                    <label>Date Joined</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="DJ_TB" 
                                            placeholder="dd-mm-yyyy" runat="server" ReadOnly="True"></asp:TextBox> 
                                  </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Username</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="UN_TB" 
                                            placeholder="Username" runat="server" ReadOnly="True"></asp:TextBox>
                                  </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Password</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="PW_TB" 
                                            placeholder="Password" runat="server" ReadOnly="True"></asp:TextBox>
                                  </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Country</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="Country_TB" 
                                            placeholder="Country" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group"> 
                                        <asp:Button ID="Button7" runat="server" Text="Delete Permanently" class="btn btn-danger btn-block btn-md" OnClick="Button7_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>     
                    </div>
                </div>
                
                <br />

            </div>   
            
            <!-- Member Data List -->
            <div class="col-md-6">
                <br /><br />
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="h1-login-card-text">
                                        Member List
                                    </h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [MemberTable]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" 
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Member_Id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Member_Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Member_Id" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">

                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Name -
                                                                    <asp:Label ID="FirstLabel" runat="server" Font-Size="Larger" ForeColor="#996633" Text='<%# Eval("FirstName") %>' Font-Bold="True"></asp:Label>
                                                                    &nbsp;|
                                                                    <asp:Label ID="LastLabel" runat="server" Font-Size="Larger" ForeColor="#996633" Text='<%# Eval("LastName") %>' Font-Bold="False"></asp:Label>
                                                                </div>
                                                               
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Username -
                                                                    <asp:Label ID="usernameLbl" runat="server" Font-Bold="True" Text='<%# Eval("Username") %>'></asp:Label>
                                                                    &nbsp;| Password -
                                                                    <asp:Label ID="passwordLbl" runat="server" Font-Bold="True" Text='<%# Eval("Password") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Country -
                                                                    <asp:Label ID="countryLbl" runat="server" Font-Bold="True" Text='<%# Eval("Country") %>'></asp:Label>
                                                                    &nbsp;| Date :
                                                                    <asp:Label ID="dateLbl" runat="server" Font-Bold="True" Text='<%# Eval("DateJoined") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-2">

                                                            Account Status -
                                                            <asp:Label ID="statusLbl" runat="server" Font-Bold="True" Text='<%# Eval("LoginStatus") %>'></asp:Label>

                                                        </div>
                                                    </div>
                                          
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
