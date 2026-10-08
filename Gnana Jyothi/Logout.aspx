<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Gnana_Jyothi.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Gnana Jyothi</title>
  <meta name="description" content="Gnana Jyothi" />
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <link rel="stylesheet" type="text/css" href="css/style.css" />
  <link rel="stylesheet" type="text/css" href="css/Contorl.css" />
  <script type="text/javascript" src="js/jquery.min.js"></script>
  <script type="text/javascript" src="js/image_slide.js"></script>

      <script type="text/javascript">
          function preventBack() { window.history.forward(); }
          setTimeout("preventBack()", 0);
          window.onunload = function () { null };
    </script>
</head>
<body onload="changeHashOnLoad();">
  
    <form id="form1" runat="server">
    <div id="main">
    
	<div id="menubar">
      <ul id="menu">
        <li><a href="index.aspx">Home</a></li>
        <li><a href="OurProfile.aspx">Our Profile</a></li>
         <li><a href="MeetUs.aspx">Meet Us</a></li>
        <li><a href="Login.aspx">Login</a></li>
      </ul>
    </div><!--close menubar-->	

    <div id="slideshow">
	  <ul class="slideshow">
        <li class="show"><img src="images/home_1.jpg" alt="Gnana Jyothi" /></li>
        <li><img src="images/home_2.jpg" alt="Gnana Jyothi" /></li>
      </ul> 
    </div><!--close slidesho-->		  
	
	<div id="header">
	  <div id="banner">
	    <div id="welcome">
	      <h1>Gnana Jyothi</h1>
	    </div><!--close welcome-->
	  </div><!--close banner-->
    </div><!--close header-->
    
	<div id="site_content">
      <h1>Logged Out Successfully</h1>
   </div><!--close site_content--> 
    
	<div id="content_grey">
	  &copy;2020. L K Technologies
    </div><!--close content_grey-->   
 
  </div><!--close main-->
 
    </form>
</body>
</html>
