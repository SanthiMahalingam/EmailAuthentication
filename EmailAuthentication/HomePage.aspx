<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EmailAuthentication.HomePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page - ASP.NET Web Forms Application</title>
    <style>
        /* General Reset */
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            color: #333;
            line-height: 1.6;
        }

        /* Header */
        header {
            background-color:  #00ccff;
            color: #333;
            padding: 20px;
            text-align: center;
        }

        header h1 {
            font-size: 2em;
            margin: 0;
        }

        /* Navigation */
        nav ul {
            list-style: none;
            padding: 10px;
            text-align: center;
            background-color: #444;
        }

        nav ul li {
            display: inline;
            margin: 0 15px;
        }

        nav ul li a {
            color: #fff;
            text-decoration: none;
            font-size: 1em;
        }

        nav ul li a:hover {
            text-decoration: underline;
        }

        /* Main Content */
        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #333;
            margin-bottom: 10px;
        }

        p {
            margin-bottom: 15px;
        }

        /* Footer */
        footer {
            background-color: #00ccff;
            color: #333;
            text-align: center;
            padding: 10px 0;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header Section -->
        <header>
            <h1>WELCOME <br> ABOARD <br /> HAVE A NICE DAY!!</h1>
        </header>

        <!-- Navigation Section -->
        <nav>
            <ul>
                <li><a href="Home.aspx">Home</a></li>
                <li><a href="About.aspx">About</a></li>
                <li><a href="Contact.aspx">Contact</a></li>
                <li><a href="Login.aspx">SignIn</a></li>
            </ul>
        </nav>

        <!-- Main Content Section -->
        <div class="container">

            <h2>Hi, <br /> The Journey begins....</h2>
        </div>

        <!-- Footer Section -->
        <footer>
            <p>&copy; 2024 All Rights Reserved.</p>
        </footer>
    </form>
</body>
</html>