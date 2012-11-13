var transfercar = transfercar || {};

transfercar.TipMsg = "";
transfercar.Submit = function () {
    $("#transfercarform").submit(function () {
        if (transfercar.ValidTitle() && transfercar.VaildCatagroy() &&
            transfercar.ValidPrice() && transfercar.ValidArea() &&
            transfercar.ValidCity() && transfercar.ValidYear() &&
            transfercar.ValidMileage() && transfercar.ValidFacefile() &&
            transfercar.ValidOtherfile() && transfercar.ValidBadfile() &&
            transfercar.ValidEmail() &&
            transfercar.ValidTag()) {
            transfercar.BuildMVCForm();
            return true;
        }
        $('#transferModal').modal('show');
        return false;
    });
};

transfercar.Title = function () {
    return $("#title").val();
}


transfercar.ValidTitle = function () {
    if (transfercar.Title() == '') {
        transfercar.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}

transfercar.CatagroyId = function () {
    var option = $("#catagroy option:selected");
    return option.attr("value") || 0;
}

transfercar.VaildCatagroy = function () {
    if (transfercar.CatagroyId() == 0) {
        transfercar.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

transfercar.Price = function () {
    return $("#price").val();
}

transfercar.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    if (transfercar.Price() == '') {
        transfercar.TipMsg = "价格不能为空";
        return false;
    }
    var result = transfercar.Price().match(regex);
    if (null == result || 0 == result.length) {
        transfercar.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}

transfercar.AreaId = function () {
    var option = $("#area option:selected");
    return option.attr("value") || 0;
}

transfercar.ValidArea = function () {
    if (transfercar.AreaId() == 0) {
        transfercar.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

transfercar.CityId = function () {
    var option = $("#city option:selected");
    return option.attr("value") || 0;
}

transfercar.ValidCity = function () {
    if (transfercar.CityId() == 0) {
        transfercar.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}

transfercar.Year = function () {
    var option = $("#carYear option:selected");
    return option.attr("value") || 0;
}

transfercar.ValidYear = function () {
    if (transfercar.Year() == 0) {
        transfercar.TipMsg = "请选择生产年份";
        return false;
    }
    return true;
}

transfercar.Mileage = function () {
    var option = $("#carMileage option:selected");
    return option.attr("value") || 0;
}

transfercar.ValidMileage = function () {
    if (transfercar.Mileage() == 0) {
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

transfercar.Email = function () {
    return $("#email").val();
}

transfercar.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    if (transfercar.Email() == '') {
        transfercar.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = transfercar.Email().match(regex);
    if (null == result || 0 == result.length) {
        transfercar.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

transfercar.Tag = function () {
    return $("#tag").val();
}

transfercar.ValidTag = function () {
    return true;
}

transfercar.BuildMVCForm = function () {
    $("#Title").val(transfercar.Title());
    $("#Price").val(transfercar.Price());
    $("#CatagroyId").val(transfercar.CatagroyId());
    $("#AreaId").val(transfercar.AreaId());
    $("#CityId").val(transfercar.CityId());
    $("#CarYear").val(transfercar.Year());
    $("#CarMileage").val(transfercar.Mileage());
    $("#Email").val(transfercar.Email());
    $("#Mark").val(transfercar.Tag());
}

$(document).ready(function () {
    $('#transferModal').on('show', function () {
        $("#tipmsg").text(transfercar.TipMsg);
    });

    $("#transferclose").click(function () {
        $('#transferModal').modal('hide');
    });
});