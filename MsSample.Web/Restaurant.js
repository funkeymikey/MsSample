var restaurants = angular.module('Restaurants', ['ngResource']);

//register the path to our RESTful api as a constant to be used for dependency injection elsewhere
restaurants.constant('ApiPath', 'http://localhost\\:56174/Restaurants/:id')

//create the $resource object which will communicate with our RESTful api.
//factory = created once, only when necessary
restaurants.factory('RestaurantApi', function ($resource, ApiPath) {
    return $resource(ApiPath);
});

//all the logic for our page
restaurants.controller('RestaurantCtrl', function ($scope, RestaurantApi) {
    $scope.restaurants = RestaurantApi.query();

    
    $scope.setCurrentRestaurant = function (restaurantId) {
        $scope.currentRestaurant = RestaurantApi.get({ id: restaurantId });
    };
});

$(function () {

    jQuery.support.cors = true;
    $.connection.hub.url = 'http://localhost:56174/signalr';

    var chat = $.connection.restaurantHub;

    // Declare a function on the chat hub so the server can invoke it          
    chat.client.addMessage = function (message) {
        $('#messages').append('<li>' + message + '</li>');
    };

    // Start the connection
    $.connection.hub.start().done(function () {
        $("#broadcast").click(function () {
            // Call the chat method on the server
            chat.server.send($('#msg').val());
        });
    });
});