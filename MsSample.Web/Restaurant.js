var restaurants = angular.module('Restaurants', ['ngResource']);

//register the path to our RESTful api as a constant to be used for dependency injection elsewhere
restaurants.constant('ApiSource', 'http://localhost\\:56174/Restaurants/:id');
restaurants.constant('SignalRSource', 'http://localhost:56174/signalr');

//create the $resource object which will communicate with our RESTful api.
//factory = created once, only when necessary
restaurants.factory('RestaurantApi', function ($resource, ApiSource) {
    return $resource(ApiSource);
});

//all the logic for our page
restaurants.controller('RestaurantCtrl', function ($scope, RestaurantApi, SignalRSource) {
    $scope.restaurants = RestaurantApi.query();

    $scope.setCurrentRestaurant = function (restaurantId) {
        $scope.currentRestaurant = RestaurantApi.get({ id: restaurantId });
    };

    $scope.saveNewRestaurant = function () {
        RestaurantApi.save($scope.newRestaurant);
        $scope.newRestaurant = {};
    };

    jQuery.support.cors = true;
    $.connection.hub.url = SignalRSource;

    // Declare a function on the hub so the server can invoke it          
    $.connection.restaurantHub.client.refreshList = function (message) {
        $scope.restaurants = RestaurantApi.query();
    };

    // Start the connection
    $.connection.hub.start();

});
