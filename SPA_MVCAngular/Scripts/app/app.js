/// <reference path="../angular.js" />
var StudentModule = angular.module("StudentApp",
            ["ngRoute", "stucontroller", "sturesources",
            "studetailscontroller"]);
StudentModule.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
        .when('/home', {
            templateUrl: 'templates/students.html',
            controller: 'GetStudentsList'
        })       
        .when('/addstu', {
            templateUrl: 'templates/addstudent.html',
            controller: 'AddStudent'
        })
        .when('/studetails/:id', {
            templateUrl: 'templates/studentdetails.html',
            controller: 'StuDetails'
        })
        .when('/addstudetails/:id', {
            templateUrl: 'templates/addstudentdetails.html',
            controller: 'AddStuDetails'
        })
        .otherwise({ redirectTo: '/home'             
        });
}]);