
RTCWebApp.controller('ReportAdminController',
    function ($scope, ReportAdminService, $interval, $timeout, $filter, $rootScope, $location) {
        console.log("Inside-Controller access");
        $scope.ProjectList = [];
        $scope.User = [];
        $scope.TodayReport = [];
        $scope.TodayReportList = [];
        /* $scope.ListReportName = [];*/
        $scope.check = null;
        $scope.ReportDetail = {
            ProjectID: null,
            WorkDetail: null,
            WorkFinished: null,
            ProblemRemained: null,
            ExpectedSolution: null,
            ProjectCode: null,
            NextDayWork: null,
            Note: null
        }

        // Shorten a string to less than maxLen characters without truncating words.
        function shorten(str, maxLen, separator = ' ') {
            if (str.length <= maxLen) return str;
            return str.substr(0, str.lastIndexOf(separator, maxLen));
        }

        $scope.GetTodayReport = function () {
            var request = ReportAdminService.Check();
            request.then(function (res) {
                $scope.TodayReport = res.data.Json;
                /*console.log($scope.TodayReport);*/
                $scope.TodayReportList = angular.copy($scope.TodayReport);

                if ($scope.TodayReport == null) {
                    $scope.check = null;

                }
                else {
                    $scope.check = $scope.TodayReport.length;
                    for (var i = 0; i < $scope.TodayReport.length; i++) {
                        $scope.TodayReport[i].DateCreated = moment($scope.TodayReport[i].DateCreated).format("DD/MM/YYYY");
                        if ($scope.TodayReport[i].WorkDetail.length > 20)
                            $scope.TodayReport[i].WorkDetail = shorten($scope.TodayReport[i].WorkDetail, 20) + ' ...';

                        if ($scope.TodayReport[i].WorkFinished.length > 20)
                            $scope.TodayReport[i].WorkFinished = shorten($scope.TodayReport[i].WorkFinished, 20) + ' ...';

                        if ($scope.TodayReport[i].ProblemRemained.length > 20)
                            $scope.TodayReport[i].ProblemRemained = shorten($scope.TodayReport[i].ProblemRemained, 20) + ' ...';

                        if ($scope.TodayReport[i].ExpectedSolution.length > 20)
                            $scope.TodayReport[i].ExpectedSolution = shorten($scope.TodayReport[i].ExpectedSolution, 20) + ' ...';

                        if ($scope.TodayReport[i].NextDayWork.length > 20)
                            $scope.TodayReport[i].NextDayWork = shorten($scope.TodayReport[i].NextDayWork, 20) + ' ...';

                        if ($scope.TodayReport[i].Note.length > 20)
                            $scope.TodayReport[i].Note = shorten($scope.TodayReport[i].Note, 20) + ' ...';

                    }
                    console.log($scope.TodayReport);
                }
                /*var list = [];
                $scope.TodayReport.forEach(function (item) {
                    list = $scope.ProjectList.find(x => x.ProjectID == item.ProjectID);
                    console.log(list);
                    $scope.ListReportName.push(list.ProjectCode + " " + list.ProjectName)
                });*/
            })
        }


        /*
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
        */

        $scope.Init = function () {
            /* $scope.GetProjectList();
             $scope.GetUserInfo();*/
            $scope.GetTodayReport();
        }
        $scope.Init();
        console.log("Controller access");
    }
);