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

        this.DeleteTask = function (id) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/DeleteTask',
                data: { id: id},
            })
            return response;
        };
    },

);
