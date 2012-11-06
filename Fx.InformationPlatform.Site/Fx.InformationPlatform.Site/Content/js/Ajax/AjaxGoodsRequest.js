var AjaxGoods = AjaxGoods || {};

AjaxGoods.GetGoodsConditionData = function () {
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

$(document).ready(function () {  
    AjaxGoods.GetGoodsConditionData();
});