<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GridView.aspx.cs" Inherits="AtomicItems.GridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script>
        function BookEdit(Id) {

            var Name = $("#txt_name").val();
            var Author = $("#txt_author").val();
            var Info = $("#txt_info").val();

            $.ajax({
                type: "POST",
                url: "../GridView.aspx/Edit",
                data: "{'Id':'" + Id + "','Name':'" + Name + "','Author':'" + Author + "','Info':'" + Info + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    
                    document.getElementById('<%=div_grid_view_1.ClientID %>').innerHTML = msg.d;
                    ShowHideSmooth('bg_modal', 'hide');
        },
        error: function (msg) {
            alert(msg.responseJSON);
            console.log(msg);
        },
        failure: function (msg) {
            alert(msg.responseText);
        }
    });

        }
    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <center>
        <div id="div_grid_view_0" runat="server" style="margin:50px 0px 50px 0px; width:96%;"></div>
    </center>




    <center>
        <div class="fram_3" style="width:96%;">
            <div id="div_grid_view_1" runat="server" ></div>
        </div>
    </center>



</asp:Content>
