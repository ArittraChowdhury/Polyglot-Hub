<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Lesson_BeginnerPage.aspx.cs" Inherits="PolyglotHub.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .disp-div{
            display: flex;
            justify-content:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row disp-div" id ="cardContainer" runat="server">
    </div>
</asp:Content>
