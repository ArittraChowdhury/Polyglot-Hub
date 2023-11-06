<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminLessonManagement.aspx.cs" Inherits="PolyglotHub.WebForm6" %>
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
                <br /> <br />
                <!-- Lesson Add/Update/Delete -->
                <div class="row">
                    <div class="card">
                        <div class="card-body">
    
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4 class="h1-login-card-text">
                                            Lesson Details
                                        </h4>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img id="imgview" height="120" width="150"
                                            src="Lesson_Img/UserProfileLessonHistoryIconnobg.png" />
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
                                    <label>Select Level</label>>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="LevelDropList" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Upload Image</label>>
                                    <div class="form-group">
                                        <asp:FileUpload onchange="readURL(this);" ID="LessonImage" Class="form-control" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Lesson ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox  class="form-control" ID="LessonIDTB" 
                                            placeholder="ID here" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button ID="LessonIdSearchBtn" class="btn btn-dark" runat="server" Text="Search" OnClick="LessonIdSearchBtn_Click" />
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>Chinese Word</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="ChineseTitleTB" 
                                            placeholder="Lesson Title [CN]" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <label>English Translation</label>
                                    <div class="form-group">  
                                        <asp:TextBox  class="form-control" ID="EnglishTitleTB" 
                                            placeholder=" [EN]" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
      

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="LessonAddBtn" runat="server" Text="Add" class="btn btn-success btn-block btn-md" OnClick="LessonAddBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="LessonUpdateBtn" runat="server" Text="Update" class="btn btn-primary btn-block btn-md" OnClick="LessonUpdateBtn_Click" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group"> 
                                        <asp:Button ID="LessonDeleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block btn-md" OnClick="LessonDeleteBtn_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <a href="AdminLessonContentManagement.aspx"><< Add Lesson Content >></a> 
                                </div>
                            </div>
                        </div>     
                    </div>
                </div>
                 
                <br />
            </div>   
            
            <!-- Lesson List -->
            <div class="col-md-7">
                <br />  
                <br />
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="h1-login-card-text">
                                        Lesson List
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [LessonTable]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" 
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Lesson_Id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Lesson_Id" HeaderText="ID " InsertVisible="False" ReadOnly="True" SortExpression="Lesson_Id" />                                 
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-8">

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="ChinesePlaceholder" runat="server" Text='<%# Eval("Chinese_Title") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="EnglishPlaceholder" runat="server" Text='<%# Eval("English_Title") %>' Font-Underline="True" Font-Size="Large" ></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="LevelPlaceholder" runat="server" Text='<%# Eval("Level_Id") %>' Font-Italic="False" Font-Size="Medium" Font-Bold="True"></asp:Label>
                                                                    &nbsp;- Level ID
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-4">
                                                            <asp:Image ID="Image1" class="img-fluid p-2" runat="server" ImageUrl='<%# Eval("LessonImage") %>' Width="220" Height="130" />
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
