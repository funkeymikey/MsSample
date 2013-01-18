/// <reference path="TypeScript Definitions/jquery/jquery-1.9.d.ts" />
/// <reference path="TypeScript Definitions/angularjs/angular-1.0.d.ts" />


angular.service('MsSample', function ($resource) {
    return $resource('api/wines/:wineId', {}, {
        update: {method:'PUT'}
    });
});



module MsSample {
    
export class Controller {
    constructor($scope) {
        $scope.Name = "poopykins";

        $scope.Restaurants = [{ Name: "one" }, { Name: "two" }];
        var s = $scope;
        $.get("http://localhost/MsSample.Api/Restaurants",
            function (data) {
                s.Restaurants = data;
            }
        );

    }
}
}