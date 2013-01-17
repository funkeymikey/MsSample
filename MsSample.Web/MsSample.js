var MsSample;
(function (MsSample) {
    var Controller = (function () {
        function Controller($scope) {
            $scope.Name = "poopykins";
            $scope.Restaurants = [
                {
                    Name: "one"
                }, 
                {
                    Name: "two"
                }
            ];
            $.get("http://localhost:54647/Restaurants", function (data) {
                $scope.Restaurants = data;
            });
        }
        return Controller;
    })();
    MsSample.Controller = Controller;    
})(MsSample || (MsSample = {}));
