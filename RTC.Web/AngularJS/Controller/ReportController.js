/// <reference path="../../scripts/_references.js" />
/// <reference path="../../scripts/angular.js" />

var RTCWeb = angular.controller('blogManagementController',
    function ($scope, blogManagementService, $interval, $timeout, $filter, $rootScope, $location) {
        $scope.CurrentBlogList = [];
        $scope.ListCategoryManagement = [];
        $scope.ListCategoryId = [];
        $scope.HastagValue = "";
        $scope.BlogTitle = "";
        $scope.CategoryId = "";
        $scope.BlogDetail = {};
        $scope.DefaultBlogDetail = { Id: 0, CategoryId: "", BlogTitle: "", BlogContent: "", Hastag: "", Status: 1, CreatedDate: "", UpdatedDate: "", ImageUrl: "", SubDescription: "" };
        $scope.obj = [];
        $scope.FilterBlog = [];
        $scope.ListFilterBlog = [];
        $scope.ListOptionCategory = [];
        $scope.IsActive = [];
        $scope.ListStatusAsOne = [];
        $scope.ListStatusAsTwo = [];
        $scope.SelectFilterBlog = function (item, status) {
            var objfilter = { Id: item.Id, Value: item.CategoryKey };
            var statusvalue = status;
            var checkIndex = $scope.FilterBlog.findIndex(x => x.Id == objfilter.Id);
            if (checkIndex > -1) {
                $scope.FilterBlog.splice(checkIndex, 1);
            }
            else {
                $scope.FilterBlog.push(objfilter);
            }
            $scope.GetBlogByFilterValue(statusvalue);
        };
        $scope.GetBlogByFilterValue = function (statusvalue) {
            var listId = [];
            $scope.FilterBlog.forEach(function (item) {
                listId.push(item.Id)
            });
            if (listId.length == 0) {
                $scope.ListFilterBlog = angular.copy($scope.CurrentBlogList);
                $scope.ListFilterBlog.forEach(function (item) {
                    item.BlogContent = (item.SubDescription != null && item.SubDescription.length > 250)
                        ? item.SubDescription.substr(0, 250) + ' ...' : item.SubDescription;

                    if (item.Hastag != null && item.Hastag != undefined && item.Hastag != '')
                        item.Hastag = angular.fromJson(item.Hastag);

                    item.CreatedDate = moment(item.CreatedDate).format("DD/MM/YYYY");
                });
            }
            else {
                var request = blogManagementService.GetBlogManagementWithFilter(listId, statusvalue);
                request.then(function (res) {
                    $scope.ListFilterBlog = res.data.Json.blogList;
                    $scope.ListFilterBlog.forEach(function (item) {
                        item.BlogContent = (item.SubDescription != null && item.SubDescription.length > 250)
                            ? item.SubDescription.substr(0, 250) + ' ...' : item.SubDescription;

                        if (item.Hastag != null && item.Hastag != undefined && item.Hastag != '')
                            item.Hastag = angular.fromJson(item.Hastag);

                        item.CreatedDate = moment(item.CreatedDate).format("DD/MM/YYYY");
                    });
                })
            }
        };
        $scope.RemoveFilterItem = function (item) {
            var index = $scope.FilterBlog.findIndex(x => x.Id == item.Id);
            if (index > -1)
                $scope.FilterBlog.splice(index, 1);
            $('#' + item.Id).prop('checked', false);
            $scope.GetBlogByFilterValue();
        };
        $scope.GetInfoblog = function (id) {
            var request = blogManagementService.GenerateBlogModal(id);
            var today = new Date();
            request.then(function (res) {
                $scope.DefaultBlogDetail = res.data.Json;
                $('#summernote').summernote('code', $scope.DefaultBlogDetail.SubDescription);
                if ($scope.DefaultBlogDetail.Hastag != null && $scope.DefaultBlogDetail.Hastag != undefined && $scope.DefaultBlogDetail.Hastag != '')
                    $scope.ListHastagAdd = angular.fromJson($scope.DefaultBlogDetail.Hastag);
                else
                    $scope.ListHastagAdd = [];
                $('#selected-menublog').val($scope.DefaultBlogDetail.CategoryId);
                $('#CreateBlog').addClass('d-none');
                $('#SaveBlog').removeClass('d-none');
                $("#modal-create-blog").modal('show');
            })
        };
        $scope.SaveBlogModal = function () {
            $scope.BlogDetail.Id = $scope.DefaultBlogDetail.Id;
            $scope.BlogDetail.CategoryId = $('#selected-menublog').val();
            $scope.BlogDetail.BlogTitle = $scope.DefaultBlogDetail.BlogTitle;
            $scope.BlogDetail.BlogContent = "";
            $scope.BlogDetail.Status = $scope.DefaultBlogDetail.Status;
            $scope.BlogDetail.Hastag = angular.toJson($scope.ListHastagAdd);
            $scope.BlogDetail.SubDescription = $('#summernote').summernote('code');
            $scope.BlogDetail.ImageUrl = $scope.DefaultBlogDetail.ImageUrl;
            $scope.BlogDetail.CreatedDate = $scope.DefaultBlogDetail.CreatedDate;
            var request = blogManagementService.SaveBlogModal($scope.BlogDetail);
            request.then(function (res) {
                toastr["success"](res.Message);
                location.reload();
            });
        };
        $scope.RefreshForm = function () {
            $('#CreateBlog').removeClass('d-none');
            $('#SaveBlog').addClass('d-none');
            $scope.DefaultBlogDetail.CategoryId = 0;
            $('#selected-menublog').val($scope.DefaultBlogDetail.CategoryId);
            $scope.DefaultBlogDetail.BlogTitle = null;
            $scope.ListHastagAdd = [];
            $scope.DefaultBlogDetail.Hastag = null;
            $scope.DefaultBlogDetail.Status = 1;
            $scope.DefaultBlogDetail.BlogContent = null;
            $scope.DefaultBlogDetail.ImgUrl = null;
            $scope.DefaultBlogDetail.CreatedDate = null;
            $scope.DefaultBlogDetail.UpdatedDate = null;
            $scope.DefaultBlogDetail.SubDescription = null;
            $('#summernote').summernote('code', null);
        };
        $scope.GetBlogManagementWithFilter = function () {
            var ManagementCategory = [];
            ManagementCategory.push(3);
            var request = blogManagementService.GetBlogManagementWithFilter(ManagementCategory);
            request.then(function (res) {
                $('.modal-footer').append('<button type="button" id="test" class="btn btn-info btn-pills waves-effect waves-themed" style="background:#2196F3;border-color:#2196F3">Insert Image</button>');
                $('.modal-dialog .note-image-btn').addClass('d-none');
                $('button[data-original-title="Picture"]').click(function () {
                    $('.modal-dialog .note-image-url').val($scope.DefaultBlogDetail.ImageUrl);
                    $('.modal-dialog #test').click(function () {
                        $('[aria-label="Insert Image"]').modal('hide');
                        $scope.DefaultBlogDetail.ImageUrl = $('.modal-dialog .note-image-url').val();
                    });
                });
                $scope.CurrentBlogList = res.data.Json.blogList;
                $scope.ListCategoryManagement = res.data.Json.blogManagement;
                $scope.ListOptionCategory = angular.copy($scope.ListCategoryManagement);
                $scope.IsActive = angular.copy($scope.CurrentBlogList);
                $scope.ListFilterBlog = angular.copy($scope.CurrentBlogList);
                $scope.ListFilterBlog.forEach(function (item) {
                    item.BlogContent = (item.SubDescription != null && item.SubDescription.length > 250)
                        ? item.SubDescription.substr(0, 250) + ' ...' : item.SubDescription;

                    if (item.Hastag != null && item.Hastag != undefined && item.Hastag != '')
                        item.Hastag = angular.fromJson(item.Hastag);

                    item.CreatedDate = moment(item.CreatedDate).format("DD/MM/YYYY");
                });
            },
                function (res) {
                });
        };
        $scope.ListHastagAdd = [];
        $scope.AddHashTag = function () {
            var object = { Value: $scope.HastagValue };
            $scope.ListHastagAdd.push(object);
            $scope.HastagValue = "";
        };
        $scope.RemoveHastag = function (ListHastagAdd, value) {
            var index = $scope.ListHastagAdd.findIndex(x => x.Value == value);
            $scope.ListHastagAdd.splice(index, 1);
        };
        $scope.OpenConfirmRemove = function (BlogId) {
            $('#btn-delete-blog').val(BlogId);
            $('#confirm-remove').modal("show");
        };
        $scope.DeleteBlog = function () {
            var BlogId = $('#btn-delete-blog').val();
            var model = {
                Id: BlogId,
                Status: 3,
            };
            var request = blogManagementService.DeleteBlog(model);
            request.then(function (res) {
                toastr["success"]("Xóa bài thành công!");
                location.reload();
            })
        };
        $scope.OpenConfirmAdd = function (BlogId) {
            $('#btn-confirmadd-blog').val(BlogId);
            $('#confirm-add').modal("show");
        };
        $scope.AddBlog = function () {
            var BlogId = $('#btn-confirmadd-blog').val();
            var model = {
                Id: BlogId,
                Status: 2,
            };
            var request = blogManagementService.UpdateBlogByStatus(model);
            request.then(function (res) {
                toastr["success"]("Đã đăng!");
                location.reload();
            })
        };
        $scope.OpenRemoveConfirmAdd = function (BlogId) {
            $('#btn-confirmremoveadd-blog').val(BlogId);
            $('#confirm-remove-add').modal("show");
        }
        $scope.RemoveBlog = function () {
            var BlogId = $('#btn-confirmremoveadd-blog').val();
            var model = {
                Id: BlogId,
            };
            var request = blogManagementService.RemoveBlogById(model);
            request.then(function (res) {
                toastr["success"]("Đã gỡ bỏ bài viết!");
                location.reload();
            })
        };
        $scope.CreateBlog = function () {
            var today = new Date();
            $scope.BlogDetail.CategoryId = $('#selected-menublog').val();
            $scope.BlogDetail.BlogTitle = $scope.DefaultBlogDetail.BlogTitle;
            $scope.BlogDetail.Hastag = angular.toJson($scope.ListHastagAdd);
            $scope.BlogDetail.Status = $scope.DefaultBlogDetail.Status;
            $scope.BlogDetail.ImageUrl = $('.modal-dialog .note-image-url').val();
            $scope.BlogDetail.BlogContent = $('#summernote').summernote('code');
            $scope.BlogDetail.CreatedDate = moment(today).format("DD/MM/YYYY");
            $scope.BlogDetail.UpdatedDate = moment(today).format("DD/MM/YYYY");
            $scope.BlogDetail.SubDescription = $('#summernote').summernote('code');
            var request = blogManagementService.CreateBlogModal($scope.BlogDetail);
            request.then(function (res) {
                toastr["success"]("Đăng bài thành công!");
                location.reload();
            })
            $scope.RefreshForm();
        };
        $scope.Init = function () {
            $scope.GetBlogManagementWithFilter();
        }
        $scope.ConvertDatetime = function (time) {
            return moment(time).format("DD/MM/YYYY - HH:mm:ss")
        }
        $scope.Init();
    });