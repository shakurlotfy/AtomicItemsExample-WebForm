using AtomicItemsLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtomicItems
{
    public partial class GridView : System.Web.UI.Page
    {

        private static DataTable dt_cars, dt_books, dt_books_2;
        static List<Datas.DataBooks> LBooks = new List<Datas.DataBooks>();


        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBooks();

            LoadBooks_2();
        }

        private void LoadBooks()
        {
            Datas.DataTableCars tableCars = new Datas.DataTableCars();
            dt_cars = tableCars.GetCars();

            string HtmlRow = Implements.GetView(Server.MapPath("MyViews/GridView_1.html"));

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", "f_id");
            KeyVals.Add("f_name", "f_name");
            KeyVals.Add("f_company", "f_company");
            KeyVals.Add("f_info", "f_info");
            

            Grid gr = new Grid(new string[] { "#", "Name", "Company", "Info" }, KeyVals, dt_cars);
           // gr.HeaderBackgroundColor = "#ffffff";
            div_grid_view_0.InnerHtml = gr.GridCreatorFromView(HtmlRow);

        }

        private void LoadBooks_2()
        {
            Datas.DataBooks Books = new Datas.DataBooks();
            LBooks = Books.GetBooksList();

            dt_books_2 = Implements.ModelToDataTable
                (
                    new string[] 
                    {
                              "Id"
                            , "Name"
                            , "Img"
                            , "Desc"
                            , "Author"
                            , "Link"
                            , "Info"
                    }
                    , LBooks
                );

            string HtmlRow_2 = Implements.GetView(Server.MapPath("MyViews/GridView_2.html"));

            Dictionary<string, string> KeyVals_2 = new Dictionary<string, string>();
            KeyVals_2.Add("f_id", "Id");
            KeyVals_2.Add("f_name", "Name");
            KeyVals_2.Add("f_author", "Author");
            KeyVals_2.Add("f_info", "Info");

            Grid gr_2 = new Grid(new string[] { "#", "Name", "Author", "Info", "", "" }, KeyVals_2, dt_books_2);
            div_grid_view_1.InnerHtml = gr_2.GridCreatorFromView(HtmlRow_2);
        }

        [WebMethod]
        public static string ShowBookEditModal(string Id, string Name, string Author, string Info)
        {
            string ModalPage = Implements.GetView(HttpContext.Current.Server.MapPath("MyViews/BookEditModal.html"));

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", Id);
            KeyVals.Add("f_name", Name);
            KeyVals.Add("f_author", Author);
            KeyVals.Add("f_info", Info);

            AtomicItemsLib.MyPageViewer myPage = new AtomicItemsLib.MyPageViewer(ModalPage, KeyVals, 0);

            return myPage.CreateMyPage();
        }

        [WebMethod]
        public static string Edit(string Id, string Name, string Author, string Info)
        {
            //for (int i = 0; i < dt_books_2.Rows.Count; i++)
            //{
            //    if (dt_books_2.Rows[i]["f_id"].ToString() == Id)
            //    {
            //        dt_books_2.Rows[i]["f_name"] = Name;
            //        dt_books_2.Rows[i]["f_author"] = Author;
            //        dt_books_2.Rows[i]["f_info"] = Info;

            //        i = dt_books_2.Rows.Count;
            //    }
            //}
            
            for (int i = 0; i < LBooks.Count; i++)
            {
                Datas.DataBooks Book = LBooks[i];
                if (Book.Id == Id)
                {
                    Book.Name = Name;
                    Book.Author = Author;
                    Book.Info = Info;

                    i = LBooks.Count;
                }
            }

            dt_books_2 = Implements.ModelToDataTable
                (
                    new string[]{"Id", "Name", "Img", "Desc", "Author", "Link", "Info"}, LBooks
                );

            string HtmlRow_2 = Implements.GetView(HttpContext.Current.Server.MapPath("MyViews/GridView_2.html"));

            Dictionary<string, string> KeyVals_2 = new Dictionary<string, string>();
            KeyVals_2.Add("f_id", "Id");
            KeyVals_2.Add("f_name", "Name");
            KeyVals_2.Add("f_author", "Author");
            KeyVals_2.Add("f_info", "Info");

            Grid gr_2 = new Grid(new string[] { "#", "Name", "Author", "Info", "", "" }, KeyVals_2, dt_books_2);
            return gr_2.GridCreatorFromView(HtmlRow_2);

        }


    }
}