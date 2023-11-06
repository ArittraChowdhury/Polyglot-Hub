<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminGrammarContentManagement.aspx.cs" Inherits="PolyglotHub.WebForm30" %>
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
                <!-- Grammar Content Add/Update/Delete -->
                <div class="row">
                    <div class="card">
                        <div class="card-body">
    
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4 class="h1-login-card-text">
                                            Grammar Content Details
                                        </h4>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="img/GrammarIcon.png" width="100" />
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
                                    <label>Grammar Content ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox  class="form-control" ID="GCIDTB" 
                                            placeholder="ID here" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button ID="SearchBtn" class="btn btn-dark" runat="server" Text="Search" OnClick="SearchBtn_Click" />
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Sub Heading</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="SHTB" 
                                            placeholder="Enter Subheading" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Content Text</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="CTTB" 
                                            placeholder="Enter Text" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <label>Example</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="EXTB" 
                                            placeholder="Separate Example with 'comma (,)' " runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Grammar</label>
                                    <div class="form-group">  
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [GrammarTable]"></asp:SqlDataSource>
                                        <asp:DropDownList ID="GrammarList" runat="server" DataSourceID="SqlDataSource2" DataTextField="Chinese_Title" DataValueField="Grammar_Id"></asp:DropDownList>
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
                                        <asp:Button ID="UpdateBtn" runat="server" Text="Update" class="btn btn-primary btn-block btn-md" OnClick="UpdateBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="DeleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block btn-md" OnClick="DeleteBtn_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <a href="AdminGrammarManagement.aspx"> << Back To Grammar Management >></a>
                                </div>
                            </div>
                        </div>     
                    </div>  
                </div>
                <br />
            </div>   
            
            <!-- Grammar Content List -->
            <div class="col-md-7">
                <br /><br />
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="h1-login-card-text">
                                        Grammar Content List
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [GrammarContent]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" 
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="GrammarContent_Id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="GrammarContent_Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="GrammarContent_Id" />
                                        <asp:BoundField DataField="SubHeading" HeaderText="SubHeading" SortExpression="SubHeading" />
                                        <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
                                        <asp:BoundField DataField="Example" HeaderText="Example(s)" SortExpression="Example" />
                                        <asp:BoundField DataField="Grammar_Id" HeaderText="GrammarID" SortExpression="Grammar_Id" />
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
