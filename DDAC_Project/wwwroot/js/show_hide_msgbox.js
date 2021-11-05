window.addEventListener("load", function () {
    if ($(".success-msg").text().length != 0) {
        $("#msg-success").removeClass("d-none");
        $("#msg-success").delay(1500).fadeOut(500)
    } else if ($(".fail-msg").text().length != 0) {
        $("#msg-fail").removeClass("d-none");
        $("#msg-fail").delay(1500).fadeOut(500)
    };
});