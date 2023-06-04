# AtomicItemsExample-Webform
A example project for show, how to use AtomicItems for createing responsive Table List Grid view in web.

# Atomic Items
**A simple way to create responsive Table, Grid, List, Modal Forms dynamically**

>**Note:** This Library can use in .Net Webforms Application

Just follow these simple steps to create Table, Grid or List 
- Add JQuery and Bootstrap libraries to your project
- Create your class to keep the information (or use DataTable directly) that you have gotten for example from API
- Create a html file in a folder, for design your items ( ../MyViews/tbl_view_1.html - It's your view )
- Convert model to DataTable
- Specify each value that must use in your view
- Pass parameters to Method and get result and show it


### 1 ) Add JQuery and Bootstrap
>You can add these from Nuget, just search and install them\
then refrence to them

```
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link type="text/css" rel="stylesheet" href="Content/bootstrap.css" />
<script type="text/javascript" src="Scripts/jquery-3.7.0.min.js" ></script>
```
### 2 ) Create a class to keep the information

```
public class DataBooks
    {
        public DataBooks() { }


        public string Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Desc { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
        public string Info { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
}
```
### 2-2 ) Insert datas

```
List<DataBooks> LBooks = new List<DataBooks>();

            DataBooks books1 = new DataBooks();
            books1.Id = "1";
            books1.Name = "I has to say so";
            books1.Img = "i_had_say_so.jpg";
            books1.Desc = "This is the story of the drama relationship between ...";
            books1.Author = "Mike Jones";
            books1.Link = "https://books.google.com/books?id=8q9hQ5vi3tYC&source=gbs_slider_cls_metadata_1021_mylibrary";
            books1.Info = "Seven Stories Press, Dey 14, 1389 AP - Biography & Autobiography - 256 pages";
            books1.Price = "1200";
            books1.Discount = "200";
            LBooks.Add(books1);
```
### 2-3 ) OR Create a DataTable to keep the information and then Insert datas

```
DataTable dt_books = new DataTable();
            dt_books.Columns.Add("f_id");
            dt_books.Columns.Add("f_name");
            dt_books.Columns.Add("f_desc");
            dt_books.Columns.Add("f_img");
            dt_books.Columns.Add("f_author");
            dt_books.Columns.Add("f_info");
            dt_books.Columns.Add("f_link");
            dt_books.Columns.Add("f_price");
            dt_books.Columns.Add("f_discount");

            DataRow row = dt_books.NewRow();
            row["f_id"] = "1";
            row["f_name"] = "I has to say so";
            row["f_desc"] = @"This is the story of the drama relationship between ...";
            row["f_img"] = "i_had_say_so.jpg";
            row["f_author"] = "Mike Jones";
            row["f_info"] = "Seven Stories Press, Dey 14, 1389 AP - Biography & Autobiography - 256 pages";
            row["f_link"] = "https://books.google.com/books?id=8q9hQ5vi3tYC&source=gbs_slider_cls_metadata_1021_mylibrary";
            row["f_price"] = "1200";
            row["f_discount"] = "200";
            dt_books.Rows.Add(row);
```
### 3 ) Create View

At the first I create a folder in my project. For example set a name 'MyViews'\
and then create my html file into it example : '../MyViews/tbl_view_1.html.\
**Now** I can design my view by HTML, CSS, ...
```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>

    <style>
        @media screen and (max-width: 900px) {
            #div_h_v_1 {
                overflow: visible;
            }
        }
    </style>
    <div class="fram_1" style="width:200px; min-height:350px; padding:8px;" onclick="ShowBooksDetails('f_id'); return false;">
        <table style="text-align:left;">
            <tr> <td colspan="2"> <center> <img src="../images/f_img" style="max-height:180px;" /> </center> </td> </tr>
            <tr> <td colspan="2"> <h5> f_name </h5> </td> </tr>
            <tr> <td colspan="2"> <h6> f_author </h6> </td> </tr>
            <tr> <td colspan="2" style="font-size:10px;"> f_info </td> </tr>
            <tr>
                
               =[
                    if(f_discount>0)
                    {
                        "<td style='text-align:center; color:#a0a0a0; text-decoration:line-through;'>";;f_price;;"</td><td>";;"£";;(f_price-f_discount);;"</td>";;
                    }
                    else
                    {
                        "<td>";;"£";;f_price;;"</td><td></td>";;
                    }
                ]
                
                
            </tr>
        </table>
    </div>

</body>
</html>

```
> You can use the formula into your html file\
Please pay attention to it:\
=[   if(f_discount>0)  {  do something }  else  {  do something  }  ]\
**It means that if we have discount for this item in our datas show price minus discount else show price**\
=[   if(f_discount>0)  {  (f_price-f_discount);;  }  else  {  "£";;f_price;;  }  ]\

![tblview1](https://www.dropbox.com/s/dypxyfbz45l4568/tbl_view_1.jpg?dl=0)\
[Show View in DropBox](https://www.dropbox.com/s/dypxyfbz45l4568/tbl_view_1.jpg?dl=0)

![tblview1](https://drive.google.com/file/d/1cDU91BZXohVlJcqDJEj5k99_QgMaEGdc/view?usp=drive_link)\
[Show View in Google Drive](https://drive.google.com/file/d/1cDU91BZXohVlJcqDJEj5k99_QgMaEGdc/view?usp=drive_link)

### 4 ) Use below code for convert your model to DataTable

```
DataTable dt_books = Implements.ModelToDataTable
 (
        new string[] {"Id", "Name", "Img", "Desc", "Author", "Link", "Info", "Price", "Discount"}
      , Lbooks
 );
```

### 5 ) we use a dictionary for pass keys and values that must show in our view

```
Dictionary<string, string> KeyVals = new Dictionary<string, string>();
            KeyVals.Add("f_id", "Id");
            KeyVals.Add("f_img", "Img");
            KeyVals.Add("f_name", "Name");
            KeyVals.Add("f_author", "Author");
            KeyVals.Add("f_info", "Info");
            KeyVals.Add("f_price", "Price");
            KeyVals.Add("f_discount", "Discount");
```
> **f_name** is a tag that we have used in our view (tbl_view_1.html file)\
**<tr> <td colspan="2"> <h5> f_name </h5> </td> </tr>**\
and Name is the value of our class (Name is a property of 'DataBooks' class)\
DataBooks books1 = new DataBooks();\
books1.Id = "1";\
books1.Name = "I has to say so";

# Table View
### 6 ) Pass params and create your **Table View** and show result
```
AtomicItemsLib.TableView tableView = new AtomicItemsLib.TableView(dt_books, KeyVals, 0);
div_table_view.InnerHtml = tableView.TableCreatorFromViewNoPaging(ItemView, "css_books", "books_items");
```

> If you had added 10 or more item to your datas\
Now you should have something like this

![TableViewPage](https://www.dropbox.com/s/miky5dge8nkod25/table_view.jpg?dl=0)\
[Show Page Image in DropBox](https://www.dropbox.com/s/miky5dge8nkod25/table_view.jpg?dl=0)

![TableViewPage](https://drive.google.com/file/d/15GWmINJ1sS6jKehDd3LB97HDwBPWYZGW/view?usp=drive_link)\
[Show Page Image in Google Drive](https://drive.google.com/file/d/15GWmINJ1sS6jKehDd3LB97HDwBPWYZGW/view?usp=drive_link)

# Horizontal View

### Create another view for our settings items
```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>

    <style>
        @media screen and (max-width: 900px) {
            #div_h_v_0 {
                overflow:visible;
            }
        }
    </style>
    <div class="fram_1" style="width:120px; border-radius:50px; padding:8px; margin:4px 8px 4px 8px; font-weight:bold;" >
        <center>
            <table style="text-align:left;">
                <tr>
                    <td>
                        <center> <img src="../images/f_img" style="width:24px;" /> </center>
                    </td>
                    <td style="width:5px;"></td>
                    <td>  f_name  </td>
                </tr>
            </table>
        </center>
    </div>

</body>
</html>
```
> You can use **ModelToDataTable** method from **Implements** class for convert your model to DataTable\
The Images are in **Image** folder of our progect
```
string ItemView = Implements.GetView(Server.MapPath("MyViews/SettingView.html"));

DataTable dt_settings = Implements.ModelToDataTable
 (
        new string[] {"Id", "Name", "Img", "Desc", "Author", "Link", "Info", "Price", "Discount"}
      , Lbooks
 );
Dictionary<string, string> KeyVals = new Dictionary<string, string>();
KeyVals.Add("f_id", "f_id");
KeyVals.Add("f_img", "f_img");
KeyVals.Add("f_name", "f_name");

AtomicItemsLib.ListView lv = new AtomicItemsLib.ListView(dt_settings, KeyVals, 0);
string books_str = lv.HorizontalScrollListView(ItemView, "div_h_v_0");
string result = "<div id='' style='overflow-x:auto; padding:0px; z-index:10000;'>" + books_str + "</div>";
div_horizontal_view_0.InnerHtml = result;
```
### Display books horizontally
```
DataBooks DataBook = new DataBooks();
DataTable dt_books = DataBook.GetBooks();

string ItemView = Implements.GetView(Server.MapPath("MyViews/tbl_View_1.html"));

Dictionary<string, string> KeyVals = new Dictionary<string, string>();
KeyVals.Add("f_id", "f_id");
KeyVals.Add("f_img", "f_img");
KeyVals.Add("f_name", "f_name");
KeyVals.Add("f_author", "f_author");
KeyVals.Add("f_info", "f_info");
KeyVals.Add("f_price", "f_price");
KeyVals.Add("f_discount", "f_discount");

AtomicItemsLib.ListView lv = new AtomicItemsLib.ListView(dt_books, KeyVals, 0);
string books_str = lv.HorizontalScrollListView(ItemView, "div_h_v_1");
string result = "<div id='' style='overflow-x:auto; padding:0px; z-index:10000;'>" + books_str + "</div>";
div_horizontal_view_1.InnerHtml = result;
```
> you can move items horizontally

![HorizontalViewPage](https://www.dropbox.com/s/8fgw6tq4wijdxoy/horizontal_view.jpg?dl=0)\
[Show Page Image in DropBox](https://www.dropbox.com/s/8fgw6tq4wijdxoy/horizontal_view.jpg?dl=0)

![HorizontalViewPage](https://drive.google.com/file/d/1qnFQ5fjMNEqqjbg9sc693gbCRW8t7Uyk/view?usp=sharing)\
[Show Page Image in Google Drive](https://drive.google.com/file/d/1qnFQ5fjMNEqqjbg9sc693gbCRW8t7Uyk/view?usp=sharing)

![HorizontalViewPageResponsive](https://drive.google.com/file/d/1T2IniKLX-C287Ej6DTsmbxl9iAoWsOWG/view?usp=sharing)\
[Show Responsive Page Image in Google Drive](https://drive.google.com/file/d/1T2IniKLX-C287Ej6DTsmbxl9iAoWsOWG/view?usp=sharing)

# Grid View

### Our View
```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>

    <td> f_id </td>
    <td> f_name </td>
    <td> f_author </td>
    <td> f_info </td>
    <td onclick="ShowBookEdit('f_id','f_name','f_author','f_info'); return false;"> 
        <img src="../images/icons/ic_edit_64.png" style="width:18px;" /> 
    </td>
    <td> <img src="../images/icons/ic_delete_64.png" style="width:18px;" /> </td>

</body>
</html>
```
### Our Codes
```
DataBooks Books = new DataBooks();
LBooks = Books.GetBooksList(); // Get all datas that have saved

            dt_books_2 = Implements.ModelToDataTable
                (
                    new string[] { "Id" , "Name" , "Img", "Desc"  , "Author"  , "Link"  , "Info"}
                    , LBooks
                );

string HtmlRow_2 = Implements.GetView(Server.MapPath("MyViews/GridView_2.html"));

Dictionary<string, string> KeyVals_2 = new Dictionary<string, string>();
KeyVals_2.Add("f_id", "Id");
KeyVals_2.Add("f_name", "Name");
KeyVals_2.Add("f_author", "Author");
KeyVals_2.Add("f_info", "Info");

Grid gr = new Grid(new string[] { "#", "Name", "Author", "Info", "", "" }, KeyVals_2, dt_books_2);
div_grid_view_1.InnerHtml = gr.GridCreatorFromView(HtmlRow_2);
```
![GridViewPage](https://www.dropbox.com/s/hjl5ojw0hs8i5rj/grid_view.jpg?dl=0)\
[Show Page Image in DropBox](https://www.dropbox.com/s/hjl5ojw0hs8i5rj/grid_view.jpg?dl=0)

![GridViewPage](https://drive.google.com/file/d/1v-hHaTvXSidQoOs40gROfWmTBoRN7hUe/view?usp=sharing)\
[Show Page Image in Google Drive](https://drive.google.com/file/d/1v-hHaTvXSidQoOs40gROfWmTBoRN7hUe/view?usp=sharing)


# Modal Page

### If you want, can create a html file for your modal page and call it by AJAX JQuery then display that
### Our Modal html file ( BookEditModal.html )

```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>


    <div class="fram_1" style="width:98%; margin:8px 0px 8px 0px;">


        <div style="position:relative; height:40px;">
            <img src="../images/icons/ic_left.png" onclick="ShowHideSmooth('bg_modal','hide'); return false;"
                 style="position:absolute; left:8px; top:5px; width:32px; height:32px; padding:8px;" />
        </div>

        <div class="horizontal_divider_1"></div>

        <div style="margin:8px; padding:8px;">

            <div style="text-align:left; font-weight:bold;"> Name : </div>

            <input id="txt_name" type="text" value="f_name" class="form-control" />

            <div style="text-align:left; font-weight:bold;"> Author : </div>

            <input id="txt_author" type="text" value="f_author" class="form-control" />

            <div style="text-align:left; font-weight:bold;"> Info : </div>

            <textarea id="txt_info" class="form-control"> f_info </textarea>
     
        </div>

        <div class="horizontal_divider_1"></div>

        <div class="bg_btn_modal_1">

            <div onclick="BookEdit('f_id'); return false;" class="item_btn_modal_1"> 
                Confirm 
            </div>
            <div  class="item_btn_modal_1" style="background-color:#e6e6e6; width:1px; height:50px;"></div>
            <div onclick="ShowHideSmooth('bg_modal','hide'); return false;"  class="item_btn_modal_1">
                Cancel 
            </div>

        </div>

    </div>
    
</body>
</html>
```
### Call a js function for show the modal page
```
function ShowBookEdit(Id, Name, Author, Info) {

    $.ajax({
        type: "POST",
        url: "../GridView.aspx/ShowBookEditModal",
        data: "{'Id':'" + Id + "','Name':'" + Name + "','Author':'" + Author + "','Info':'" + Info + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {

            $("#div_modal").html(msg.d); // This div in our master page
            $("#bg_modal").show('slow'); // This div in our master page

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
```
### ShowBookEditModal WebMethod in GridView.aspx

```
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
```
![ModalViewPage](https://www.dropbox.com/s/mojqwq1m66ldohi/modal_page.jpg?dl=0)\
[Show Page Image in DropBox](https://www.dropbox.com/s/mojqwq1m66ldohi/modal_page.jpg?dl=0)

![ModalViewPage](https://drive.google.com/file/d/1IiiM2nm3-dVMPhtLK4bFDN2QQ9VGzCnr/view?usp=drive_link)\
[Show Page Image in Google Drive](https://drive.google.com/file/d/1IiiM2nm3-dVMPhtLK4bFDN2QQ9VGzCnr/view?usp=drive_link)


# List View
### Our html view

```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>

 
    <div style="background-color:#fff; width:100%;" onclick="ShowCarDetails('f_id'); return false;" >
        <div style="padding:8px;">
            <table style="text-align:left; width:100%;">
                <tr>
                    <td style="width:110px;">
                        <center>
                            <table>
                                <tr>
                                    <td> <center> <img src="../images/icons/f_logo" style="width:40px;" /> </center> </td>
                                </tr>
                                <tr> <td style="text-align:center; font-weight:bold;"> f_company </td> </tr>
                            </table>
                        </center>
                    </td>
                    <td>
                        <table style="width:100%;">
                            <tr> <td style="font-weight:bold;"> f_name </td> </tr>
                            <tr> <td> f_info </td> </tr>
                            <tr> <td> £ f_price </td> </tr>
                        </table> 
                    </td>
                </tr>
            </table>
        </div>
        <div class="horizontal_divider_2"></div>
    </div>

</body>
</html>
```
### The code

```
string ItemView = Implements.GetView(Server.MapPath("MyViews/VerticalView_2.html"));

DataCar car = new DataCar();
List<DataCar> LCars = new List<DataCar>();

            DataTable dt_cars = Implements.ModelToDataTable
                (
                    new string[]  { "Id" , "Name" , "Img" , "Desc" , "Author" , "Link" , "Info" }
                    , LCars
                );

Dictionary<string, string> KeyVals = new Dictionary<string, string>();
KeyVals.Add("f_id", "f_id");
KeyVals.Add("f_name", "f_name");
KeyVals.Add("f_logo", "f_logo");
KeyVals.Add("f_company", "f_company");
KeyVals.Add("f_info", "f_info");
KeyVals.Add("f_price", "f_price");

AtomicItemsLib.ListView lv = new AtomicItemsLib.ListView(dt_cars, KeyVals, 0);
div_cars_bg.InnerHtml = lv.CreateVerticalListviewFromView(ItemView);
```

![ListViewPage](https://www.dropbox.com/s/yokw37b6p4h51vd/list_view_mobile.jpg?dl=0)\
[Show Page Image in DropBox](https://www.dropbox.com/s/yokw37b6p4h51vd/list_view_mobile.jpg?dl=0)

![ListViewPage](https://drive.google.com/file/d/1KDLT8TJ6RYySRQFJE5POYd4o9KkyB4TT/view?usp=sharing)\
[Show Page Image in Google Drive](https://drive.google.com/file/d/1KDLT8TJ6RYySRQFJE5POYd4o9KkyB4TT/view?usp=sharing)

