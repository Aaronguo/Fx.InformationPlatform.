var transfergoods = transfergoods || {};

transfergoods.TipMsg = "";
transfergoods.Submit = function () {
    $("form:first").submit(function () {
        if (transfergoods.ValidTitle() && transfergoods.VaildCatagroy() &&
            transfergoods.ValidPrice() && transfergoods.ValidChangeGoods() &&
            transfergoods.ValidArea() && transfergoods.ValidCity() &&
            transfergoods.ValidGoodsconditon() && transfergoods.ValidFacefile() &&
            transfergoods.ValidOtherfile() && transfergoods.ValidBadfile() &&
            transfergoods.ValidEmail() &&
            transfergoods.ValidTag()) {
            return true;
        }
        //$("input[type='submit']").attr("data-content", transfergoods.TipMsg);
        //$("input[type='submit']").popover('show');
        $('#transferModal').modal('show');
        return false;
    });
};
transfergoods.ValidTitle = function () {
    var title = $("#title").val();
    if (title == '') {
        transfergoods.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

transfergoods.VaildCatagroy = function () {
    var option = $("#catagroy option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfergoods.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

transfergoods.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    var price = $("#price").val();
    if (price == '') {
        transfergoods.TipMsg = "价格不能为空";
        return false;
    }
    var result = price.match(regex);
    if (null == result || 0 == result.length) {
        transfergoods.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}
transfergoods.ValidChangeGoods = function () {
    if ($("#changegoods").attr("checked") == "checked" && $("changegoodstxt").val() == "") {
        transfergoods.TipMsg = "您如果想换物，请填写相关信息";
        return false;
    }
    return true;
}

transfergoods.ValidArea = function () {
    var option = $("#area option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfergoods.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

transfergoods.ValidCity = function () {
    var option = $("#city option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfergoods.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

transfergoods.ValidGoodsconditon = function () {
    var option = $("#goodsconditon option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transfergoods.TipMsg = "请选择新旧程度";
        return false;
    }
    if (value > 2 && $("#goodsextend").val() == "") {
        transfergoods.TipMsg = "请填写相关新旧程度信息";
        return false;
    }
    return true;
}

transfergoods.ValidFacefile = function () {
    var facefile = $("input[name=facefile]");
    var minlength = $("#mainface").attr("minlength");
    if (facefile.length == 1 && facefile.length != minlength) {
        transfergoods.TipMsg = "请选择物品正面照片";
        return false;
    }
    if (facefile.length < minlength) {
        transfergoods.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}

transfergoods.ValidOtherfile = function () {
    var otherfile = $("input[name=otherfile]");
    var minlength = $("#mainother").attr("minlength");
    if (otherfile.length == 1 && otherfile.length != minlength) {
        transfergoods.TipMsg = "请选择物品其他方位照片";
        return false;
    }
    if (otherfile.length < minlength) {
        transfergoods.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}


transfergoods.ValidBadfile = function () {
    var badfile = $("input[name=badfile]");
    var badfile = $("#mainbad").attr("minlength");
    if (badfile.length == 1 && badfile.length != minlength) {
        transfergoods.TipMsg = "请选择磨损部位照片";
        return false;
    }
    if (badfile.length < minlength) {
        transfergoods.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}


transfergoods.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var email = $("#email").val();
    if (email == '') {
        transfergoods.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = email.match(regex);
    if (null == result || 0 == result.length) {
        transfergoods.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

transfergoods.ValidTag = function () {
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
