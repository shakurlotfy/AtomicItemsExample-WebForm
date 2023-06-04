

function ShowBooksDetails(BooksId) {

    $.ajax({
        type: "POST",
        url: "../TableView.aspx/BookDetails",
        data: "{'Id':'" + BooksId + "'}",
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

function ShowCarDetails(CarId) {

    $.ajax({
        type: "POST",
        url: "../VerticalViewMobile.aspx/CarDetails",
        data: "{'Id':'" + CarId + "'}",
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

function VerticalSettings(name) {
    alert(name);
}


