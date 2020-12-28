
RTCWebApp.service("NavBarService",
    function ($http) {
        console.log("NavBarService access");
        this.GetIdentity = function () {
            var response = $http({
                method: "POST",
                url: '/Base/GetIdentity',
                dataType: "json"
            })
            return response;
        };
    },

);