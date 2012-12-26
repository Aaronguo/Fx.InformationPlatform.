var AjaxBase = AjaxBase || {};
//BindData To Control
AjaxBase.GetCityData = function () {
    var index = $("#area").find("option:selected").val();
    if (!$("#publish").data(index)) {
        $.ajax({
            url: "/Ajax/City?areaId=" + $("#area").find("option:selected").val(),
            type: "POST",
            dataType: "json",
            data: {},
            success: function (data) {
                $("#publish").data(index, data);
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

AjaxBase.AjaxPrivateMessage = function () {
    var privatetxt = $("#privatetxt").val();
    var infoId = $("#infoid").val();
    var channelCatagroy = $("#channelCatagroy").val();
    if (privatetxt == "") {
        alert("请输入要发送私信的内容");
    }
    else {
        $.ajax({
            url: "/AjaxPost/PrivateMessage?infoId=" + infoId + "&privateTxt=" + privatetxt + "&channelCatagroy=" + channelCatagroy,
            type: "POST",
            dataType: "json",
            data: {},
            success: function (data) {
                alert(data);
            },
            error: function () {
                alert("请登录后在尝试发送私信");
            }
        });
    }
}





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
    //AjaxBase.GetAreaData();

    AjaxBase.BindAreaChange();
});