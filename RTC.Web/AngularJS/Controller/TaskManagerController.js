
RTCWebApp.controller('TaskManagerController',
    function ($scope, TaskManagerService, $interval, $timeout, $filter, $rootScope, $location) {
        console.log("Inside-Controller access");
        $scope.AllTaskList = [];
        $scope.User = [];
        $scope.TaskList = [];
        $scope.ColumnList = [];
        $scope.TaskDetail = {
            ProjectID: null,
            TaskName: null,
            TaskDescription: null,
            UserID: null,
            FullName: null,
            ParentID: null,
            Type: null,
            Status: null,
            UrlFiles: null,
            DateCreated: null,
            DateModified: null,
        }
        $scope.Dummy = {
            ProjectID: null,
            TaskName: null,
            TaskDescription: null,
            UserID: null,
            FullName: null,
            ParentID: null,
            Type: 2,
            Status: 1,
            UrlFiles: null,
            DateCreated: null,
            DateModified: null,
        }

        $scope.GetTaskList = function (callback1, callback2) {
            if (projectDetailID == null) {
                toastr['error']("Không tìm thấy");
                window.location.href = '/TaskManager/Index';
            }
            var request = TaskManagerService.GetAllList(projectDetailID);
            request.then(function (res) {
                $scope.AllTaskList = res.data.Json;
                $scope.TaskList = $scope.AllTaskList.filter(x => x.Type == 2 && x.Status == 1);
                $scope.ColumnList = $scope.AllTaskList.filter(x => x.Type == 1 && x.Status == -1);
                console.log($scope.AllTaskList);
                console.log($scope.TaskList);
                console.log($scope.ColumnList);
            })
        }

        $scope.Cleartext = function () {
            $scope.Dummy = null;
        }

        $scope.GetColumnID = function (id) {
            $scope.Dummy.ParentID = id;
        }

        $scope.AddTask = function () {
            $scope.Dummy.ProjectID = projectDetailID;
            var text = $scope.Dummy.TaskDescription;
            text = text.replace(/\n\r?/g, '<br />');
            $scope.Dummy.TaskDescription = text;
            var request = TaskManagerService.SubmitTask($scope.Dummy);
            request.then(function (res) {
                if (res.data.IsSuccess) {
                    toastr["success"]("Thêm thẻ thành công !!");
                    $scope.Cleartext();
                    $scope.Init();
                }
                else
                    toastr["error"]("Thêm thẻ thất bại :( ")
            }, function (res) {
                toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
            });
        }

        $scope.UpdateTask = function () {
            $scope.TaskDetail.ProjectID = projectDetailID;
            var text = $scope.TaskDetail.TaskDescription;
            text = text.replace(/\n\r?/g, '<br />');
            $scope.TaskDetail.TaskDescription = text;
            var request = TaskManagerService.SubmitTask($scope.TaskDetail);
            request.then(function (res) {
                if (res.data.IsSuccess) {
                    toastr["success"]("Sửa thẻ thành công !!");
                    $scope.ClearModal();
                    $scope.Init();
                }
                else
                    toastr["error"]("Sửa thẻ thất bại :( ")
            }, function (res) {
                toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
            });
            $('.btn-save').css({ "display": "none" });

        }

        $scope.ClearModal = function () {
           
            $('#modal1').modal("hide");
            $scope.CloseAllEditForm();
            $scope.TaskDetail = null;
        }

        $scope.GoToTaskDetail = function (taskID, column) {
            if (taskID == null) {
                toastr["error"]("Có lỗi xảy ra, không lấy được ID !!");
            }
            else {
                $scope.TaskDetail = null;
                $scope.TaskDetail = angular.copy($scope.TaskList.find(x => x.id == taskID));
                console.log($scope.TaskList);
                $scope.CurrentColumn = column;
            }
        }

        $scope.ConvertToHtml = function (text) {
            var dummy = text;
            dummy = dummy.replace(/\n\r?/g, '<br />');
            text = dummy;
        }

       
        $scope.EditOnClick = function (mark) {
            $('.edit-on-click-' + mark).css({ "display": "none" });
            $('.edit-form-' + mark).css({ "display": "block" });
        }

        $scope.FinishEdit = function (mark) {
            if (mark == 2) {
                var text = $scope.TaskDetail.TaskDescription;
                text = text.replace(/\n\r?/g, '<br />');
                $scope.TaskDetail.TaskDescription = text;
                console.log($scope.TaskDetail.TaskDescription);
            };
            if (mark != 3) {
                $('.edit-form-' + mark).css({ "display": "none" });
                $('.edit-on-click-' + mark).css({ "display": "block" });
            }
            $('.btn-save').css({ "display": "block" });
        }

        $scope.CloseAllEditForm = function () {
            $('.close-all').css({ "display": "none" });
            $('.edit-on-click-1').css({ "display": "block" });
            $('.edit-on-click-2').css({ "display": "block" });
            $('.edit-on-click-3').css({ "display": "block" });
        }

   

        $scope.Init = function () {
            $scope.GetTaskList();
           
        }
        $scope.Init();
        console.log("Controller access");


    
    }
);