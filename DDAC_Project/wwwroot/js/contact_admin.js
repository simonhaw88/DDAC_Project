$(document).ready(function () {
    $("#contat_admin").click(function () {
        var modal = $("#adminProfile");
        var url = $(this).data("url");
        $.ajax({
            type: "GET",
            url: url,
            data: { "email": email },
            dataType: 'json',
            success: function (data) {
                 
            },
            error: function (xhr) {
                if (xhr.status == 419) {
                    location.reload();
                }

            }
        });
        $("#adminProfile").modal("show");
    });
});