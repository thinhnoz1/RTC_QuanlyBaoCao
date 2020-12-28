
console.log("NavBarService exec done!");
RTCWebApp.controller('NavBarController',
    function ($scope, NavBarService) {
        console.log("NavBarController access");

        $scope.GetIdentity = function () {
            var request = NavBarService.GetIdentity();
            request.then(function (res) {
                $scope.Identity = res.data.Json;
            })
        }


        $scope.Init = function () {
            $scope.GetIdentity();
        }
        $scope.Init();
    }
);