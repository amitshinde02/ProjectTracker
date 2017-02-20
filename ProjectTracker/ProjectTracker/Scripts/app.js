var app = angular.module('ProjectTrackingModule', ['ngRoute']);
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    
    $routeProvider
        .when("/Home", {
            templateUrl: "/Home.html",
            controller: "HomeController"
        })
        .when("/Projects", {
            templateUrl: "../ProjectManagement/ProjectDetails.html",
            controller: "ProjectsController"
        })

        .when("/Employees", {
            templateUrl: "../Employees/EmployeeDetails.html",
            controller: "EmployeesController"
        })

    .otherwise({ redirectTo: "/ProjectManagement/ProjectDetails.html" });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false,
        hashPrefix: '!'
    });

}]);