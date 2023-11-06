<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ReportViewPage.aspx.cs" Inherits="PolyglotHub.WebForm32" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Table ID="tblChartData" runat="server" Font-Bold="true" HorizontalAlign="Center">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2" Font-Bold="true" HorizontalAlign="Center">
                    Report Count Visualisation <hr />
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    Category
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="CategList" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="Test by Level" Value="TestByLevel"></asp:ListItem>
                            <asp:ListItem Text="Grammar by Level" Value="GrammarByLevel"></asp:ListItem>
                            <asp:ListItem Text="Vocabulary by Level" Value="VocabularyByLevel"></asp:ListItem>
                            <asp:ListItem Text="Question by Level" Value="QuestionByLevel"></asp:ListItem>
                            <asp:ListItem Text="Discussion by Status" Value="DiscussionByStatus"></asp:ListItem>
                            <asp:ListItem Text="Member by Status" Value="MemberByStatus"></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Chart Type
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="chartRBList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text ="Column" Value="10" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Bar" Value="7"></asp:ListItem>
                        <asp:ListItem Text="Pie" Value="17"></asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <hr />
                    <asp:Button ID="btnChart" runat="server" Text="Create Chart" Font-Bold="true" OnClick="btnChart_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="messageLbl" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
        <div id="divChart" runat="server" visible="false" style="text-align: center">
            <asp:Chart ID="chartComp" runat="server">
                <Series>
                    <asp:Series Name="Count"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>

    </div>
</asp:Content>
