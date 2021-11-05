$(document).ready(function () {
    $("#insight-date-filter").click(function () {
        var date = $("#insight-date-input").val();
        var url = $(this).data("url") + "?date_filter=" + date;
        window.location.replace(url);
    });
     
});