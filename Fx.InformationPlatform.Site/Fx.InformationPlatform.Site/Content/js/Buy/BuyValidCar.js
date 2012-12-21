var buycar = buycar || {};

buycar.TipMsg = "";
buycar.Submit = function () {
    $("#buycarform").submit(function () {
        if (buycar.ValidTitle() && buycar.VaildCatagroy() &&
            buycar.ValidPrice() && buycar.ValidArea() &&
            buycar.ValidCity() && buycar.ValidYear() &&
            buycar.ValidMileage() && buycar.ValidFacefile() &&
            buycar.ValidOtherfile() && buycar.ValidBadfile() &&
            buycar.ValidEmail() &&
            buycar.ValidTag()) {
            buycar.BuildMVCForm();
            $(":submit").button('loading');
            return true;
        }
        $('#transferModal').modal('show');
        return false;
    });
};

buycar.Title = function () {
    return $("#title").val();
}


buycar.ValidTitle = function () {
    if (buycar.Title() == '') {
        buycar.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

buycar.CatagroyId = function () {
    var option = $("#catagroy option:selected");
    return option.attr("value") || 0;
}

buycar.VaildCatagroy = function () {
    if (buycar.CatagroyId() == 0) {
        buycar.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

buycar.Price = function () {
    return $("#price").val();
}

buycar.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    if (buycar.Price() == '') {
        buycar.TipMsg = "价格不能为空";
        return false;
    }
    var result = buycar.Price().match(regex);
    if (null == result || 0 == result.length) {
        buycar.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}

buycar.AreaId = function () {
    var option = $("#area option:selected");
    return option.attr("value") || 0;
}

buycar.ValidArea = function () {
    if (buycar.AreaId() == 0) {
        buycar.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

buycar.CityId = function () {
    var option = $("#city option:selected");
    return option.attr("value") || 0;
}

buycar.ValidCity = function () {
    if (buycar.CityId() == 0) {
        buycar.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

buycar.Year = function () {
    var option = $("#carYear option:selected");
    return option.attr("value") || 0;
}

buycar.ValidYear = function () {
    if (buycar.Year() == 0) {
        buycar.TipMsg = "请选择生产年份";
        return false;
    }
    return true;
}

buycar.Mileage = function () {
    var option = $("#carMileage option:selected");
    return option.attr("value") || 0;
}

buycar.ValidMileage = function () {
    if (buycar.Mileage() == 0) {
        buycar.TipMsg = "请选择里程数";
        return false;
    }
    return true;
}


buycar.ValidFacefile = function () {
    var facefile = $("input[name=facefile]");
    var minlength = $("#mainface").attr("minlength");
    if (facefile.length == 1 && facefile.length != minlength) {
        buycar.TipMsg = "请选择物品正面照片";
        return false;
    }
    if (facefile.length < minlength) {
        buycar.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}

buycar.ValidOtherfile = function () {
    var otherfile = $("input[name=otherfile]");
    var minlength = $("#mainother").attr("minlength");
    if (otherfile.length == 1 && otherfile.length != minlength) {
        buycar.TipMsg = "请选择物品其他方位照片";
        return false;
    }
    if (otherfile.length < minlength) {
        buycar.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}

buycar.ValidBadfile = function () {
    var badfile = $("input[name=badfile]");
    var minlength = $("#mainbad").attr("minlength");
    if (badfile.length == 1 && badfile.length != minlength) {
        buycar.TipMsg = "请选择其他方位照片2";
        return false;
    }
    if (badfile.length < minlength) {
        buycar.TipMsg = "图片的数量至少是：" + minlength;
        return false;
    }
    return true;
}

buycar.Email = function () {
    return $("#email").val();
}

buycar.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    if (buycar.Email() == '') {
        buycar.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = buycar.Email().match(regex);
    if (null == result || 0 == result.length) {
        buycar.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

buycar.Tag = function () {
    return $("#tag").val();
}

buycar.ValidTag = function () {
    return true;
}

buycar.BuildMVCForm = function () {
    $("#Title").val(buycar.Title());
    $("#Price").val(buycar.Price());
    $("#CatagroyId").val(buycar.CatagroyId());
    $("#AreaId").val(buycar.AreaId());
    $("#CityId").val(buycar.CityId());
    $("#CarYear").val(buycar.Year());
    $("#CarMileage").val(buycar.Mileage());
    $("#Email").val(buycar.Email());
    $("#Mark").val(buycar.Tag());
}

$(document).ready(function () {
    $('#buyModal').on('show', function () {
        $("#tipmsg").text(buycar.TipMsg);
    });

    $("#buyclose").click(function () {
        $('#buyModal').modal('hide');
    });
});