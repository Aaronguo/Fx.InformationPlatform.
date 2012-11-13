var transfergoods = transfergoods || {};

transfergoods.TipMsg = "";
transfergoods.Submit = function () {
    $("#transfergoodsform").submit(function () {
        if (transfergoods.ValidTitle() && transfergoods.VaildCatagroy() &&
            transfergoods.VaildPriceAndChangeGooods() &&
            transfergoods.ValidArea() && transfergoods.ValidCity() &&
            transfergoods.ValidGoodsconditon() && transfergoods.ValidFacefile() &&
            transfergoods.ValidOtherfile() && transfergoods.ValidBadfile() &&
            transfergoods.ValidEmail() &&
            transfergoods.ValidTag()) {
            transfergoods.BuildMVCForm();
            return true;
        }
        //$("input[type='submit']").attr("data-content", transfergoods.TipMsg);
        //$("input[type='submit']").popover('show');
        $('#transferModal').modal('show');        
        return false;
    });
};




transfergoods.Title = function () {
    return $("#title").val();
}

transfergoods.ValidTitle = function () {
    if (transfergoods.Title() == '') {
        transfergoods.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

transfergoods.CatagroyId = function () {
    var option = $("#catagroy option:selected");
    return option.attr("value") || 0;
}

transfergoods.VaildCatagroy = function () {
    if (transfergoods.CatagroyId() == 0) {
        transfergoods.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

transfergoods.Price = function () {
    return $("#price").val();
}

transfergoods.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    if (transfergoods.Price() == '') {
        transfergoods.TipMsg = "价格不能为空";
        return false;
    }
    var result = transfergoods.Price().match(regex);
    if (null == result || 0 == result.length) {
        transfergoods.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}

transfergoods.IsChangeGoods = function () {
    return $("#changegoods").attr("checked") == "checked";
}

transfergoods.ChangeGoodsText = function () {
    return $("#changegoodstxt").val();              
}

transfergoods.ValidChangeGoods = function () {
    if (transfergoods.IsChangeGoods() == true && transfergoods.ChangeGoodsText() == "") {
        transfergoods.TipMsg = "您如果想换物，请填写相关信息";
        return false;
    }
    return true;
}

//一个交叉验证的例子 相互依赖
//有 以物换物 和 以价格交换 两个选项 （要求至少勾选一项）
//以物换物若被勾选则
//多出一个文本框供用户填写其想交换的物品。
transfergoods.VaildPriceAndChangeGooods = function () {
    return transfergoods.ValidPrice() || transfergoods.ValidChangeGoods();
}



transfergoods.AreaId = function () {
    var option = $("#area option:selected");
    return option.attr("value") || 0;
}

transfergoods.ValidArea = function () {
    if (transfergoods.AreaId() == 0) {
        transfergoods.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

transfergoods.CityId = function () {
    var option = $("#city option:selected");
    return option.attr("value") || 0;
}

transfergoods.ValidCity = function () {
    if (transfergoods.CityId() == 0) {
        transfergoods.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

transfergoods.GoodsConditonId = function () {
    var option = $("#goodsconditon option:selected");
    return option.attr("value") || 0;
}

transfergoods.GoodsConditionText = function () {
    return $("#goodsextend").val();
}


transfergoods.ValidGoodsconditon = function () {
    if (transfergoods.GoodsConditonId() == 0) {
        transfergoods.TipMsg = "请选择新旧程度";
        return false;
    }
    if (transfergoods.GoodsConditonId() > 2 && transfergoods.GoodsConditionText() == "") {
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
    var minlength = $("#mainbad").attr("minlength");
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

transfergoods.Email = function () {
    return $("#email").val();
}

transfergoods.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    if (transfergoods.Email() == '') {
        transfergoods.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = transfergoods.Email().match(regex);
    if (null == result || 0 == result.length) {
        transfergoods.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

transfergoods.Tag = function () {
    return $("#tag").val();
}

transfergoods.ValidTag = function () {
    return true;
}

//注意Checkbox
transfergoods.BuildMVCForm = function () {
    $("#Title").val(transfergoods.Title());
    $("#Price").val(transfergoods.Price());
    $("#CatagroyId").val(transfergoods.CatagroyId());
    $("#IsChangeGoods").attr("checked",$("#changegoods").attr("checked"));
    $("#ChangeGoodsMsg").val(transfergoods.ChangeGoodsText());
    $("#AreaId").val(transfergoods.AreaId());
    $("#CityId").val(transfergoods.CityId());
    $("#GoodConditionId").val(transfergoods.GoodsConditonId());
    $("#GoodConditonMsg").val(transfergoods.GoodsConditionText());
    $("#Email").val(transfergoods.Email());
    $("#Mark").val(transfergoods.Tag());   
}

$(document).ready(function () {
    $('#transferModal').on('show', function () {
        $("#tipmsg").text(transfergoods.TipMsg);
    });

    $("#transferclose").click(function () {
        $('#transferModal').modal('hide');
    });
});
