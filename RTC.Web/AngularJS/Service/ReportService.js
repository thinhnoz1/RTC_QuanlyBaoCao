

RTCWebApp.service("ReportService",
    function ($http) {
        this.GetProjectList = function () {
            var response = $http({
                method: 'POST',
                url: '/Report/GetProjectList',
                dataType: "json"
            })
            return response;
        };

        this.SubmitForm = function (_reportDetail) {
            var response = $http({
                method: 'POST',
                data: { reportDetail: _reportDetail },
                url: '/Report/SubmitForm',
                dataType: "json"
            })
            return response;
        };

        this.GetUserInfo = function () {
            var response = $http({
                method: 'POST',
                url: '/Report/GetUserInfo',
                dataType: "json"
            })
            return response;
        };

        this.Check = function () {
            var response = $http({
                method: "POST",
                url: '/Report/Check',
                dataType: "json"
            })
            return response;
        };
    },

);
