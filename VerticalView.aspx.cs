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
    public partial class VerticalView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // LoadVerticalView_Datatable();
            LoadVerticalView1();
        }

        private void LoadVerticalView1()
        {
            string HtmlRow = Implements.GetView(Server.MapPath("MyViews/VerticalView_1.html"));

            Datas.DataSettings Settings = new Datas.DataSettings();
            List<Datas.DataSettings> LSettings = Settings.GetSettingsList();

            DataTable dt_settings = Implements.ModelToDataTable
                (
                    new string[] 
                    {
                          "Id"
                        , "Name"
                        , "Img"
                        , "Desc"
                        , "Author"
                        , "Info"
                        , "Link"
                    }
                    , LSettings
                );

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", "Id");
            KeyVals.Add("f_name", "Name");

            AtomicItemsLib.ListView lv = new AtomicItemsLib.ListView(dt_settings, KeyVals, 0);
            div_vertical_view_0.InnerHtml = lv.CreateVerticalListviewFromView(HtmlRow);
            
        }

        private void LoadVerticalView_Datatable()
        {
            Datas.DataSettings tableSettings = new Datas.DataSettings();
            DataTable dt_settings = tableSettings.GetSettings();

            string ItemView = Implements.GetView(Server.MapPath("MyViews/VerticalView_1.html"));

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", "f_id");
            KeyVals.Add("f_name", "f_name");

            AtomicItemsLib.ListView lv = new AtomicItemsLib.ListView(dt_settings, KeyVals, 0);
            div_vertical_view_0.InnerHtml = lv.CreateVerticalListviewFromView(ItemView);

        }


    }
}