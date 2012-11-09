var buycar = buycar || {};

buycar.TipMsg = "";
buycar.Submit = function () {
    $("form:first").submit(function () {
        if (buycar.ValidTitle() && buycar.VaildCatagroy() &&
            buycar.ValidPrice() && buycar.ValidChangeGoods() &&
            buycar.ValidArea() && buycar.ValidCity() &&            
            buycar.ValidEmail() &&
            buycar.ValidTag()) {
            return true;
        }
        $('#buyModal').modal('show');
        return false;
    });
};
buycar.ValidTitle = function () {
    var title = $("#title").val();
    if (title == '') {
        buycar.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

buycar.VaildCatagroy = function () {
    var option = $("#catagroy option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        buycar.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

buycar.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    var price = $("#price").val();
    if (price == '') {
        buycar.TipMsg = "价格不能为空";
        return false;
    }
    var result = price.match(regex);
    if (null == result || 0 == result.length) {
        buycar.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}
buycar.ValidChangeGoods = function () {
    if ($("#changegoods").attr("checked") == "checked" && $("changegoodstxt").val() == "") {
        buycar.TipMsg = "您如果想换物，请填写相关信息";
        return false;
    }
    return true;
}

buycar.ValidArea = function () {
    var option = $("#area option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        buycar.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

buycar.ValidCity = function () {
    var option = $("#city option:selected");
    var value = option.attr("value") || 0;
    if (value == 0) {
        buycar.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

buycar.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var email = $("#email").val();
    if (email == '') {
        buycar.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = email.match(regex);
    if (null == result || 0 == result.length) {
        buycar.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

buycar.ValidTag = function () {
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