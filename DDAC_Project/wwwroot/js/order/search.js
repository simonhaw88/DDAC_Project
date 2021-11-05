 
$(document).ready(function () {
    $("#search_order_id").click(function () {
        var input_orderId = $("#order_id_input").val();
        var url = $(this).data("url") + "?order_id=" + input_orderId;
        window.location.replace(url);
    })

    $("#filter").click(function () {
        var start_date = $("#start_date-input").val();
        var end_date = $("#end_date-input").val();
        var order_status = $("#order_status-input").val();
        var url = $(this).data("url");
       
            url = url + "?order_status=" + order_status;
       
        if (start_date && end_date) {
            url =url + "&timeFrom=" + start_date + "&timeTo=" + end_date;
            
        } window.location.replace(url);
       
    })

});