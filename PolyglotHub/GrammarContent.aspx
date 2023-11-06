<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="GrammarContent.aspx.cs" Inherits="PolyglotHub.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">    
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-header">
                        <div class="row">
                            <div class="col">
                                <h2><asp:Label ID="ChineseTitle" runat="server" Text="[ChineseTitle]"></asp:Label></h2>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <h4><asp:Label ID="EnglishTitle" runat="server" Text="[EnglishTitle]"></asp:Label></h4>
                            </div>
                        </div>
                    </div>
                </div>               
                <br />
                <div id="cardContainer" runat="server">

                </div>
            </div>
        </div>
    </div>
</asp:Content>
