

function ShowHide(element, type) {
    if (type == 'show') {
        $('#' + element).show();
    }
    else {
        $('#' + element).hide();
    }
}

function ShowHideSmooth(element, type) {
    if (type == 'show') {
        $('#' + element).show('slow');
    }
    else {
        $('#' + element).hide('slow');
    }
}
