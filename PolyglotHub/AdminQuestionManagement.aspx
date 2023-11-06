<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminQuestionManagement.aspx.cs" Inherits="PolyglotHub.WebForm11" %>
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
                <!-- Question Add/Update/Delete -->
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4 class="h1-login-card-text">
                                            Question Details
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
                                    <label>Question ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox  class="form-control" ID="qIDTB" 
                                            placeholder="ID here" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button ID="searchBtn" class="btn btn-dark" runat="server" Text="Search" OnClick="searchBtn_Click" />
                                        </div>   
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>QuestionText</label>
                                    <asp:TextBox  class="form-control" ID="qTxtTB" 
                                            placeholder="Text Here" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Choice 1</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="c1TB" 
                                            placeholder="A." runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <label>Choice 2</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="c2TB" 
                                            placeholder="B." runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <label>Choice 3</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="c3TB" 
                                            placeholder="C." runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>ReadingText ID</label>
                                    <div class="form-group">  
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [ReadingTest]"></asp:SqlDataSource>
                                        <asp:DropDownList ID="TestIDList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ReadingTest_Id" DataValueField="ReadingTest_Id"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Answer</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="ansTB" 
                                            placeholder="Answer Here" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="addBtn" runat="server" Text="Add" class="btn btn-success btn-block btn-md" OnClick="addBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="updateBtn" runat="server" Text="Update" class="btn btn-primary btn-block btn-md" OnClick="updateBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="deletebtn" runat="server" Text="Delete" class="btn btn-danger btn-block btn-md" OnClick="deletebtn_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <a href="AdminTestManagement.aspx"><< Manage Test Text Here >></a>
                                </div>
                            </div>
                        </div>     
                    </div>
                </div>
                
                <br />
            </div>   
            
            <!-- Question Table List -->
            <div class="col-md-7">
                <br /><br />
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="h1-login-card-text">
                                        Question List
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
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [QuestionTable]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" 
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Question_Id" DataSourceID="SqlDataSource2">
                                    <Columns>
                                        <asp:BoundField DataField="Question_Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Question_Id" />
                                        <asp:BoundField DataField="Content" HeaderText="Question" SortExpression="Content" />
                                        <asp:BoundField DataField="FirstChoice" HeaderText="A" SortExpression="FirstChoice" />
                                        <asp:BoundField DataField="SecondChoice" HeaderText="B" SortExpression="SecondChoice" />
                                        <asp:BoundField DataField="ThirdChoice" HeaderText="C" SortExpression="ThirdChoice" />
                                        <asp:BoundField DataField="Answer" HeaderText="Answer" SortExpression="Answer" />
                                        <asp:BoundField DataField="ReadingTest_Id" HeaderText="Test ID" SortExpression="ReadingTest_Id" />
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
