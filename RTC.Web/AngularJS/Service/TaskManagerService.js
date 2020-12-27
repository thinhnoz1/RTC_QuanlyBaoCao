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

        this.DeleteCol = function (id, listChild) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/DeleteColumn',
                data: {
                    id: id,
                    listChild: listChild,
                },
            })
            return response;
        };

        this.AddWorker = function (listmember) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/AddWorker',
                data: { listmember: listmember },
                dataType: "json"
            })
            return response;
        };

        this.DeleteWorker = function (id) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/RemoveWorker',
                data: { id: id },
            })
            return response;
        };

        this.GetListEmployee = function () {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/GetListEmployee',
                dataType: "json"
            })
            return response;
        };

        this.GetListTaskMember = function (taskID) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/GetListTaskMember',
                data: { taskID: taskID },
                dataType: "json"
            })
            return response;
        };

        this.GetAllListMember = function (projectID) {
            var response = $http({
                method: 'POST',
                url: '/TaskManager/GetAllListMember',
                data: { projectID: projectID },
                dataType: "json"
            })
            return response;
        };
    },

);
