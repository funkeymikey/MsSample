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
            var s = $scope;
            $.get("http://localhost/MsSample.Api/Restaurants", function (data) {
                s.Restaurants = data;
            });
        }
        return Controller;
    })();
    MsSample.Controller = Controller;    
})(MsSample || (MsSample = {}));
