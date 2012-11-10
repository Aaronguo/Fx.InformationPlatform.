var transfercar = transfercar || {};

transfercar.TipMsg = "";
transfercar.Submit = function () {
    $("form:first").submit(function () {
        if (transfercar.ValidTitle() && transfercar.VaildCatagroy() &&
            transfercar.ValidPrice() && transfercar.ValidArea() && 
            transfercar.ValidCity() && transfercar.ValidYear() &&
            transfercar.ValidMileage() && transfercar.ValidFacefile() &&
            transfercar.ValidOtherfile() && transfercar.ValidBadfile() &&
            transfercar.ValidEmail() &&
            transfercar.ValidTag()) {
            return true;
        }
        $('#transferModal').modal('show');
        return false;
    });
};
transfercar.ValidTitle = function () {
    var title = $("#title").val();
    if (title == '') {
        transfercar.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

transfercar.VaildCatagroy = function () {
    var option = $("#catagroy option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfercar.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

transfercar.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    var price = $("#price").val();
    if (price == '') {
        transfercar.TipMsg = "价格不能为空";
        return false;
    }
    var result = price.match(regex);
    if (null == result || 0 == result.length) {
        transfercar.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}

transfercar.ValidArea = function () {
    var option = $("#area option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfercar.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

transfercar.ValidCity = function () {
    var option = $("#city option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfercar.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

transfercar.ValidYear = function () {
    var option = $("#carYear option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfercar.TipMsg = "请选择生产年份";
        return false;
    }
    return true;
}

transfercar.ValidMileage = function () {
    var option = $("#carMileage option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfercar.TipMsg = "请选择里程数";
        return false;
    }
    return true;
}




transfercar.ValidFacefile = function () {
    var facefile = $("input[name=facefile]");
    var minlength = $("#mainface").attr("minlength");
    if (facefile.length == 1 && facefile.length != minlength) {
        transfercar.TipMsg = "请选择物品正面照片";
        return false;
    }
    if (facefile.length < minlength) {
        transfercar.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}

transfercar.ValidOtherfile = function () {
    var otherfile = $("input[name=otherfile]");
    var minlength = $("#mainother").attr("minlength");
    if (otherfile.length == 1 && otherfile.length != minlength) {
        transfercar.TipMsg = "请选择物品其他方位照片";
        return false;
    }
    if (otherfile.length < minlength) {
        transfercar.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}


transfercar.ValidBadfile = function () {
    var badfile = $("input[name=badfile]");
    var minlength = $("#mainbad").attr("minlength");
    if (badfile.length == 1 && badfile.length != minlength) {
        transfercar.TipMsg = "请选择磨损部位照片";
        return false;
    }
    if (badfile.length < minlength) {
        transfercar.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}


transfercar.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var email = $("#email").val();
    if (email == '') {
        transfercar.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = email.match(regex);
    if (null == result || 0 == result.length) {
        transfercar.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

transfercar.ValidTag = function () {
    var tag = $("#tag").val();
    //if (tag == '') {
    //    return false;
    //}
    return true;
}

$(document).ready(function () {
    $('#transferModal').on('show', function () {
        $("#tipmsg").text(transfergoods.TipMsg);
    });

    $("#transferclose").click(function () {
        $('#transferModal').modal('hide');
    });
});