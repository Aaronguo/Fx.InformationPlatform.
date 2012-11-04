$(document).ready(function () {
    //GetArea
    AjaxController.GetAreaData();
    AjaxController.GetGoodsConditionData();


    AjaxController.BindAreaChange();
    AjaxController.BindGoodsconditonChange();
});


var AjaxController = AjaxController || {};
//BindData To Control
AjaxController.GetAreaData = function () {
    $.ajax({
        url: "/Ajax/Aera",
        type: "POST",
        dataType: "json",
        data: {},
        success: function (data) {
            $("#area").html(data);
        },
        error: function () {
            $("#area").html("<option value='0'>服务异常，请稍后刷新重试</option>");
        }
    });
}
AjaxController.GetCityData = function () {
    $.ajax({
        url: "/Ajax/City?areaId=" + $("#area").find("option:selected").val(),
        type: "POST",
        dataType: "json",
        data: {},
        success: function (data) {
            $("#city").html(data);
        },
        error: function () {
            $("#city").html("<option value='0'>服务异常，请稍后刷新重试</option>");
        }
    });
};
AjaxController.GetGoodsConditionData = function () {
    $.ajax({
        url: "/Ajax/GoodsCondition",
        type: "POST",
        dataType: "json",
        data: {},
        success: function (data) {
            $("#goodsconditon").html(data);
        },
        error: function () {
            $("#area").html("<option value='0'>服务异常，请稍后刷新重试</option>");
        }
    });
};

//BindEvent To Control
AjaxController.BindAreaChange = function () {
    $("#area").change(function () {
        var value = $("#area").attr("value") || 0;
        if (value != 0) {
            $("#city").removeClass("hide");
            AjaxController.GetCityData();
        }
        else {
            $("#city").addClass("hide");
        }
    });
};
AjaxController.BindGoodsconditonChange = function () {
    $("#goodsconditon").change(function () {
        var option = $("#goodsconditon option:selected");
        var value = option.attr("value") || 0;
        var extend = option.attr("extend");
        if (value != 0 && extend == "TRUE") {
            $("#goodsextend").attr("placeholder", option.attr("message"));
            //解决因JS修改placeholder导致不能即使刷新placeholder 故清空内容 模式聚焦是失焦流程
            $("#goodsextend").attr("value", "");
            $("#goodsextend").focus();
            $("#goodsextend").blur();
            //最后在显示控件
            $("#goodsextend").show();
        }
        else {
            $("#goodsextend").hide();
        }
    });
}
