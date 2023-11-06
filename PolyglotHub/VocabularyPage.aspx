<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="VocabularyPage.aspx.cs" Inherits="PolyglotHub.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">

                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h4 class="h1-login-card-text">
                                                Vocabulary Words
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
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [LevelTable]"></asp:SqlDataSource>
                                        <asp:DropDownList ID="LevelList" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Level_Id" AutoPostBack="True" OnSelectedIndexChanged="LevelList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col">
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [VocabularyWord] WHERE ([Level_Id] = @Level_Id)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="LevelList" Name="Level_Id" PropertyName="SelectedValue" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:GridView class="table table-striped table-bordered" 
                                            ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="VocabularyWord_Id" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="NumLabel" runat="server" Text="Label"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ChineseWord" HeaderText="Chinese" SortExpression="ChineseWord" />
                                                <asp:BoundField DataField="Pinyin" HeaderText="Pinyin" SortExpression="Pinyin" />
                                                <asp:BoundField DataField="EnglishText" HeaderText="English" SortExpression="EnglishText" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div> 
        </div>
    </div>
</asp:Content>
