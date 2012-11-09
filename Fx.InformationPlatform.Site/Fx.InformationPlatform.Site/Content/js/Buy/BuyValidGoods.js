var buygoods = buygoods || {};

buygoods.TipMsg = "";
buygoods.Submit = function () {
    $("form:first").submit(function () {
        if (buygoods.ValidTitle() && buygoods.VaildCatagroy() &&
            buygoods.ValidPrice() && buygoods.ValidChangeGoods() &&
            buygoods.ValidArea() && buygoods.ValidCity() &&
            buygoods.ValidGoodsconditon() && buygoods.ValidFacefile() &&
            buygoods.ValidOtherfile() && buygoods.ValidBadfile() &&
            buygoods.ValidEmail() &&
            buygoods.ValidTag()) {
            return true;
        }
        $('#buyModal').modal('show');
        return false;
    });
};
buygoods.ValidTitle = function () {
    var title = $("#title").val();
    if (title == '') {
        buygoods.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

buygoods.VaildCatagroy = function () {
    var option = $("#catagroy option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        buygoods.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

buygoods.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    var price = $("#price").val();
    if (price == '') {
        buygoods.TipMsg = "价格不能为空";
        return false;
    }
    var result = price.match(regex);
    if (null == result || 0 == result.length) {
        buygoods.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}
buygoods.ValidChangeGoods = function () {
    if ($("#changegoods").attr("checked") == "checked" && $("changegoodstxt").val() == "") {
        buygoods.TipMsg = "您如果想换物，请填写相关信息";
        return false;
    }
    return true;
}

buygoods.ValidArea = function () {
    var option = $("#area option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        buygoods.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

buygoods.ValidCity = function () {
    var option = $("#city option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        buygoods.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

buygoods.ValidGoodsconditon = function () {
    var option = $("#goodsconditon option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        buygoods.TipMsg = "请选择新旧程度";
        return false;
    }
    if (value > 2 && $("#goodsextend").val() == "") {
        buygoods.TipMsg = "请填写相关新旧程度信息";
        return false;
    }
    return true;
}

buygoods.ValidFacefile = function () {
    var facefile = $("input[name=facefile]");
    var minlength = $("#mainface").attr("minlength");
    if (facefile.length == 1 && facefile.length != minlength) {
        buygoods.TipMsg = "请选择物品正面照片";
        return false;
    }   
    if (facefile.length < minlength) {
        buygoods.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}

buygoods.ValidOtherfile = function () {
    var otherfile = $("input[name=otherfile]");
    var minlength = $("#mainother").attr("minlength");
    if (otherfile.length == 1 && otherfile.length != minlength) {
        buygoods.TipMsg = "请选择物品其他方位照片";
        return false;
    }  
    if (otherfile.length < minlength) {
        buygoods.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}


buygoods.ValidBadfile = function () {
    var badfile = $("input[name=badfile]");
    var badfile = $("#mainbad").attr("minlength");
    if (badfile.length == 1 && badfile.length != minlength) {
        buygoods.TipMsg = "请选择磨损部位照片";
        return false;
    }  
    if (badfile.length < minlength) {
        buygoods.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}


buygoods.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var email = $("#email").val();
    if (email == '') {
        buygoods.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = email.match(regex);
    if (null == result || 0 == result.length) {
        buygoods.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

buygoods.ValidTag = function () {
    var tag = $("#tag").val();
    //if (tag == '') {
    //    return false;
    //}
    return true;
}

$(document).ready(function () {
    $('#buyModal').on('show', function () {
        $("#tipmsg").text(transfergoods.TipMsg);
    });

    $("#buyclose").click(function () {
        $('#buyModal').modal('hide');
    });
});