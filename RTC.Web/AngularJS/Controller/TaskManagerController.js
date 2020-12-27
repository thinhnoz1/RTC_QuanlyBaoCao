
RTCWebApp.controller('TaskManagerController',
    function ($scope, TaskManagerService, $interval, $timeout, $filter, $rootScope, $location) {
        console.log("Inside-Controller access");
        $scope.AllTaskList = [];
        $scope.User = [];
        $scope.TaskList = [];
        $scope.ColumnList = [];
        $scope.MemberList = [];
        $scope.TempList = [];
        $scope.Temp = {
            UserID: null,
            TaskID: null,
            ProjectID: null,
        };

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
                $scope.LatestOrder = Math.max.apply(Math, $scope.ColumnList.map(function (o) { return o.ColumnOrder; }))
            })
        }

        $scope.Cleartext = function () {
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
        }

        $scope.GetColumnID = function (id) {
            $scope.Cleartext();
            $scope.Dummy.ParentID = id;
        }

        $scope.GetColumnName = function (item) {
            if (item.id == null) {
                toastr["error"]("Có lỗi xảy ra, không lấy được ID !!");
            }
            else {
                $scope.Cleartext();
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
                    $scope.Dummy.ColumnOrder = $scope.LatestOrder + 1;
                }
                var request = TaskManagerService.SubmitTask($scope.Dummy);
                request.then(function (res) {
                    if (res.data.IsSuccess) {
                        toastr["success"]("Thêm thẻ thành công !!");
                        $scope.Cleartext();
                        $scope.GetTaskList();
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
                }
                else
                    toastr["error"]("Sửa thẻ thất bại :( ")
            }, function (res) {
                toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
            });
            if ($scope.TempList.length > 0) {
                var request = TaskManagerService.AddWorker($scope.TempList);
                request.then(function (res) {
                    if (res.data.IsSuccess) {
                        toastr["success"]("Giao việc thành công !!");
                        $scope.ClearModal();
                        $scope.ClearTempList();
                        $scope.Init();
                    }
                    else {
                        toastr["error"]("Giao việc thất bại :( ");
                        $scope.ClearTempList();
                    }
                }, function (res) {
                    toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
                });
            }
            else {
                $scope.GetTaskList();
            }
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
                    $scope.GetTaskList();
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
            $scope.ClearTempList();
            $scope.TaskDetail = null;
            $scope.thisTaskID = null;
        }

        $scope.GoToTaskDetail = function (item, column) {
            if (item.id == null) {
                toastr["error"]("Có lỗi xảy ra, không lấy được ID !!");
            }
            else {
                $scope.TaskDetail = null;
                $scope.TaskDetail = item;
                $scope.CurrentColumn = column;
                $scope.GetListTaskMember(item.id);
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
            $scope.Cleartext();
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
                var listChild = $scope.TaskList.filter(x => x.ParentID == id);
                var request = TaskManagerService.DeleteCol(id, listChild);
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

        $scope.GetEmployeeList = function (callback) {
            var request = TaskManagerService.GetListEmployee();
            request.then(function (res) {
                $scope.EmployeeList = res.data.Json;
                if (typeof callback === "function")
                    callback();
            }, function (res) {
                toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
            });

        }

        $scope.GetListTaskMember = function (taskID) {
            $scope.TaskMemberIDList = [];
            /*$scope.MemberList = [];*/
            if (taskID != null) {
                $scope.TaskMemberIDList = $scope.FirstListTaskMember.filter(x => x.TaskID == taskID)
                if ($scope.TaskMemberIDList != null && $scope.TaskMemberIDList.length > 0) {
                    $scope.AnotherTemp = {
                        id: null,
                        UserID: null,
                        FullName: null,
                        ShortName: null,
                        TaskID: null,
                    };
                    $scope.thisTaskID = taskID;
                }
            }
            else {
                toastr["error"]("Không lấy được ID!!");
            }
        }

        $scope.GetFirstListMember = function () {
            $scope.FirstListTaskMember = [];
            $scope.AllMemberList = [];
            var request = TaskManagerService.GetAllListMember(projectDetailID);
            request.then(function (res) {
                $scope.FirstListTaskMember = res.data.Json;
                if ($scope.FirstListTaskMember != null && $scope.FirstListTaskMember.length > 0) {
                    $scope.AnotherTemp1 = {
                        id: null,
                        UserID: null,
                        FullName: null,
                        ShortName: null,
                        TaskID: null,
                    };
                    for (var i = 0; i < $scope.FirstListTaskMember.length; i++) {
                        $scope.AnotherTemp1.TaskID = $scope.FirstListTaskMember[i].TaskID;
                        $scope.AnotherTemp1.UserID = $scope.FirstListTaskMember[i].UserID;
                        $scope.AnotherTemp1.id = $scope.FirstListTaskMember[i].id;
                        var result = $scope.EmployeeList.filter(x => x.UserID == $scope.FirstListTaskMember[i].UserID);
                        $scope.AnotherTemp1.FullName = result[0].FullName;
                        $scope.AnotherTemp1.ShortName = result[0].FullName.substring(0, 2);
                        $scope.AllMemberList.push($scope.AnotherTemp1);
                        $scope.AnotherTemp1 = {
                            id: null,
                            UserID: null,
                            FullName: null,
                            ShortName: null,
                            TaskID: null,
                        };
                    }
                }

            }, function (res) {
                toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
            });
        }

        $scope.AddWorker = function () {
            if ($scope.Temp.UserID != null) {
                if ($scope.TaskMemberIDList.length == 0) {
                    var result2 = $scope.TempList.filter(x => x.UserID == $scope.Temp.UserID);
                    if (result2.length == 0) {
                        $scope.Temp.ProjectID = projectDetailID;
                        $scope.Temp.TaskID = angular.copy($scope.TaskDetail.id);
                        $scope.TempList.push($scope.Temp);
                        $scope.Temp = {
                            UserID: null,
                            TaskID: null,
                            ProjectID: null,
                        };
                    }
                }
                //th nếu result đã có trong MemberList
                //th nếu task đã được giao MemberList != null
                else {
                    var result1 = $scope.TaskMemberIDList.filter(x => x.UserID == $scope.Temp.UserID);
                    if (result1.length == 0) {
                        var result2 = $scope.TempList.filter(x => x.UserID == $scope.Temp.UserID);
                        if (result2.length == 0) {
                            $scope.Temp.ProjectID = projectDetailID;
                            $scope.Temp.TaskID = angular.copy($scope.TaskDetail.id);
                            $scope.TempList.push($scope.Temp);
                            $scope.Temp = {
                                UserID: null,
                                TaskID: null,
                                ProjectID: null,
                            };
                        }

                    }
                }
                $('.btn-save').css({ "display": "block" });
            }
            else {
                toastr["error"]("Vui lòng chọn nhân viên mà bạn muốn thêm trước !");
            }

        }

        $scope.RemoveWorker = function (userID) {
            $scope.TempList = $scope.TempList.filter(x => x.UserID != userID);
        };

        $scope.DeleteWorker = function (id) {
            var r = confirm("Bạn có chắc muốn xóa người này khỏi công việc ? Một khi đã xóa là không thể hoàn tác lại");
            if (r == true) {
                var request = TaskManagerService.DeleteWorker(id);
                request.then(function (res) {
                    if (res.data.IsSuccess) {
                        toastr["success"]("Xóa thành công !!");
                        $scope.GetFirstListMember();
                    }
                    else
                        toastr["error"]("Xóa thất bại :( ")
                }, function (res) {
                    toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
                });
            } else {

            }
        };

        $scope.ClearTempList = function () {
            $scope.Temp = {
                UserID: null,
                TaskID: null,
                ProjectID: null,
            };
            $scope.TempList = [];
        }

        $scope.Init1 = function () {
            $scope.GetTaskList();
        }

        $scope.Init = function () {
            $scope.GetTaskList();
            $scope.GetFirstListMember();
        }
        $scope.GetEmployeeList($scope.Init);
        console.log("Controller access");



    }
);
