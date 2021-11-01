$(document).ready(function () {
    $("#addStaffSubmit").click(function () {
        var url = $(this).data("url");
        var email = $("#staffEmail").val();
        var msg_box = $("#msgBox");
        var msg_text = $("#msg");
        $.ajax({
            type: "POST",
            url: url,
            data: {"email":email},
            dataType: 'json',
            success: function (data) {
                if (data.status == "Success") {
                    msg_text.addClass("alert-success").removeClass("alert-danger");
                    var acc_email = data.acc_email;
                    var acc_password = data.acc_password;
                    $("#accountDetails").removeClass("d-none");
                    $("#emailValue").empty().append(acc_email);
                    $("#passwordValue").empty().append(acc_password);
                } else {
                    msg_text.addClass("alert-danger").removeClass("alert-success");
                }
                msg_box.removeClass("d-none").css({
                    "position": "sticky",
                    "top": "1%",
                    "font-weight": "bold",
                    "text-align": "center"
                });
                msg_text.text(data.message);

                msg_box.fadeIn(500).delay(1500).fadeOut(500);
             },
            error: function (xhr) {
                if (xhr.status == 419) {
                    location.reload();
                }

            }
        });
    });

    $(".getPassword").click(function () {
        var url = $(this).data("url");
        var button = $(this);
        $.ajax({
            type: "GET",
            url: url,
            dataType: 'json',
            success: function (data) {
                button.replaceWith(data.password);
            },
            error: function (xhr) {
                if (xhr.status == 419) {
                    location.reload();
                }

            }
        });
       
    });

    $(".updatestatus").click(function () {
        var url = $(this).data("url");
        var button = $(this);
        var thisElement = $(this);
        var msg_box = $("#globalMsgBox");
        var msg_text = $("#globalMsg");
        var type = $(this).data("type");
        var userStatus;
        var userId = $(this).data("id");
        $.ajax({
            type: "GET",
            url: url,
            dataType: 'json',
            success: function (data) {
                if (data.status == "Success") {
                    msg_text.addClass("alert-success").removeClass("alert-danger");
                    if (type == "deactivate") {
                        thisElement.parent().prev().find(".status").text("Inactive");
                        thisElement.data("type", "activate").data("url", "/user/updatestatus/activate/" + userId);
                        thisElement.removeClass("btn-warning").addClass("btn-success");
                        thisElement.children().attr("class", "fas fa-check-circle");

                    } else {
                        thisElement.parent().prev().find(".status").text("Active");                       
                        thisElement.data("type", "deactivate").data("url", "/user/updatestatus/deactivate/" + userId);
                        thisElement.removeClass("btn-success").addClass("btn-warning");
                        thisElement.children().attr("class", "fas fa-ban");
                    }
                } else {
                    msg_text.addClass("alert-danger").removeClass("alert-success");
                }
                msg_box.removeClass("d-none").css({
                    "position": "sticky",
                    "top": "1%",
                    "font-weight": "bold",
                    "text-align": "center"
                });
                msg_text.text(data.message);
                msg_box.fadeIn(500).delay(1500).fadeOut(500);

            },
            error: function (xhr) {
                if (xhr.status == 419) {
                    location.reload();
                }

            }
        });
    });

    $(".deleteuser").click(function () {
         var url = $(this).data("url");
        var userId = $(this).data("id");
        var msg_box = $(".msgBoxDelete");
        var msg_text = $(".msgDelete");
        $.ajax({
            type: "GET",
            url: url,
            dataType: 'json',
            success: function (data) {
                 if (data.status == "Success") {
                    msg_text.addClass("alert-success").removeClass("alert-danger");
                    var acc_email = data.acc_email;
                    var acc_password = data.acc_password;
                    $("#accountDetails").removeClass("d-none");
                    $("#acc_email").append(acc_email);
                    $("#acc_password").append(acc_password);
                } else {
                    msg_text.addClass("alert-danger").removeClass("alert-success");
                }
                msg_box.removeClass("d-none").css({
                    "position": "sticky",
                    "top": "1%",
                    "font-weight": "bold",
                    "text-align": "center"
                });
                msg_text.text(data.message);

                msg_box.fadeIn(500).delay(1500).fadeOut(500, function () {
                    location.reload();
                });

            },
            error: function (xhr) {
                if (xhr.status == 419) {
                    location.reload();
                }

            }
        });

    })
});

