$(document).ready(function () {
    var message = $(".field-validation-error").text();
    if (message != null) {
 
        $(".field-validation-error").fadeIn(500).delay(1500).fadeOut(500);
    }
});