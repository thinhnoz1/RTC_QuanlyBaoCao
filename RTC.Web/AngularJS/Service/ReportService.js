

RTCWebApp.service("ReportService",
    function ($http) {
        this.GetBlogManagementWithFilter = function (listCategoryId, status) {
            var response = $http({
                method: 'POST',
                url: '/Administrator/GetBlogListWithFilter',
                data: { categoriesID: listCategoryId, status: status },
                dataType: "json"
            })
            return response;
        };

        this.GetAllWithPaged = function () {

        }
    }
);
