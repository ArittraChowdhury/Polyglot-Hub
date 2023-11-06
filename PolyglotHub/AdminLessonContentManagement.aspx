<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminLessonContentManagement.aspx.cs" Inherits="PolyglotHub.WebForm29" %>
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
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <br /><br />
                <div class="row">
                    <div class="card">
                        <div class="card-body">
    
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4 class="h1-login-card-text">
                                            Content Details
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
                                    <label>Lesson Content ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox  class="form-control" ID="LessonContentIDTB" 
                                            placeholder="ID here" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button ID="ContentIDSearchBtn" class="btn btn-dark" runat="server" Text="Search" OnClick="ContentIDSearchBtn_Click" />
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Chinese Text</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="ChineseTextTB" 
                                            placeholder="Enter Chinese Text" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Pinyin e.g. 你好 Nǐhǎo</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="TextBox1" 
                                            placeholder="Enter PinYin of Text" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Translation</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="TranslationTB" 
                                            placeholder="Enter Translation of Text" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [LessonTable]"></asp:SqlDataSource>
                                    <label>Lesson ID</label>
                                    <div class="form-group">  
                                        <asp:DropDownList ID="LessonIDList" runat="server" DataSourceID="SqlDataSource2" DataTextField="Lesson_Id" DataValueField="Lesson_Id"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="ContentAddBtn" runat="server" Text="Add" class="btn btn-success btn-block btn-md" OnClick="ContentAddBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="ContentUpdateBtn" runat="server" Text="Update" class="btn btn-primary btn-block btn-md" OnClick="ContentUpdateBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="ContentDeleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block btn-md" OnClick="ContentDeleteBtn_Click" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <a href="AdminLessonManagement.aspx"><< Back to Lesson Management >></a>
                                    </div>
                                </div>
                            </div>
                        </div>    
                    </div>
                </div>
                <br />
            </div>
            <div class="col-md-7">
                <br />  
                <br />
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="h1-login-card-text">
                                        Lesson Content List
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [LessonContent]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" 
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="LessonContent_Id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="LessonContent_Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="LessonContent_Id" />                                 
                                        <asp:BoundField DataField="Content" HeaderText="Content" SortExpression="Content" />
                                        <asp:BoundField DataField="Pinyin" HeaderText="Pinyin" SortExpression="Pinyin" />
                                        <asp:BoundField DataField="Translation" HeaderText="Translation" SortExpression="Translation" />
                                        <asp:BoundField DataField="Lesson_Id" HeaderText="LessonID" SortExpression="Lesson_Id" />
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
