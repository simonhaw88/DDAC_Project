
$(document).ready(function () {

    $("#filter").click(function () {
        var start_date = $("#start_date-input").val();
        var end_date = $("#end_date-input").val();
        var order_status = $("#order_status-input").val();
        var url = $(this).data("url");

        url = url + "?order_status=" + order_status;

        if (start_date && end_date) {
            url = url + "&timeFrom=" + start_date + "&timeTo=" + end_date;

        } window.location.replace(url);

    })

    var message = $(".field-validation-error").text();
    if (message != null) {

        $(".field-validation-error").fadeIn(500).delay(1500).fadeOut(500);
    }

});