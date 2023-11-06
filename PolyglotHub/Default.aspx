<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PolyglotHub.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
          font-family: Arial, sans-serif;   
        }

        h1 {
          margin: 0;
          color: white;
        }

        section {
          padding: 20px;
        }

        .bg-container {
            position: relative;
            background-image: url('img/bgimage.png');
            background-size: cover;
            background-position: center;
            height: 100%; /* Adjust the height as needed */
            z-index: -1; /* Push the image behind the content */
        }
        
        .content {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            font-size: 24px; /* Adjust the font size as needed */
            text-align: center;
        }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-container">
        <img src="img/bgimage.png" />
        <section class="content">
            <h2>Welcome to Our Chinese Language Learning Platform</h2>
            <p>Start your journey to chinese language fluency with our wide range of courses taught by experienced teachers.</p>
            <p>Whether you're a beginner or an advanced learner, we have courses to suit your needs.</p>
            <p>Sign up now and explore the world of chinese languages!</p>
        </section>
    </div>
</asp:Content>
