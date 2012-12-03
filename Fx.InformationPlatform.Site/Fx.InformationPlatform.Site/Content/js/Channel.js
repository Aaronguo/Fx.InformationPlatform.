$(document).ready(function () {
    var id = document.getElementById('selectcatid').value || 0;
    $("#selectcat > a").eq(id).css("background-color", "rgba(108, 0, 168, 0.28)");//rgba(108, 0, 168, 0.28)
    $("#selectcat  a").each(function () {
        $(this).mouseover(function () {
            $("#selectcat  a").each(function () {
                $(this).css("background-color", "white");
            });
            $(this).css("background-color", "rgba(108, 0, 168, 0.28)");
        }).mouseout(function () {
            $(this).css("background-color", "white");
            $("#selectcat > a").eq(id).css("background-color", "rgba(108, 0, 168, 0.28)");
        });
    });
    $("#selectdetail > div").eq(0).toggleClass("hide");
    $("#selectcat > a").click(function () {
        var indexold = document.getElementById("selectcatindex").value;
        var indexnow = $(this).index();
        if (indexold != indexnow) {
            var prevDiv = $("#selectdetail  div").eq(indexold);
            var currentDiv = $("#selectdetail  div").eq(indexnow);
            prevDiv.toggleClass("hide");
            currentDiv.toggleClass("hide");
            document.getElementById("selectcatindex").value = indexnow;
        }
    });
    if (id > 0) {
        $("#selectcat > a").eq(id).click();
    }
});