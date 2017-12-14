var viewModel;

function EditPelletsViewModel() {

    var self = this;
    self.pellets = ko.observableArray();

    var pellet = function (mass, diameter, thickness, resistance) {
        var self = this;
        self.mass = ko.observable(mass);
        self.diameter = ko.observable(diameter);
        self.thickness = ko.observable(thickness);
        self.resistance = ko.observable(resistance);
    };

    self.getPellets = function () {
        self.pellets.removeAll();
        var mixId = $('#mixId').val();
        var URL = 'api/mixes/' + mixId + '/pellets/';
        $.ajax({
            url: URL,
            type: 'GET',
            datatype: "json",
            success: function (data) {
                $.each(data, function (key, value) {
                    self.pellets.push(new pellet(value.Mass, value.Diameter, value.Thickness, value.Resistance));
                });
            },
        });
    }

    self.addPellet = function () { self.pellets.push(new pellet()) };
    self.removePellet = function (pellet) { self.pellets.remove(pellet) };
};

$(document).ready(function () {

    viewModel = new EditPelletsViewModel();

    // bind viewmodel to view
    ko.applyBindings(viewModel);

    // load pellets
    viewModel.getPellets();
});