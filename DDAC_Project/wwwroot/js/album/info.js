$("#checkout").click(function () {
    var albumId = $(this).data("id");
    var quantity = $("#quantity_input").val();
    var url = $(this).data("url");
    var redirect_url = $(this).data("redirect");
    var login_url = $(this).data("login");
    var msg_box = $("#msgBox");
    var msg_text = $("#msg");
    $.ajax({
        type: "POST",
        url: url,
        data: { "albumId": albumId, "quantity": quantity },
        dataType: 'json',
        success: function (data) {
            if (data.status == "success") {
                var stock = $(".stock").text();
                $(".stock").text(stock - quantity);
                msg_text.addClass("alert-success").removeClass("alert-danger");
                msg_box.fadeIn(500).delay(1500).fadeOut(500, function () {
                    window.location.replace(redirect_url);
                });
               
            } else if (data.status == "user_invalid") {
                return window.location.replace(login_url);
            } else {
                msg_text.addClass("alert-danger").removeClass("alert-success");
                msg_box.fadeIn(500).delay(1500).fadeOut(500);
            }
            msg_box.removeClass("d-none").css({
                "position": "sticky",
                "top": "1%",
                "font-weight": "bold",
                "text-align": "center"
            });
            msg_text.text(data.message);

            
        },
        error: function (xhr) {
            if (xhr.status == 419) {
                location.reload();
            }

        }
    });
});

$("#add_to_cart").click(function () {
    var albumId = $(this).data("id");
    var quantity = $("#quantity_input").val();
    var url = $(this).data("url");
    var login_url = $(this).data("login");
    var msg_box = $("#msgBox");
    var msg_text = $("#msg");
    $.ajax({
        type: "POST",
        url: url,
        data: { "albumId": albumId, "quantity": quantity },
        dataType: 'json',
        success: function (data) {
            if (data.status == "success") {
                var stock = $(".stock").text();
                $(".stock").text(stock - quantity);
                msg_text.addClass("alert-success").removeClass("alert-danger");
                msg_box.fadeIn(500).delay(1500).fadeOut(500);

            } else if (data.status == "user_invalid") {
                return window.location.replace(login_url);
            } else {
                msg_text.addClass("alert-danger").removeClass("alert-success");
                msg_box.fadeIn(500).delay(1500).fadeOut(500);
            }
            msg_box.removeClass("d-none").css({
                "position": "sticky",
                "top": "1%",
                "font-weight": "bold",
                "text-align": "center"
            });
            msg_text.text(data.message);

        },
        error: function (xhr) {
            if (xhr.status == 419) {
                location.reload();
            }

        }
    });
});

$('.btn-number').click(function (e) {
    e.preventDefault();

    fieldName = $(this).attr('data-field');
    type = $(this).attr('data-type');
    var input = $("input[name='" + fieldName + "']");
    var currentVal = parseInt(input.val());
    if (!isNaN(currentVal)) {
        if (type == 'minus') {

            if (currentVal > input.attr('min')) {
                input.val(currentVal - 1).change();
            }
            if (parseInt(input.val()) == input.attr('min')) {
                $(this).attr('disabled', true);
            }

        } else if (type == 'plus') {

            if (currentVal < input.attr('max')) {
                input.val(currentVal + 1).change();
            }
            if (parseInt(input.val()) == input.attr('max')) {
                $(this).attr('disabled', true);
            }

        }
    } else {
        input.val(0);
    }
});
$('.input-number').focusin(function () {
    $(this).data('oldValue', $(this).val());
});
$('.input-number').change(function () {

    minValue = parseInt($(this).attr('min'));
    maxValue = parseInt($(this).attr('max'));
    valueCurrent = parseInt($(this).val());

    name = $(this).attr('name');
    if (valueCurrent >= minValue) {
        $(".btn-number[data-type='minus'][data-field='" + name + "']").removeAttr('disabled')
    } else {
        alert('Sorry, the minimum value was reached');
        $(this).val($(this).data('oldValue'));
    }
    if (valueCurrent <= maxValue) {
        $(".btn-number[data-type='plus'][data-field='" + name + "']").removeAttr('disabled')
    } else {
        alert('Sorry, the maximum value was reached');
        $(this).val($(this).data('oldValue'));
    }
});

$(".input-number").keydown(function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 ||
        // Allow: Ctrl+A
        (e.keyCode == 65 && e.ctrlKey === true) ||
        // Allow: home, end, left, right
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }

  
});


