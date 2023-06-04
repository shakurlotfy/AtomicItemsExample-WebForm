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
    public partial class TableView : System.Web.UI.Page
    {


        Datas.DataBooks DataBooks = new Datas.DataBooks();
        DataTable dt_books;



        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTableView();
        }

        private void LoadTableView()
        {
          //  dt_books = DataBooks.GetBooks();

            Datas.DataBooks books = new Datas.DataBooks();
            List<Datas.DataBooks> Lbooks = books.GetBooksList();

            DataTable dt_books = Implements.ModelToDataTable
                (
                    new string[] {"Id", "Name", "Img", "Desc", "Author", "Link", "Info", "Price", "Discount"}
                    , Lbooks
                );

            string ItemView = Implements.GetView(Server.MapPath("MyViews/TblView_1.html"));

            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", "Id");
            KeyVals.Add("f_img", "Img");
            KeyVals.Add("f_name", "Name");
            KeyVals.Add("f_author", "Author");
            KeyVals.Add("f_info", "Info");
            KeyVals.Add("f_price", "Price");
            KeyVals.Add("f_discount", "Discount");

            AtomicItemsLib.TableView tableView = new AtomicItemsLib.TableView(dt_books, KeyVals, 0);
            div_table_view.InnerHtml = tableView.TableCreatorFromViewNoPaging(ItemView, "css_books", "books_items");

        }


        [WebMethod]
        public static string BookDetails(string Id)
        {
            string Name = "", Img = "", Desc = "", Info = "", Author = "", Link = "";

            Datas.DataBooks DataBooks = new Datas.DataBooks();
            DataTable dt_books = DataBooks.GetBooks();

            
            for (int i = 0; i < dt_books.Rows.Count; i++)
            {
                if (dt_books.Rows[i]["f_id"].ToString() == Id)
                {
                    Name = dt_books.Rows[i]["f_name"].ToString();
                    Img = dt_books.Rows[i]["f_img"].ToString();
                    Info = dt_books.Rows[i]["f_info"].ToString();
                    Desc = dt_books.Rows[i]["f_desc"].ToString();
                    Author = dt_books.Rows[i]["f_author"].ToString();
                    Link = dt_books.Rows[i]["f_link"].ToString();

                    i = dt_books.Rows.Count;
                }
            }

            string ModalPage = Implements.GetView(HttpContext.Current.Server.MapPath("MyViews/BookDetailsModal.html"));
            
            Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_img", Img);
            KeyVals.Add("f_name", Name);
            KeyVals.Add("f_author", Author);
            KeyVals.Add("f_info", Info);
            KeyVals.Add("f_desc", Desc);
            KeyVals.Add("f_link", Link);

          //  MyLibrary.MyPageViewer myPage = new MyLibrary.MyPageViewer(ModalPage, KeyVals, 0);
            AtomicItemsLib.MyPageViewer myPage = new AtomicItemsLib.MyPageViewer(ModalPage, KeyVals, 0);

            return myPage.CreateMyPage();
        }


    }
}