
RTCWebApp.controller('TaskManagerController',
    function ($scope, TaskManagerService, $interval, $timeout, $filter, $rootScope, $location) {
        console.log("Inside-Controller access");
        $scope.AllTaskList = [];
        $scope.User = [];
        $scope.TaskList = [];
        $scope.ColumnList = [];
        $scope.numColumn = 0;
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
            ColumnOrder: null,
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
            ColumnOrder: null,
        }

        $scope.GetTaskList = function (callback1, callback2) {
            if (projectDetailID == null) {
                toastr['error']("Không tìm thấy");
                /*window.location.href = '/TaskManager/Index';*/
            }
            var request = TaskManagerService.GetAllList(projectDetailID);
            request.then(function (res) {
                $scope.AllTaskList = res.data.Json;
                $scope.TaskList = $scope.AllTaskList.filter(x => x.Type == 2 && x.Status == 1);
                $scope.ColumnList = $scope.AllTaskList.filter(x => x.Type == 1 && x.Status == -1);
                $scope.numColumn = $scope.ColumnList.length;

            })
        }

        $scope.Cleartext = function () {
            $scope.Dummy = null;
        }

        $scope.GetColumnID = function (id) {
            $scope.Dummy.ParentID = id;
        }

        $scope.GetColumnName = function (item) {
            if (item.id == null) {
                toastr["error"]("Có lỗi xảy ra, không lấy được ID !!");
            }
            else {
                $scope.Dummy = null;
                $scope.Dummy = angular.copy(item);
                $scope.CurrentPosition = angular.copy(item.ColumnOrder);
            }
        }

        $scope.AddTask = function (type) {
            if ($scope.Dummy.TaskName == null) {
                toastr["error"]("Vui lòng nhập đủ thông tin trước !! ")
            }
            else {
                $scope.Dummy.ProjectID = projectDetailID;
                if (type == 2 && $scope.Dummy.TaskDescription != null) {
                    var text = $scope.Dummy.TaskDescription;
                    text = text.replace(/\n\r?/g, '<br />');
                    $scope.Dummy.TaskDescription = text;
                }
                if (type == 1) {
                    $scope.Dummy.ParentID = 0;
                    $scope.Dummy.Type = 1;
                    $scope.Dummy.Status = -1;
                    $scope.Dummy.ColumnOrder = $scope.numColumn +1;
                }
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
                if (type == 1) {
                    $scope.ClearAddColForm(4);
                }
            }
        }

        $scope.UpdateTask = function () {
            $scope.TaskDetail.ProjectID = projectDetailID;
            if ($scope.TaskDetail.TaskDescription != null) {
                var text = $scope.TaskDetail.TaskDescription;
                text = text.replace(/\n\r?/g, '<br />');
                $scope.TaskDetail.TaskDescription = text;
            }

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
           /* $scope.AutoAdjustHeight($scope.TaskDetail.ParentID);*/
        }

        $scope.UpdateColumn = function () {
            $scope.Dummy.ProjectID = projectDetailID;
            

            var request = TaskManagerService.EditColumn($scope.Dummy, $scope.CurrentPosition);
            request.then(function (res) {
                if (res.data.IsSuccess) {
                    toastr["success"]("Sửa thẻ thành công !!");
                    $scope.Cleartext();
                    $scope.Init();
                }
                else
                    toastr["error"]("Sửa thẻ thất bại :( ")
            }, function (res) {
                toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
            });
         
            /* $scope.AutoAdjustHeight($scope.Dummy.ParentID);*/
        }

        $scope.ClearModal = function () {
           
            $('#modal1').modal("hide");
            $scope.CloseAllEditForm();
            $scope.TaskDetail = null;
        }

        $scope.GoToTaskDetail = function (item, column) {
            if (item.id == null) {
                toastr["error"]("Có lỗi xảy ra, không lấy được ID !!");
            }
            else {
                $scope.TaskDetail = null;
                $scope.TaskDetail = item;
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

        $scope.ClearAddColForm = function (mark) {
            $('.edit-form-' + mark).css({ "display": "none" });
            $('.edit-on-click-' + mark).css({ "display": "block" });
            $scope.Dummy = null;
        }


        $scope.CloseAllEditForm = function () {
            $('.close-all').css({ "display": "none" });
            $('.edit-on-click-1').css({ "display": "block" });
            $('.edit-on-click-2').css({ "display": "block" });
            $('.edit-on-click-3').css({ "display": "block" });
            $('.edit-on-click-4').css({ "display": "block" });
        }

        $scope.DeleteTask = function (id) {
            var r = confirm("Bạn có muốn xóa thẻ này ??");
            if (r == true) {
                var request = TaskManagerService.DeleteTask(id);
                request.then(function (res) {
                    if (res.data.IsSuccess) {
                        toastr["success"]("Xóa thẻ thành công !!");
                        $scope.Init();
                    }
                    else
                        toastr["error"]("Xóa thẻ thất bại :( ")
                }, function (res) {
                    toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
                });
            } else {
                
            }
        }

        $scope.DeleteCol = function (id) {
            var r = confirm("Bạn có muốn xóa cột này ?? Điều này đồng nghĩa với việc bạn sẽ xóa toàn bộ các thẻ trong cột !!");
            if (r == true) {
                var request = TaskManagerService.DeleteCol(id);
                request.then(function (res) {
                    if (res.data.IsSuccess) {
                        toastr["success"]("Xóa cột thành công !!");
                        $scope.Init();
                    }
                    else
                        toastr["error"]("Xóa cột thất bại :( ")
                }, function (res) {
                    toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
                });
            } else {
                
            }
        }

        $scope.AutoAdjustHeight = function (id, count) {
            if (count > 300) {
                $('.column-' + id).css({ "height": "400px" });
            }
            else {
                $('.column-' + id).css({ "height": "auto" });
            };
        }

        $scope.Init = function () {
            $scope.GetTaskList();
        }
        $scope.Init();
        console.log("Controller access");


    
    }
);
