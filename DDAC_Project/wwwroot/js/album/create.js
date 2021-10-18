$(document).ready(function () {
    $("#add-track").click(function () {
        var trackCol = $(".track:first").clone();
        var trackAction = $(".track-action:first").clone();

        trackCol.find(".track-input").val("");
        trackAction.empty().append('<i class="fas fa-trash-alt" id="delete-track" style="cursor:pointer;"></i>');

        $(".track-action:last").after(trackCol);
        $(".track:last").after(trackAction)
    });
    $(document).on("click","#delete-track",function () {
        var trackAction = $(this).parent();
        var trackCol = trackAction.prev();
        trackAction.remove();
        trackCol.remove();
       
    });
});