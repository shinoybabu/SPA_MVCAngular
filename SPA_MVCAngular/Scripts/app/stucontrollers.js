/// <reference path="../angular.js" />
var stucontrollers = angular.module("stucontroller", []);

stucontrollers.controller("GetStudentsList", function GetStudentsList($scope, $http) {
    $scope.getAll = function () {
        $http.get("api/Students").success(function (data) {
            $scope.students = data;
        });
    }

    $scope.getAll();   

    $scope.Remove=function(Id){
        $http({method:"DELETE", url:"api/students/"+Id})
            .success(function () {
                alert("Deleted successfully.")
                $scope.getAll();
            });
    }
});

stucontrollers.controller("AddStudent", function AddStudent($scope, $http, $location) {
    $scope.student={
        "FirstName": "",
        "LastName":"",
        "Age" : "",
        "Gender":"Male"
    };
    $scope.genders=["Male", "Female","Other"];
    $scope.pattern=/^\s*\d+\s*$/;
    $scope.Add=function(){
        $http({ method: "POST", data: $scope.student, url: "api/Students" }).
            success(function(data,status,headers,config){
                $scope.students=data;
                $scope.student={
                    "FirstName": "",
                    "LastName":"",
                    "Age" : "",
                    "Gender":""
                };
                alert("Student added successfully");
                $location.path('/students');
            });        
    }
});
