<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="SampleTestPage.aspx.cs" Inherits="PolyglotHub.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        main {
            width: 960px;
            display: flex; 
            justify-content: center;
        }

        .flexbox-box {
            display: flex;
            flex-wrap: wrap;
            justify-content: flex-start;
            align-items: flex-start;
            margin-top: 50px;
            margin-bottom: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <main>
            <div id="flexbox" class="row flexbox-box" runat="server">
      
            </div>
        </main>
    </div>

</asp:Content>
