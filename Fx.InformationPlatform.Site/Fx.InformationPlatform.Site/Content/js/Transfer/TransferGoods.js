var transfer = transfer || {};

transfer.Submit = function () {
    $("form:first").submit(function () {
        if (transfer.ValidTitle() && transfer.ValidPrice() &&
            transfer.ValidFacefile() && transfer.ValidEmail() &&
            transfer.ValidTag()) {
            return true;
        }
        return false;
    });
};
transfer.ValidTitle = function () {
    var title = $("#title").val();
    if (title == '') {
        return false;
    }
    return true;
}

transfer.ValidPrice = function () {
    var title = $("#price").val();
    if (title == '') {
        return false;
    }
    return true;
}

transfer.ValidFacefile = function () {
    var facefile = $("#facefile");
    if (title == '') {
        return false;
    }
    return true;
}


transfer.ValidEmail = function () {
    var title = $("#email").val();
    if (title == '') {
        return false;
    }
    return true;
}

transfer.ValidTag = function () {
    var title = $("#tag").val();
    if (title.lenght > 128) {
        return false;
    }
    return true;
}


//换物
transfer.Checked = function () {

}



$(document).ready(function () {
    transfer.Submit();
});