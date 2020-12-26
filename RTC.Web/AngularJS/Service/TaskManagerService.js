RTCWebApp.service("TaskManagerService",
    function ($http) {
        this.GetAllList = function (projectID) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/GetTaskList',
                data: { projectID: projectID },
                dataType: "json"
            })
            return response;
        };

        this.SubmitTask = function (task) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/SubmitTask',
                data: { task: task },
                dataType: "json"
            })
            return response;
        };

        this.EditColumn = function (task, current) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/EditColumn',
                data: { task: task, current: current },
                dataType: "json"
            })
            return response;
        };

        this.DeleteTask = function (id) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/DeleteTask',
                data: { id: id},
            })
            return response;
        };

        this.DeleteCol = function (id) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/DeleteColumn',
                data: { id: id },
            })
            return response;
        };
    },

);
