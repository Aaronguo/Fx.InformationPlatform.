var buygoods = buygoods || {};

buygoods.TipMsg = "";
buygoods.Submit = function () {
    $("#buygoodsform").submit(function () {
        if (buygoods.ValidTitle() && buygoods.VaildCatagroy() &&
            buygoods.VaildPriceAndChangeGooods() &&
            buygoods.ValidArea() && buygoods.ValidCity() &&
            buygoods.ValidGoodsconditon() && buygoods.ValidFacefile() &&
            buygoods.ValidOtherfile() && buygoods.ValidBadfile() &&
            buygoods.ValidEmail() &&
            buygoods.ValidTag()) {
            buygoods.BuildMVCForm();
            $(":submit").button('loading');
            return true;
        } 
        $('#buyModal').modal('show');
        return false;
    });
};

buygoods.Title = function () {
    return $("#title").val();
}

buygoods.ValidTitle = function () {
    if (buygoods.Title() == '') {
        buygoods.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

buygoods.CatagroyId = function () {
    var option = $("#catagroy option:selected");
    return option.attr("value") || 0;
}

buygoods.VaildCatagroy = function () {
    if (buygoods.CatagroyId() == 0) {
        buygoods.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

buygoods.Price = function () {
    return $("#price").val();
}

buygoods.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    if (buygoods.Price() == '') {
        buygoods.TipMsg = "价格不能为空";
        return false;
    }
    var result = buygoods.Price().match(regex);
    if (null == result || 0 == result.length) {
        buygoods.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}

buygoods.IsChangeGoods = function () {
    return $("#changegoods").attr("checked") == "checked";
}

buygoods.ChangeGoodsText = function () {
    return $("#changegoodstxt").val();
}

buygoods.ValidChangeGoods = function () {
    if (buygoods.IsChangeGoods() == true && buygoods.ChangeGoodsText() == "") {
        buygoods.TipMsg = "您如果想换物，请填写相关信息";
        return false;
    }
    return true;
}

buygoods.VaildPriceAndChangeGooods = function () {
    return buygoods.ValidPrice() || buygoods.ValidChangeGoods();
}

buygoods.AreaId = function () {
    var option = $("#area option:selected");
    return option.attr("value") || 0;
}

buygoods.ValidArea = function () {
    if (buygoods.AreaId() == 0) {
        buygoods.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

buygoods.CityId = function () {
    var option = $("#city option:selected");
    return option.attr("value") || 0;
}

buygoods.ValidCity = function () {
    if (buygoods.CityId() == 0) {
        buygoods.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

buygoods.GoodsConditonId = function () {
    var option = $("#goodsconditon option:selected");
    return option.attr("value") || 0;
}

buygoods.GoodsConditionText = function () {
    return $("#goodsextend").val();
}

buygoods.ValidGoodsconditon = function () {
    if (buygoods.GoodsConditonId() == 0) {
        buygoods.TipMsg = "请选择新旧程度";
        return false;
    }
    if (buygoods.GoodsConditonId() > 2 && buygoods.GoodsConditionText() == "") {
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
    //如果选择了换物 请上传图片
    //if (buygoods.IsChangeGoods() == true && facefile.length == 1) {
    //    buygoods.TipMsg = "如果你选择了换物，请上你交换物品的图片";
    //    return false;
    //}
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
    var minlength = $("#mainbad").attr("minlength");
    if (badfile.length == 1 && badfile.length != minlength) {
        buygoods.TipMsg = "请选择其他方位照片2";
        return false;
    }  
    if (badfile.length < minlength) {
        buygoods.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}

buygoods.Email = function () {
    return $("#email").val();
}

buygoods.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    if (buygoods.Email() == '') {
        buygoods.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = buygoods.Email().match(regex);
    if (null == result || 0 == result.length) {
        buygoods.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

buygoods.Tag = function () {
    return $("#tag").val();
}

buygoods.ValidTag = function () {  
    return true;
}

buygoods.BuildMVCForm = function () {
    $("#Title").val(buygoods.Title());
    $("#Price").val(buygoods.Price());
    $("#CatagroyId").val(buygoods.CatagroyId());
    $("#IsChangeGoods").attr("checked", $("#changegoods").attr("checked"));
    $("#ChangeGoodsMsg").val(buygoods.ChangeGoodsText());
    $("#AreaId").val(buygoods.AreaId());
    $("#CityId").val(buygoods.CityId());
    $("#GoodConditionId").val(buygoods.GoodsConditonId());
    $("#GoodConditonMsg").val(buygoods.GoodsConditionText());
    $("#Email").val(buygoods.Email());
    $("#Mark").val(buygoods.Tag());
}

$(document).ready(function () {
    $('#buyModal').on('show', function () {
        $("#tipmsg").text(buygoods.TipMsg);
    });

    $("#buyclose").click(function () {
        $('#buyModal').modal('hide');
    });
});