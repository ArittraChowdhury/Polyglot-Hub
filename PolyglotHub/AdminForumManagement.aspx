<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminForumManagement.aspx.cs" Inherits="PolyglotHub.WebForm31" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type-="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
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
                                            Forum Details
                                        </h4>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="img/discussIcon.png" width="100" />
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
                                    <label>Discussion ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox  class="form-control" ID="discIDTB" 
                                            placeholder="ID here" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button ID="searchBtn" class="btn btn-dark" runat="server" Text="Search" CssClass="auto-style1" OnClick="searchBtn_Click" />
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Title</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="title_TB" 
                                            placeholder="Discussion Title" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>            
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>Content</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="content_TB" 
                                            placeholder="Content of Post" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Discussion Status</label>
                                    <div class="form-group">  
                                        <div class="input-group">
                                            <asp:TextBox  class="form-control" ID="DS_TB" 
                                                placeholder="Status" runat="server" ReadOnly="True"></asp:TextBox>
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
                                    <label>Date Created</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="DC_TB" 
                                            placeholder="yyyy-mm-dd" runat="server" ReadOnly="True"></asp:TextBox> 
                                  </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Member (Creator)</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="user_TB" 
                                            placeholder="User ID" runat="server" ReadOnly="True"></asp:TextBox>
                                  </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group"> 
                                        <asp:Button ID="deleteBtn" runat="server" Text="Delete Permanently" class="btn btn-danger btn-block btn-md" OnClick="deleteBtn_Click" />
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
                                        Discussion List
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [Discussion]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" 
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Discussion_Id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Discussion_Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Discussion_Id" />
                                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                        <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
                                        <asp:BoundField DataField="Date_Created" HeaderText="Date" SortExpression="Date_Created" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="Member_Id" HeaderText="CreatorID" SortExpression="Member_Id" />
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
