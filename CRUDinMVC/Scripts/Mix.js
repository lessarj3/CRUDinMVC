var TeamDetailPostBackURL = '/Mix/EditPellets';
$(function () {
    $(".anchorDetail").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamDetailPostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                debugger;
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });

    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
});

function deletePellet(id) {
    $('#' + id).fadeOut(1000, function () {
        $('#' + id).remove();
    });
}

function addPellet() {
    var id = $('#Pellets tr:last').attr('id');
    $('#Pellets').append('<tr>New Row</tr>');
}

