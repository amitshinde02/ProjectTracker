(function () {
    var ProjectService = function ($http) {


        var projects = function () {
            return $http.get("http://localhost:30574/api/ptProjects").then(function (serviceResp) {
                return serviceResp.data;
            })
        };

        var searchProjects = function (ProjectName) {
            return $http.get("http://localhost:30574/api/ptProjects/" + ProjectName).
            then(function (serviceResp) {
                return serviceResp.data;
            });
        };

        return {
            Projects: projects,
            SearchProjects: searchProjects
        };

    };
    var module = angular.module("ProjectTrackingModule");
    module.factory("ProjectsService", ['$http', ProjectService]);

}());