using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtomicItemsLib;

namespace AtomicItems
{
    public partial class VerticalViewMobil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadVerticalView();
        }


        private void LoadVerticalView()
        {
            Datas.DataTableCars tableCars = new Datas.DataTableCars();
            DataTable dt_scars = tableCars.GetCars();

            string ItemView = Implements.GetView(Server.MapPath("MyViews/VerticalView_2.html"));

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", "f_id");
            KeyVals.Add("f_name", "f_name");
            KeyVals.Add("f_logo", "f_logo");
            KeyVals.Add("f_company", "f_company");
            KeyVals.Add("f_info", "f_info");
            KeyVals.Add("f_price", "f_price");

            AtomicItemsLib.ListView lv = new AtomicItemsLib.ListView(dt_scars, KeyVals, 0);
            div_cars_bg.InnerHtml = lv.CreateVerticalListviewFromView(ItemView);


        }

        [WebMethod]
        public static string CarDetails(string Id)
        {
            string Company = "", Name = "", Img = "", Desc = "", Info = "", Logo = "", Price = "";

            Datas.DataTableCars dataTableCars = new Datas.DataTableCars();
            DataTable dt_cars = dataTableCars.GetCars();


            for (int i = 0; i < dt_cars.Rows.Count; i++)
            {
                if (dt_cars.Rows[i]["f_id"].ToString() == Id)
                {
                    Company = dt_cars.Rows[i]["f_company"].ToString();
                    Name = dt_cars.Rows[i]["f_name"].ToString();
                    Img = dt_cars.Rows[i]["f_img"].ToString();
                    Info = dt_cars.Rows[i]["f_info"].ToString();
                    Desc = dt_cars.Rows[i]["f_desc"].ToString();
                    Logo = dt_cars.Rows[i]["f_logo"].ToString();
                    Price = dt_cars.Rows[i]["f_price"].ToString();

                    i = dt_cars.Rows.Count;
                }
            }

            string ModalPage = Implements.GetView(HttpContext.Current.Server.MapPath("MyViews/CarDetailsModal.html"));

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_img", Img);
            KeyVals.Add("f_name", Name);
            KeyVals.Add("f_company", Company);
            KeyVals.Add("f_logo", Logo);
            KeyVals.Add("f_info", Info);
            KeyVals.Add("f_desc", Desc);
            KeyVals.Add("f_price", Price);

            AtomicItemsLib.MyPageViewer myPage = new AtomicItemsLib.MyPageViewer(ModalPage, KeyVals, 0);

            return myPage.CreateMyPage();
        }


    }
}