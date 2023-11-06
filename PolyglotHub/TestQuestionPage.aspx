<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="TestQuestionPage.aspx.cs" Inherits="PolyglotHub.WebForm20" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .header-text {
            font-size: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="flexbox" runat="server">
            <br />
            <div class="card-header">
                <br />
                <div class="row">
                    <div class="col">
                        <asp:Label ID="TextLabel" runat="server" Text="[Label]" class="header-text"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Label ID="scoreLabel" runat="server" Text="[Score]" ForeColor="Red" EnableViewState="True"></asp:Label><br />
            </div> 
        </div>
        <div class="row">
            <div class="col">
                <asp:Button ID="CheckBtn" runat="server" Text="Submit" class="btn btn-primary" OnClick="CheckBtn_Click"/><br />
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Button ID="ReturnBtn" runat="server" Text="Return To Test List" class="btn btn-primary" OnClick="ReturnBtn_Click" /><br />
            </div>
        </div>
        <br />
        
    </div>
</asp:Content>
