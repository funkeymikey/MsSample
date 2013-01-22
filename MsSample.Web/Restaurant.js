var restaurants = angular.module('Restaurants', ['ngResource']);

restaurants.controller('RestaurantCtrl', function ($scope, RestaurantApi) {
    $scope.restaurants = RestaurantApi.query();
});

restaurants.factory('RestaurantApi', function ($resource) {
    return $resource('http://localhost/MsSample.Api/Restaurants');
});