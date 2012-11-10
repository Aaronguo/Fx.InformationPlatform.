var transferhouse = transferhouse || {};

transferhouse.TipMsg = "";
transferhouse.Submit = function () {
    $("form:first").submit(function () {
        if (transferhouse.ValidTitle() && transferhouse.VaildCatagroy() &&
            transferhouse.ValidPrice() && transferhouse.ValidRoomnumber()&&
            transferhouse.ValidArea() && transferhouse.ValidCity() &&
            transferhouse.ValidFacefile() &&
            transferhouse.ValidOtherfile() && transferhouse.ValidBadfile() &&
            transferhouse.ValidEmail() &&
            transferhouse.ValidTag()) {
            return true;
        }
        $('#transferModal').modal('show');
        return false;
    });
};
transferhouse.ValidTitle = function () {
    var title = $("#title").val();
    if (title == '') {
        transferhouse.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

transferhouse.VaildCatagroy = function () {
    var option = $("#catagroy option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transferhouse.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

transferhouse.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    var price = $("#price").val();
    if (price == '') {
        transferhouse.TipMsg = "价格不能为空";
        return false;
    }
    var result = price.match(regex);
    if (null == result || 0 == result.length) {
        transferhouse.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}

transferhouse.ValidRoomnumber = function () {
    var option = $("#roomnumber option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transferhouse.TipMsg = "请选择具体的房间数量";
        return false;
    }
    return true;
}

transferhouse.ValidArea = function () {
    var option = $("#area option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transferhouse.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

transferhouse.ValidCity = function () {
    var option = $("#city option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transferhouse.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

transferhouse.ValidGoodsconditon = function () {
    var option = $("#goodsconditon option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        transferhouse.TipMsg = "请选择新旧程度";
        return false;
    }
    if (value > 2 && $("#goodsextend").val() == "") {
        transferhouse.TipMsg = "请填写相关新旧程度信息";
        return false;
    }
    return true;
}

transferhouse.ValidFacefile = function () {
    var facefile = $("input[name=facefile]");
    var minlength = $("#mainface").attr("minlength");
    if (facefile.length == 1 && facefile.length != minlength) {
        transferhouse.TipMsg = "请选择物品正面照片";
        return false;
    }
    if (facefile.length < minlength) {
        transferhouse.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}

transferhouse.ValidOtherfile = function () {
    var otherfile = $("input[name=otherfile]");
    var minlength = $("#mainother").attr("minlength");
    if (otherfile.length == 1 && otherfile.length != minlength) {
        transferhouse.TipMsg = "请选择物品其他方位照片";
        return false;
    }
    if (otherfile.length < minlength) {
        transferhouse.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}


transferhouse.ValidBadfile = function () {
    var badfile = $("input[name=badfile]");
    var minlength = $("#mainbad").attr("minlength");
    if (badfile.length == 1 && badfile.length != minlength) {
        transferhouse.TipMsg = "请选择磨损部位照片";
        return false;
    }
    if (badfile.length < minlength) {
        transferhouse.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}


transferhouse.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var email = $("#email").val();
    if (email == '') {
        transferhouse.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = email.match(regex);
    if (null == result || 0 == result.length) {
        transferhouse.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

transferhouse.ValidTag = function () {
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