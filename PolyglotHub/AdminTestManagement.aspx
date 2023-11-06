<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminTestManagement.aspx.cs" Inherits="PolyglotHub.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find
                ("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <br /> <br />
                <!-- Test Add/Update/Delete -->
                <div class="row-md-4">
                    <div class="card">
                        <div class="card-body">
    
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4 class="h1-login-card-text">
                                            Reading Test Details
                                        </h4>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="img/readingicon.png" width="100" />
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
                                    <label>Test ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox  class="form-control" ID="TSID" 
                                            placeholder="ID here" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button ID="SearchBtn" class="btn btn-dark" runat="server" Text="Search" OnClick="SearchBtn_Click" />
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Test Text</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="TTLTB" 
                                            placeholder="Text Here" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [LevelTable]"></asp:SqlDataSource>
                                    <asp:DropDownList ID="LevelList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Level_Id"></asp:DropDownList>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="AddBtn" runat="server" Text="Add" class="btn btn-success btn-block btn-md" OnClick="AddBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="updateBtn" runat="server" Text="Update" class="btn btn-primary btn-block btn-md" OnClick="updateBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="deleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block btn-md" OnClick="deleteBtn_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <a href="AdminQuestionManagement.aspx"><< Manage Questions Here >></a>
                                </div>
                            </div>

                        </div>     
                    </div>
                </div>     
                <br />
            </div>   
            
            <!-- Test Table View -->
            <div class="col-md-7">
                <br /><br />
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h4 class="h1-login-card-text">
                                                Test Table
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
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [ReadingTest]"></asp:SqlDataSource>
                                        <asp:GridView class="table table-striped table-bordered" 
                                            ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ReadingTest_Id" DataSourceID="SqlDataSource2">
                                            <Columns>
                                                <asp:BoundField DataField="ReadingTest_Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ReadingTest_Id" />
                                                <asp:BoundField DataField="TestText" HeaderText="TestText" SortExpression="TestText" />
                                                <asp:BoundField DataField="Level_Id" HeaderText="Level ID" SortExpression="Level_Id" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>

</asp:Content>
