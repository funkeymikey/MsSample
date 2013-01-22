var restaurants = angular.module('Restaurants', ['ngResource']);

//register the path to our RESTful api as a constant to be used for dependency injection elsewhere
restaurants.constant('ApiPath', 'http://localhost/MsSample.Api/Restaurants/:id')

//create the $resource object which will communicate with our RESTful api.
//factory = created once, only when necessary
restaurants.factory('RestaurantApi', function ($resource, ApiPath) {
    return $resource(ApiPath);
});

//all the logic for our page
restaurants.controller('RestaurantCtrl', function ($scope, RestaurantApi) {
    $scope.restaurants = RestaurantApi.query();

    
    $scope.showData = function (restaurantId) {
        $scope.currentRestaurant = RestaurantApi.get({ id: restaurantId });
    };
});


