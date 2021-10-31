$(document).ready(function () {
    var todaysDate = new Date();
    var year = todaysDate.getFullYear();
    var month = ("0" + (todaysDate.getMonth() + 1)).slice(-2);
    var day = ("0" + todaysDate.getDate()).slice(-2);
    var maxDate = (year + "-" + month + "-" + day);
    $('#Admin_DateOfBirth').attr('max', maxDate);
});