
RTCWebApp.controller('ProjectManagerController',
    function ($scope, ProjectManagerService, $interval, $timeout, $filter, $rootScope, $location) {
        console.log("Inside-Controller access");
        $scope.ListUserJoinedProject = [];
        $scope.ListUserOwnedProject = [];
        $scope.ListBGImage = [];
        $scope.Dummy = {
            ProjectCode: null,
            ProjectName: null,
            idImage: null
        }

        $scope.GetListUserJoinedProject = function (callback) {
            var request = ProjectManagerService.GetListUserJoinedProject();
            request.then(function (res) {
                $scope.ListUserJoinedProject = res.data.Json;
                console.log($scope.ListUserJoinedProject);
                console.log('GetListUserJoinedProject exec!');
                if (typeof callback === "function") {
                    callback();
                }
            })
        }

        $scope.GetListUserOwnedProject = function (callback) {
            var request = ProjectManagerService.GetListUserOwnedProject();
            request.then(function (res) {
                $scope.ListUserOwnedProject = res.data.Json;
                console.log($scope.ListUserOwnedProject);
                console.log('GetListUserOwnedProject exec!');
                if (typeof callback === "function") {
                    callback();
                }
            
            })
        }

        $scope.GetAllListBGImage = function (callback) {
            var request = ProjectManagerService.GetBGImageList();
            request.then(function (res) {
                $scope.ListBGImage = res.data.Json;
                console.log('GetAllListBGImage exec!');
                if (typeof callback === "function") {
                    callback();
                }
            })
        }

        $scope.GetListOwnerBGImage = function (callback) {
            $scope.Temp1 = [];

            for (var i = 0; i < $scope.ListUserOwnedProject.length; i++) {
                var x = $scope.ListBGImage.filter(x => x.id == $scope.ListUserOwnedProject[i].idImage);
                $scope.Temp1.push(x[0]);
            }
            $scope.ListBGImageStyle = [];

            for (var i = 0; i < $scope.Temp1.length; i++) {
                $scope.myObj = {
                    "background-image": "url(" + $scope.Temp1[i].src + ")",
                }
                $scope.ListBGImageStyle.push($scope.myObj);
            }
            console.log($scope.ListBGImageStyle);
            console.log('GetListOwnerBGImage exec!');

            if (typeof callback === "function") {
                callback();
            }
        }

        $scope.GetListJoinedBGImage = function (callback) {
            $scope.Temp2 = [];
            for (var i = 0; i < $scope.ListUserJoinedProject.length; i++) {
                var x = $scope.ListBGImage.filter(x => x.id == $scope.ListUserJoinedProject[i].idImage);
                $scope.Temp2.push(x[0]);
            }
            console.log($scope.Temp2);
            $scope.ListBGImageStyle1 = [];

            for (var i = 0; i < $scope.Temp2.length; i++) {
                $scope.myObj = {
                    "background-image": "url(" + $scope.Temp2[i].src + ")",
                }
                $scope.ListBGImageStyle1.push($scope.myObj);
            }
            console.log($scope.ListBGImageStyle1);
            console.log('GetListJoinedBGImage exec!');
            if (typeof callback === "function") {
                callback();
            }
        }

        $scope.GoToProjectDetail = function (id) {
            window.location.href = '/project/' + id;
        }

        $scope.Cleartext = function () {
            $scope.Dummy = {
                ProjectCode: null,
                ProjectName: null,
                idImage: null,
            };
        }

        $scope.CreateProject = function () {
            if ($scope.Dummy.ProjectName != null && $scope.Dummy.ProjectCode != null) {
                $scope.Dummy.idImage = Math.floor(Math.random() * $scope.ListBGImage.length);
                var request = ProjectManagerService.AddProject($scope.Dummy);
                request.then(function (res) {
                    if (res.data.IsSuccess) {
                        toastr["success"]("Thêm dự án thành công !!");
                        $scope.Cleartext();
                        $scope.GetListUserOwnedProject(function () {
                            $scope.GetAllListBGImage($scope.GetListOwnerBGImage());
                        });
                    }
                    else
                        toastr["error"]("Thêm dự án thất bại :( ")
                }, function (res) {
                    toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
                });
            }
            else {
                toastr["error"]("Vui lòng nhập tên và mã dự án trước!")
            }
        }

        $scope.DeleteProject = function (id) {
            var request = ProjectManagerService.DeleteProject(id);
            request.then(function (res) {
                if (res.data.IsSuccess) {
                    toastr["success"]("Xóa dự án thành công !!");
                    $scope.GetListUserOwnedProject(function () {
                        $scope.GetAllListBGImage($scope.GetListOwnerBGImage());
                    });
                }
                else
                    toastr["error"]("Thêm dự án thất bại :( ")
            }, function (res) {
                toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
            });
        }

        $scope.Init = function () {
            $scope.GetListUserOwnedProject(function () {
                $scope.GetListUserJoinedProject(function () {
                    $scope.GetAllListBGImage(function () {
                        $scope.GetListOwnerBGImage(function () {
                            $scope.GetListJoinedBGImage();
                        });
                    });
                });
            });
        }
        $scope.Init();
    }
);