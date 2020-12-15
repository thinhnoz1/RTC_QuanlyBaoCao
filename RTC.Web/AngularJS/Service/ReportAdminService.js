

RTCWebApp.service("ReportAdminService",
    function ($http) {
        /*this.GetProjectList = function () {
            var response = $http({
                method: 'POST',
                url: '/ReportAdmin/GetProjectList',
                dataType: "json"
            })
            return response;
        };

        this.SubmitForm = function (_reportDetail) {
            var response = $http({
                method: 'POST',
                data: { reportDetail: _reportDetail },
                url: '/ReportAdmin/SubmitForm',
                dataType: "json"
            })
            return response;
        };

        this.GetUserInfo = function () {
            var response = $http({
                method: 'POST',
                url: '/ReportAdmin/GetUserInfo',
                dataType: "json"
            })
            return response;
        };*/

        this.Check = function () {
            var response = $http({
                method: "POST",
                url: '/ReportAdmin/Check',
                dataType: "json"
            })
            return response;
        };
    },

);
