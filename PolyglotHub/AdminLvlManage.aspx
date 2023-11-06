<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminLvlManage.aspx.cs" Inherits="PolyglotHub.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .divfooter {
            display: flex;
            flex-direction: row;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-6">
            <br /> <br />
            <!-- Level Add/Update/Delete -->
            <div class="row-md-4">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="h1-login-card-text">
                                        Level Details
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
                                <label>Lesson Level ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox  class="form-control" ID="LevelID" 
                                        placeholder="ID here" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:Button ID="LevelIdSearchBtn" class="btn btn-dark" runat="server" Text="Search" OnClick="LevelIdSearchBtn_Click" />
                                    </div>
                                    
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Level Name</label>
                                <div class="form-group">  
                                    <asp:TextBox  class="form-control" ID="LevelNameTB" 
                                        placeholder="Enter Level Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group"> 
                                    <asp:Button ID="LevelAddBtn" runat="server" Text="Add" class="btn btn-success btn-block btn-md" OnClick="LevelAddBtn_Click" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group"> 
                                    <asp:Button ID="LeveUpdateBtn" runat="server" Text="Update" class="btn btn-primary btn-block btn-md" OnClick="LeveUpdateBtn_Click" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group"> 
                                    <asp:Button ID="LevelDeleteBtn" runat="server" Text="Delete" class="btn btn-danger btn-block btn-md" OnClick="LevelDeleteBtn_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="divfooter">
                                <a style="flex:1" href="AdminLessonManagement.aspx"> Create Lesson </a>
                                <a href="AdminGrammarManagement.aspx"> Create Grammar </a>
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
