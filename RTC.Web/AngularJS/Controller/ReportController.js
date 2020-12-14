
RTCWebApp.controller('ReportController',
    function ($scope, ReportService, $interval, $timeout, $filter, $rootScope, $location) {
        console.log("Inside-Controller access");
        $scope.ProjectList = [];
        $scope.User = [];
        $scope.TodayReport = [];
       /* $scope.ListReportName = [];*/
        $scope.check = null;
        $scope.ReportDetail = {
            ProjectID : null,
            WorkDetail : null,
            WorkFinished : null,
            ProblemRemained : null,
            ExpectedSolution : null,
            ProjectCode : null,
            NextDayWork : null,
            Note : null
        }

        $scope.Test = function () {
            var request = ReportService.Check();
            request.then(function (res) {
                $scope.TodayReport = res.data.Json;
                console.log($scope.TodayReport);
                if ($scope.TodayReport == null) {
                    $scope.check = null;
                }
                else {
                    $scope.check = $scope.TodayReport.length;
                }
                /*var list = [];
                $scope.TodayReport.forEach(function (item) {
                    list = $scope.ProjectList.find(x => x.ProjectID == item.ProjectID);
                    console.log(list);
                    $scope.ListReportName.push(list.ProjectCode + " " + list.ProjectName)
                });*/
            })
        }

       

        $scope.GetProjectList = function () {
            var request = ReportService.GetProjectList();
            request.then(function (res) {
                $scope.ProjectList = res.data.Json;

            })
        }

        $scope.GetUserInfo = function () {
            var request = ReportService.GetUserInfo();
            request.then(function (res) {
                $scope.User = res.data.Json;
            })
        }

        $scope.Cleartext = function () {
            $scope.ReportDetail = null;
        }

        $scope.Submit = function () {
            console.log($scope.ReportDetail);
            if ($scope.ReportDetail.ProjectID != null && $scope.ReportDetail.WorkDetail != null) {
                var list = $scope.ProjectList.find(x => x.ProjectID == $scope.ReportDetail.ProjectID);
                $scope.ReportDetail.ProjectCode = list.ProjectCode;
                var request = ReportService.SubmitForm($scope.ReportDetail);
                request.then(function (res) {
                    if (res.data.IsSuccess) {
                        toastr["success"]("Gửi báo cáo thành công !!");
                        $scope.Cleartext();
                    }
                    else
                        toastr["error"]("Gửi bảo cáo thất bại :( ")
                }, function (res) {
                    toastr["error"]("Có lỗi do hệ thống xảy ra, bạn đen lắm");
                });
            }
            else if ($scope.ReportDetail.ProjectID == null) {
                toastr["error"]("Vui lòng chọn dự án mà bạn làm !");
            }
            else {
                toastr["error"]("Vui lòng hoàn thành đầy đủ báo cáo !");
            }
        }


        $scope.Init = function () {
            $scope.GetProjectList();
            $scope.GetUserInfo();
            $scope.Test();
        }
        $scope.Init();
        console.log("Controller access");
    }
);