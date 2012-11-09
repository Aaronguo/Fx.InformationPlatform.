var AjaxBase = AjaxBase || {};
//BindData To Control
AjaxBase.GetAreaData = function () {
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
AjaxBase.GetCityData = function () {
    var index = $("#area").find("option:selected").val();
    if (!$("#publish").data(index)) {
        $.ajax({
            url: "/Ajax/City?areaId=" + $("#area").find("option:selected").val(),
            type: "POST",
            dataType: "json",
            data: {},
            success: function (data) {
                $("#publish").data(index,data);
                $("#city").html(data);
            },
            error: function () {
                $("#city").html("<option value='0'>服务异常，请稍后刷新重试</option>");
            }
        });
    }
    else {
        $("#city").html($("#publish").data(index));
    }
};


//BindEvent To Control
AjaxBase.BindAreaChange = function () {
    $("#area").change(function () {
        var value = $("#area").attr("value") || 0;
        if (value != 0) {
            $("#city").removeClass("hide");
            AjaxBase.GetCityData();
        }
        else {
            $("#city").addClass("hide");
        }
    });
};
$(document).ready(function () {
    //GetArea
    AjaxBase.GetAreaData();

    AjaxBase.BindAreaChange();
});