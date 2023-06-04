<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerticalViewMobile.aspx.cs" Inherits="AtomicItems.VerticalViewMobil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link type="text/css" rel="stylesheet" href="Content/bootstrap.css" />
    <link type="text/css" rel="stylesheet" href="css/MyStyle.css" />
    <script type="text/javascript" src="Scripts/jquery-3.7.0.min.js" ></script>
    <script type="text/javascript" src="js/MyJs.js" ></script>
    <script type="text/javascript" src="js/MyFunctions.js" ></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>


            <div class="header_bg">
                <div class="header-item"> <img src="images/icons/ic_left.png" style="width:16px;" /> </div>
                <div class="header-item"> Cars </div>
                <div class="header-item"> <img src="images/icons/ic_car.png" style="width:22px;" /> </div>
            </div>




            <div id="div_cars_bg" runat="server" style="margin-top:45px; margin-bottom:44px;"></div>




            <div class="footer_bg">
                <div class="footer-item"> <img src="images/icons/ic_home_48.png" style="width:30px;" /> </div>
                <div class="footer-item"> <img src="images/icons/ic_product_64.png" style="width:30px;" /> </div>
                <div class="footer-item"> <img src="images/icons/ic_person_64.png" style="width:30px;" /> </div>  
                <div class="footer-item"> <img src="images/icons/ic_setting_48.png" style="width:30px;" /> </div>
            </div>






            <center>
                <div id="bg_modal" class="css_transparent_bg" style="display:none; z-index:10000;">

                    <div id="div_modal"></div>

                </div>
            </center>




        </div>
    </form>
</body>
</html>
