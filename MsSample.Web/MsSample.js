angular.service('Wine', function ($resource) {
    return $resource('http://localhost/MsSample.Api/Restaurants/', {}, {
        update: { method: 'PUT' }
    });
});


function WineListCtrl(Wine) {

    this.wines = Wine.query();

}

function WineDetailCtrl(Wine) {

    this.wine = Wine.get({ wineId: this.params.wineId });


    this.saveWine = function () {
        if (this.wine.id > 0)
            this.wine.$update({ wineId: this.wine.id });
        else
            this.wine.$save();
        window.location = "#/wines";
    }

    this.deleteWine = function () {
        this.wine.$delete({ wineId: this.wine.id }, function () {
            alert('Wine ' + wine.name + ' deleted')
            window.location = "#/wines";
        });
    }

}