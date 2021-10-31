window.addEventListener("load", function () {
    if ($(".success-msg").text().length != 0) {
        $("#msgBox").removeClass("d-none");
        $("#msgBox").delay(1500).fadeOut(500)
    };
});