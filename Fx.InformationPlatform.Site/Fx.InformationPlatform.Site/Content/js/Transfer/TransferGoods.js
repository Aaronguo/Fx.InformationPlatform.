var transfer = transfer || {};

transfer.TipMsg = "";
transfer.Submit = function () {
    $("form:first").submit(function () {
        if (transfer.ValidTitle() && transfer.VaildCatagroy() &&
            transfer.ValidPrice() &&
            transfer.ValidChangeGoods() && transfer.ValidArea() &&
            transfer.ValidCity() && transfer.ValidGoodsconditon() &&
            transfer.ValidFacefile() && transfer.ValidEmail() &&
            transfer.ValidTag()) {
            return true;
        }
        $("input[type='submit']").attr("data-content", transfer.TipMsg);
        $("input[type='submit']").popover('show');
        return false;
    });
};
transfer.ValidTitle = function () {
    var title = $("#title").val();
    if (title == '') {
        transfer.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

transfer.VaildCatagroy = function () {
    var option = $("#catagroy option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfer.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

transfer.ValidPrice = function () {
    var regex = "^[0-9]*[1-9][0-9]*$";
    var price = $("#price").val();
    if (price == '') {
        transfer.TipMsg = "价格不能为空";
        return false;
    }
    var result = price.match(regex);
    if (null == result || 0 == result.length) {
        transfer.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}
transfer.ValidChangeGoods = function () {
    if ($("#changegoods").attr("checked") == "checked" && $("changegoodstxt").val() == "") {
        transfer.TipMsg = "您如果想换物，请填写相关信息";
        return false;
    }
    return true;
}

transfer.ValidArea = function () {
    var option = $("#area option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfer.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

transfer.ValidCity = function () {
    var option = $("#city option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfer.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

transfer.ValidGoodsconditon = function () {
    var option = $("#goodsconditon option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfer.TipMsg = "请选择新旧程度";
        return false;
    }
    if (value > 2 && $("#goodsextend").val() == "") {
        transfer.TipMsg = "请填写相关新旧程度信息";
        return false;
    }
    return true;
}

transfer.ValidFacefile = function () {
    var facefile = $("input[name=facefile]");
    if (facefile.length == 1) {
        transfer.TipMsg = "请选择物品正面图片";
        return false;
    }
    return true;
}


transfer.ValidEmail = function () { 
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var email = $("#email").val();
    if (email == '') {
        transfer.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = email.match(regex);
    if (null == result || 0 == result.length) {
        transfer.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

transfer.ValidTag = function () {
    var tag = $("#tag").val();
    //if (tag == '') {
    //    return false;
    //}
    return true;
}

$(document).ready(function () {
    transfer.Submit();
});