$(function () {
    $(".anchorDetail").click(function () {
        var URL = '/Mix/EditPellets';
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: URL,
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
    var table = $('#Pellets');
    var id = table.children('tbody').children('tr').last().attr('id') + 1.0;
    var row = '<tr id=' + id + '>' +
        '<td><input class="text-box single-line" data-val="true" data-val-number="The field Mass must be a number." data-val-required="The Mass field is required." id="item_Mass" name="item.Mass" type="text"</td>' +
        '<td><input class="text-box single-line" data-val="true" data-val-number="The field Mass must be a number." data-val-required="The Mass field is required." id="item_Mass" name="item.Mass" type="text"</td>' +
        '<td><input class="text-box single-line" data-val="true" data-val-number="The field Mass must be a number." data-val-required="The Mass field is required." id="item_Mass" name="item.Mass" type="text"</td>' +
        '<td><input class="text-box single-line" data-val="true" data-val-number="The field Mass must be a number." data-val-required="The Mass field is required." id="item_Mass" name="item.Mass" type="text"</td>' +
        '<td><a href="javascript:deletePellet(' + id + ');" class="anchorDetail">Delete</a></td>' +
        '</tr>';
    table.children('tbody').children('tr').last().after(row);
    var idCheck = table.children('tbody').children('tr').last().attr('id')
}

function updatePellets() {
    //var json = JSON.stringify(objectifyForm($form.serializeArray()));
    var mixId = $('#mixId').val();
    var URL = '/Mix/EditPellets/' + mixId;
    var json = '[{ "Mass": 1.5, "Diameter": 16.015, "Thickness": 2.35, "Resistance": 25.0, "VolumetricCapacity": 0.0, "Density": 0.0 }, { "Mass": 2.5, "Diameter": 16.015, "Thickness": 2.35, "Resistance": 25.0, "VolumetricCapacity": 0.0, "Density": 0.0 }]'
    $.ajax({
        url: URL,
        type: 'post',
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function () {
            $('#myModal').modal('hide');
        },
    });
}

