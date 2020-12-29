RTCWebApp.service("ProjectManagerService",
    function ($http) {
        this.GetProjectList = function () {
            var response = $http({
                method: 'POST',
                url: '/ProjectManager/GetProjectList',
                dataType: "json"
            })
            return response;
        };

        this.GetListUserJoinedProject = function () {
            var response = $http({
                method: 'POST',
                url: '/ProjectManager/GetListUserJoinedProject',
                dataType: "json"
            })
            return response;
        };

        this.GetListUserOwnedProject = function () {
            var response = $http({
                method: 'POST',
                url: '/ProjectManager/GetListUserOwnedProject',
                dataType: "json"
            })
            return response;
        };

        this.GetBGImageList = function () {
            var response = $http({
                method: 'POST',
                url: '/ProjectManager/GetBGImageList',
                dataType: "json"
            })
            return response;
        };

        this.AddProject = function (project) {
            var response = $http({
                method: 'POST',
                url: '/ProjectManager/AddProject',
                data: { project: project },
                dataType: "json"
            })
            return response;
        };

        this.DeleteProject = function (id) {
            var response = $http({
                method: 'POST',
                url: '/ProjectManager/DeleteProject',
                data: { id: id },
                dataType: "json"
            })
            return response;
        };
    },

);
