var transferhouse = transferhouse || {};

transferhouse.TipMsg = "";
transferhouse.Submit = function () {
    $("#transferhouseform").submit(function () {
        if (transferhouse.ValidTitle() && transferhouse.VaildCatagroy() &&
            transferhouse.ValidPrice() &&
            transferhouse.ValidArea() && transferhouse.ValidCity() &&
            transferhouse.ValidPostCode() && transferhouse.ValidRoadName() &&
            transferhouse.ValidRoomNumber() &&
            transferhouse.ValidFacefile() &&
            transferhouse.ValidOtherfile() && transferhouse.ValidBadfile() &&
            transferhouse.ValidEmail() &&
            transferhouse.ValidTag()) {
            transferhouse.BuildMVCForm();
            return true;
        }
        $('#transferModal').modal('show');
        return false;
    });
};

transferhouse.Title = function () {
    return $("#title").val();
}


transferhouse.ValidTitle = function () {
    if (transferhouse.Title() == '') {
        transferhouse.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}


transferhouse.PostCode = function () {
    return $("#postcode").val();
}


transferhouse.ValidPostCode = function () {
    if (transferhouse.PostCode() == '') {
        transferhouse.TipMsg = "房屋对应邮编不能为空";
        return false;
    }
    return true;
}

transferhouse.RoadName = function () {
    return $("#roadname").val();
}


transferhouse.ValidRoadName = function () {
    if (transferhouse.RoadName() == '') {
        transferhouse.TipMsg = "详细地址不能为空";
        return false;
    }
    return true;
}

transferhouse.CatagroyId = function () {
    var option = $("#catagroy option:selected");
    return option.attr("value") || 0;
}

transferhouse.VaildCatagroy = function () {
    if (transferhouse.CatagroyId() == 0) {
        transferhouse.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

transferhouse.Price = function () {
    return $("#price").val();
}

transferhouse.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    if (transferhouse.Price() == '') {
        transferhouse.TipMsg = "价格不能为空";
        return false;
    }
    var result = transferhouse.Price().match(regex);
    if (null == result || 0 == result.length) {
        transferhouse.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}

transferhouse.RoomNumber = function () {
    var option = $("#roomnumber option:selected");
    return option.attr("value") || 0;
}

transferhouse.ValidRoomNumber = function () {
    if (transferhouse.RoomNumber() == 0) {
        transferhouse.TipMsg = "请选择具体的房间数量";
        return false;
    }
    return true;
}

transferhouse.Bill = function () {
    return $("#bill").attr("checked") == "checked";
}

transferhouse.Furniture = function () {
    return $("#furniture").attr("checked") == "checked";
}


transferhouse.AreaId = function () {
    var option = $("#area option:selected");
    return option.attr("value") || 0;
}

transferhouse.ValidArea = function () {
    if (transferhouse.AreaId() == 0) {
        transferhouse.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

transferhouse.CityId = function () {
    var option = $("#city option:selected");
    return option.attr("value") || 0;
}

transferhouse.ValidCity = function () {
    if (transferhouse.CityId() == 0) {
        transferhouse.TipMsg = "请选择详细地址";
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


transferhouse.Email = function () {
    return $("#email").val();
}

transferhouse.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    if (transferhouse.Email() == '') {
        transferhouse.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = transferhouse.Email().match(regex);
    if (null == result || 0 == result.length) {
        transferhouse.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

transferhouse.Tag = function () {
    return $("#tag").val();
}

transferhouse.ValidTag = function () {
    return true;
}

transferhouse.BuildMVCForm = function () {
    $("#Title").val(transferhouse.Title());
    $("#Price").val(transferhouse.Price());
    $("#CatagroyId").val(transferhouse.CatagroyId());  
    $("#AreaId").val(transferhouse.AreaId());
    $("#CityId").val(transferhouse.CityId());
    $("#PostCode").val(transferhouse.PostCode());
    $("#RoadName").val(transferhouse.RoadName());
    $("#RoomNumber").val(transferhouse.RoomNumber());
    $("#Bill").attr("checked", $("#bill").attr("checked"));
    $("#HasFurniture").attr("checked", $("#furniture").attr("checked"));    
    $("#Email").val(transferhouse.Email());
    $("#Mark").val(transferhouse.Tag());
}


$(document).ready(function () {
    $('#transferModal').on('show', function () {
        $("#tipmsg").text(transferhouse.TipMsg);
    });

    $("#transferclose").click(function () {
        $('#transferModal').modal('hide');
    });
});