var buyhouse = buyhouse || {};

buyhouse.TipMsg = "";
buyhouse.Submit = function () {
    $("#buyhouseform").submit(function () {
        if (buyhouse.ValidTitle() && buyhouse.VaildCatagroy() &&
            buyhouse.ValidPrice() &&
            buyhouse.ValidArea() && buyhouse.ValidCity() &&          
            buyhouse.ValidEmail() &&
            buyhouse.ValidTag()) {
            buyhouse.BuildMVCForm();
            return true;
        }
        $('#buyModal').modal('show');
        return false;
    });
};
buyhouse.Title = function () {
    return $("#title").val();
}


buyhouse.ValidTitle = function () {
    if (buyhouse.Title() == '') {
        buyhouse.TipMsg = "标题不能为空";
        return false;
    }
    return true;
}


buyhouse.CatagroyId = function () {
    var option = $("#catagroy option:selected");
    return option.attr("value") || 0;
}

buyhouse.VaildCatagroy = function () {
    if (buyhouse.CatagroyId() == 0) {
        buyhouse.TipMsg = "请选择物品类别";
        return false;
    }
    return true;
}

buyhouse.Price = function () {
    return $("#price").val();
}

buyhouse.ValidPrice = function () {
    var regex = /^[0-9]*[1-9][0-9]*$/;
    if (buyhouse.Price() == '') {
        buyhouse.TipMsg = "价格不能为空";
        return false;
    }
    var result = buyhouse.Price().match(regex);
    if (null == result || 0 == result.length) {
        buyhouse.TipMsg = "价格必须是正整数";
        return false;
    }
    return true;
}

buyhouse.RoomNumber = function () {
    var option = $("#roomnumber option:selected");
    return option.attr("value") || 0;
}

buyhouse.ValidRoomNumber = function () {
    if (buyhouse.RoomNumber() == 0) {
        buyhouse.TipMsg = "请选择具体的房间数量";
        return false;
    }
    return true;
}

buyhouse.Bill = function () {
    return $("#bill").attr("checked") == "checked";
}

buyhouse.Furniture = function () {
    return $("#furniture").attr("checked") == "checked";
}


buyhouse.AreaId = function () {
    var option = $("#area option:selected");
    return option.attr("value") || 0;
}

buyhouse.ValidArea = function () {
    if (buyhouse.AreaId() == 0) {
        buyhouse.TipMsg = "请选择具体的地区";
        return false;
    }
    return true;
}

buyhouse.CityId = function () {
    var option = $("#city option:selected");
    return option.attr("value") || 0;
}

buyhouse.ValidCity = function () {
    if (buyhouse.CityId() == 0) {
        buyhouse.TipMsg = "请选择详细地址";
        return false;
    }
    return true;
}



buyhouse.Email = function () {
    return $("#email").val();
}

buyhouse.ValidEmail = function () {
    var regex = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    if (buyhouse.Email() == '') {
        buyhouse.TipMsg = "邮箱不能为空";
        return false;
    }
    var result = buyhouse.Email().match(regex);
    if (null == result || 0 == result.length) {
        buyhouse.TipMsg = "请填写正确的邮箱";
        return false;
    }
    return true;
}

buyhouse.Tag = function () {
    return $("#tag").val();
}

buyhouse.ValidTag = function () {
    return true;
}

buyhouse.BuildMVCForm = function () {
    $("#Title").val(buyhouse.Title());
    $("#Price").val(buyhouse.Price());
    $("#CatagroyId").val(buyhouse.CatagroyId());
    $("#AreaId").val(buyhouse.AreaId());
    $("#CityId").val(buyhouse.CityId());
    $("#RoomNumber").val(buyhouse.RoomNumber());
    $("#Bill").attr("checked", $("#bill").attr("checked"));
    $("#HasFurniture").attr("checked", $("#furniture").attr("checked"));
    $("#Email").val(buyhouse.Email());
    $("#Mark").val(buyhouse.Tag());
}

$(document).ready(function () {
    $('#buyModal').on('show', function () {
        $("#tipmsg").text(buyhouse.TipMsg);
    });

    $("#buyclose").click(function () {
        $('#buyModal').modal('hide');
    });
});