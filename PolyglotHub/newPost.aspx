<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="newPost.aspx.cs" Inherits="PolyglotHub.WebForm24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .custom-label {
            font-size: 20px;
            font-family: 'Leelawadee UI';
        }
        .textbox-size {
            width: 100%;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <br />
                <br />
                <div class="card">
                    <div class="card-header">
                        <center><h1> Create New Post </h1></center>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="PostLabel" runat="server" Text="Post Title" class="custom-label"></asp:Label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="PT_TB1" runat="server" TextMode="MultiLine" class="textbox-size" Height="55px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="DescLabel" runat="server" Text="Post Description" class="custom-label"></asp:Label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="PD_TB1" runat="server" TextMode="MultiLine" class="textbox-size" Height="100px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group"> 
                                    <asp:Button ID="createBtn" runat="server" Text="Create Post" class="btn btn-success btn-block btn-md" OnClick="createBtn_Click" />
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
