using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtomicItemsLib;

namespace AtomicItems
{
    public partial class HorizontaList : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHorizontal_0();
            LoadHorizontal_1();
        }

        private void LoadHorizontal_0()
        {
            Datas.DataSettings tableSettings = new Datas.DataSettings();
            DataTable dt_settings = tableSettings.GetSettings();

            string ItemView = Implements.GetView(Server.MapPath("MyViews/SettingView.html"));

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", "f_id");
            KeyVals.Add("f_img", "f_img");
            KeyVals.Add("f_name", "f_name");

            AtomicItemsLib.ListView lv = new AtomicItemsLib.ListView(dt_settings, KeyVals, 0);
            string books_str = lv.HorizontalScrollListView(ItemView, "div_h_v_0");
            string result = "<div id='' style='overflow-x:auto; padding:0px; z-index:10000;'>" + books_str + "</div>";
            div_horizontal_view_0.InnerHtml = result;
        }

        private void LoadHorizontal_1()
        {
            Datas.DataBooks DataBooks = new Datas.DataBooks();
            DataTable dt_books = DataBooks.GetBooks();

            string ItemView = Implements.GetView(Server.MapPath("MyViews/TblView_2.html"));

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", "f_id");
            KeyVals.Add("f_img", "f_img");
            KeyVals.Add("f_name", "f_name");
            KeyVals.Add("f_author", "f_author");
            KeyVals.Add("f_info", "f_info");
            KeyVals.Add("f_price", "f_price");
            KeyVals.Add("f_discount", "f_discount");

            // MyLibrary.ListView lv = new MyLibrary.ListView(dt_books, KeyVals, 0);
            //div_horizontal_view_1.InnerHtml = lv.HorizontalScrollListView(ItemView, "div_h_v_1");
            //string result = "<div id='div_gmain_proposal_goods' style='overflow-x:auto; padding:5px; z-index:10000;'>";
            //string books_str = lv.HorizontalScrollListView(ItemView, "div_h_v_1");

            // string result = "<div class='proposal_bg_default' style='background-color:#ff00ff;'>";
            //string result = "<div id='' style='overflow-x:auto; padding:0px; z-index:10000;'>" + books_str + "</div>";
            //  result += "</div>";

            AtomicItemsLib.ListView lv = new AtomicItemsLib.ListView(dt_books, KeyVals, 0);
            string books_str = lv.HorizontalScrollListView(ItemView, "div_h_v_1");
            string result = "<div id='' style='overflow-x:auto; padding:0px; z-index:10000;'>" + books_str + "</div>";
            div_horizontal_view_1.InnerHtml = result;
        }


    }
}