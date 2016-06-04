var studetailscontrollers = angular.module("studetailscontroller", []);

studetailscontrollers.controller("StuDetails", function StuDetails($scope, $http, $routeParams) {
    $scope.getStudent = function (id) {
        $http.get("api/Students/" + id).success(function (data) {
            $scope.student = data;
        });
    }
    var id = $routeParams.id;
    $scope.getStudent(id);
});

studetailscontrollers.controller("AddStuDetails", function AddStuDetails($scope, $http, $location, $routeParams) {
    var id = $routeParams.id;
    $scope.studetail = {
        "studentId": id,
        "Address1": "",
        "Address2": "",
        "Married": 0
    };

    $scope.Add = function () {
        
        $http({ method: "POST", data: $scope.studetail, url: "api/studentDetails" }).
            success(function (data, status, headers, config) {
                $scope.studetails = data;
                $scope.studetail = {
                    "studentId": 1,
                    "Address1": "",
                    "Address2": "",
                    "Married": 0
                };
                alert("Student Details added successfully");
                debugger;
                $location.path('/studetails/' + id);
            });
    }
});