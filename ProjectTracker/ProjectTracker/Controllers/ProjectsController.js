
(function () {
    var ProjectsController = function ($scope, Projectservice, $log) {
        var Projects = function (data) {
            $scope.Projects = data;
        };
        $scope.SearchProjects = function (employeeName) {
            Projectservice.SearchProjects(employeeName)
            .then(Projects, errorDetails);
            $log.info('Found Employee which contains - ' + employeeName);
        };
        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };
        Projectservice.Projects().then(Projects, errorDetails);
        $scope.Title = "Project Details Page";
        $scope.EmployeeName = null;
    };

    app.controller("ProjectsController", ["$scope", "ProjectsService", "$log", ProjectsController]);

}());