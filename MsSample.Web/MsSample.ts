/// <reference path="TypeScript Definitions/jquery/jquery-1.9.d.ts" />
/// <reference path="TypeScript Definitions/angularjs/angular-1.0.d.ts" />

module MsSample {
    
export class Controller {
    constructor($scope) {
        $scope.Name = "poopykins";

        $scope.Restaurants = [{ Name: "one" }, { Name: "two" }];

        $.get("http://localhost:54647/Restaurants",
            function (data) {
                $scope.Restaurants = data;
            }
        );

    }
}
}