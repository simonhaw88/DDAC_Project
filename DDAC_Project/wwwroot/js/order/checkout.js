window.addEventListener("load", function () {
    computeTotal();
    
    $('.select_cart_item').change(function () {
        computeTotal();
    });

    $(".checkout-submit").click(function (e) {

        if ($('.select_cart_item:input[type=checkbox]:checked').length == 0) {
            e.preventDefault();
            alert("You have not selected any items for checkout");
        }
    });

    $(".remove-cart-item").click(function () {
        var cartItemId = $(this).data("id");
        var url = $(this).data("url");
        var thisElement = $(this);
        $.ajax({
            type: "GET",
            url: url + cartItemId,
            dataType: 'json',
            success: function (data) {
                if (data.status == "success") {
                    thisElement.parent().parent().remove();
                    computeTotal();
                }

            },
            error: function (xhr) {
                if (xhr.status == 419) {
                    location.reload();
                }

            }
        });
    });
    function computeTotal() {
        var sum_amount = 0;
        var count_items = 0;
        $('.select_cart_item:input[type=checkbox]:checked').each(function () {
            count_items = $('.select_cart_item:input[type=checkbox]:checked').length;
            var price = $(this).parent().parent().find(".order-price").find("p").data("value");
            var quantity = $(this).parent().parent().find(".order-quantity").find("p").data("value");
            sum_amount = sum_amount + (price * quantity);
        });

        $(".total_amount").text("RM " + sum_amount.toFixed(2));
            $("#total_item").text(count_items);
        
    }
});