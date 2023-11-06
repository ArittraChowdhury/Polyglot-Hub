<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="LessonPage.aspx.cs" Inherits="PolyglotHub.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

.fab{
  font-size: 32px;
}

.position{
  position: absolute;
  top: 100px;
  right: 40px;
}

* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

h1{
 
  text-align:center;
}


main {
  width: 960px;
  margin: 50px auto;
  display: flex;
}

.step-box {
  width: 300px;
  margin-right: 30px;
  padding: 10px;
  position: relative;
  background-color: #eee;
}

.step-box:last-child {
  margin-right: 0;
}

.step-num {
  position: absolute;
  top: 0;
  left: 0;
  background-color: #ff9a4b;
  color: #fff;
}

.title {
  margin: 15px 0 5px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header></header>
  <h1>Lesson</h1>
 
  <main>
    <div class="step-box">
      <img src="img/begineer.png" width="280" height="150">
      <div> 
        <a href="Lesson_BeginnerPage.aspx">Beginner</a>
      </div>
         <p class="text">
          　 Just starting to learn Chinese
       </p>
    </div>
    <div class="step-box">
      <img src="img/intermediate.png" width="280" height="150">
    <div>
      <a href="Lesson_Intermediate.aspx">Intermediate</a>
    </div>
         <p class="text">
          　 Somewhat Experience in Chinese
       </p>
    </div>
    <div class="step-box">
      <img src="img/advanced.png" width="280" height="150">
    <div>
      <a href="Lesson_AdvancePage.aspx">Advanced</a>
    </div>
        <p class="text">
          　UptoDate knowledge and experience in Chinese
       </p>
    </div>
  </main>
  <footer></footer>
</asp:Content>
