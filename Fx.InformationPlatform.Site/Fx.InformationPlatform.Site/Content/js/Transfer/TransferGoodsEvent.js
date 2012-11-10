var transfergoods = transfergoods || {};

transfergoods.BindGoodsconditonChange = function () {
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

transfergoods.BindChangeGoodsCheckd = function () {
    $("#changegoods").change(function () {
        if ($("#changegoods").attr("checked") == "checked") {
            $("#changegoodsdiv").show();
        }else {
            $("#changegoodstxt").val("");
            $("#changegoodstxt").focus();
            $("#changegoodstxt").blur();
            $("#changegoodsdiv").hide();
        }
    });
}



$(document).ready(function () {
    transfergoods.BindGoodsconditonChange();
    transfergoods.BindChangeGoodsCheckd();
});